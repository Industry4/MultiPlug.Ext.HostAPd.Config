using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using MultiPlug.Ext.HostAPd.Config.Models.Components.Home;
using MultiPlug.Ext.HostAPd.Config.Utils.Swan;

namespace MultiPlug.Ext.HostAPd.Config.Components.Home
{
    public class HomeComponent : HomeProperties
    {
        private string Location = "/etc/hostapd/hostapd.conf";

        private const string c_LinuxSystemControlCommand = "systemctl";
        private const string c_HostAPdCommand = "hostapd";

        private bool m_RunningLinux = false;

        internal HomeComponent()
        {
          m_RunningLinux = isRunningLinux();

            if (! m_RunningLinux)
            {
                Location = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hostapd.conf");
            }  
        }

        private bool isRunningLinux()
        {
            if (Type.GetType("Mono.Runtime") != null)
            {
                try
                {
                    Task<ProcessResult> RaspberryPiModel = ProcessRunner.GetProcessResultAsync("cat", "/proc/device-tree/model");

                    RaspberryPiModel.Wait();

                    return RaspberryPiModel.Result.Okay();
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        internal void UpdateProperties(HomeProperties theProperties)
        {
            bool RestartHostAPd = false;

            IEnumerable<PropertyInfo> Properties = typeof(HomeProperties).GetProperties().Where(Property => Property.IsDefined(typeof(Models.Attributes.FileName), false));

            foreach (PropertyInfo Property in Properties)
            {
                Models.Attributes.FileName FileNameAttribute = Property.GetCustomAttribute<Models.Attributes.FileName>();
                if (FileNameAttribute != null)
                {
                    string Old = Property.GetValue(this) as string;
                    string New = Property.GetValue(theProperties) as string;

                    if ( ( Old == null && New != null ) || ( ! Old.Equals( New, StringComparison.Ordinal ) ) ) 
                    {
                        Property.SetValue(this, New);
                        RestartHostAPd = true;
                    }
                }
            }

            Save();

            if (m_RunningLinux && HostAPdEnabled != theProperties.HostAPdEnabled)
            {
                Task<ProcessResult> StartHostAPd = null;
                Task<ProcessResult> DisableHostAPd = null;

                if (theProperties.HostAPdEnabled)
                {
                    Task<ProcessResult> EnableHostAPd = ProcessRunner.GetProcessResultAsync(c_LinuxSystemControlCommand, "enable " + c_HostAPdCommand);
                    EnableHostAPd.Wait();

                    if (EnableHostAPd.Result.Okay())
                    {
                        StartHostAPd = ProcessRunner.GetProcessResultAsync(c_LinuxSystemControlCommand, "start " + c_HostAPdCommand);
                        StartHostAPd.Wait();
                    }
                }
                else
                {
                    Task<ProcessResult> StopTimesyncd = ProcessRunner.GetProcessResultAsync(c_LinuxSystemControlCommand, "stop " + c_HostAPdCommand);
                    StopTimesyncd.Wait();

                    if (StopTimesyncd.Result.Okay())
                    {
                        DisableHostAPd = ProcessRunner.GetProcessResultAsync(c_LinuxSystemControlCommand, "disable " + c_HostAPdCommand);
                        DisableHostAPd.Wait();
                    }
                }
            }
            else if(m_RunningLinux && HostAPdEnabled && RestartHostAPd)
            {
                Task<ProcessResult> Restart = ProcessRunner.GetProcessResultAsync(c_LinuxSystemControlCommand, "restart " + c_HostAPdCommand);
                Restart.Wait();
            }
        }

        private void Save()
        {
            var StringBuilder = new StringBuilder();

            IEnumerable<PropertyInfo> Properties = GetType().GetProperties().Where(Property => Property.IsDefined(typeof(Models.Attributes.FileName), false));

            foreach(PropertyInfo Property in Properties)
            {
                Models.Attributes.FileName FileNameAttribute = Property.GetCustomAttribute<Models.Attributes.FileName>();
                if (FileNameAttribute != null)
                {
                    string Value = Property.GetValue(this) as string;

                    if( ! string.IsNullOrEmpty(Value))
                    {
                        StringBuilder.Append(FileNameAttribute.Name);
                        StringBuilder.Append("=");
                        StringBuilder.Append(Value);
                        StringBuilder.Append("\n");
                    }
                }
            }

            if (OrphanLines != null)
            {
                foreach (string Line in OrphanLines)
                {
                    StringBuilder.Append(Line);
                    StringBuilder.Append("\n");
                }
            }

            using (StreamWriter FileStream = new StreamWriter(Location, false, new UTF8Encoding(false)))
            {
                FileStream.Write(StringBuilder.ToString());
            }
        }

        private void SetDefaults(List<PropertyInfo> Properties)
        {
            HostAPdEnabled = false;

            foreach (PropertyInfo Property in Properties)
            {
                Models.Attributes.FileName FileNameAttribute = Property.GetCustomAttribute<Models.Attributes.FileName>();

                if (FileNameAttribute != null )
                {
                    Property.SetValue(this, string.Empty);
                }
            }

        }

        internal HomeProperties RepopulateAndGetProperties()
        {
            List<PropertyInfo> Properties = GetType().GetProperties().Where(prop => prop.IsDefined(typeof(Models.Attributes.FileName), false)).ToList();

            SetDefaults(Properties);

            if(m_RunningLinux)
            {
                Task<ProcessResult>[] Tasks = new Task<ProcessResult>[1];

                Tasks[0] = ProcessRunner.GetProcessResultAsync("systemctl", "is-active hostapd");

                Task.WaitAll(Tasks);

                HostAPdEnabled = Tasks[0].Result.Okay() ? Tasks[0].Result.GetOutput().TrimEnd().Equals("active") : false;
            }

            if (!File.Exists(Location))
            {
                return this;
            }

            List<string> OrphanLinesList = new List<string>();



            using (System.IO.StreamReader file = new System.IO.StreamReader(Location))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] KeyValue = line.Split('=');

                    PropertyInfo LinkedProperty = null;

                    if (KeyValue.Length == 2 && (! KeyValue[0].Contains("#") ))
                    {
                        string Key = KeyValue[0].Trim();

                        foreach (PropertyInfo Property in Properties)
                        {
                            Models.Attributes.FileName FileNameAttribute = Property.GetCustomAttribute<Models.Attributes.FileName>();

                            if (FileNameAttribute != null && Key.Equals(FileNameAttribute.Name, StringComparison.OrdinalIgnoreCase))
                            {
                                Property.SetValue(this, KeyValue[1]);
                                LinkedProperty = Property;
                                break;
                            }
                        }

                        if( LinkedProperty != null)
                        {
                            Properties.Remove(LinkedProperty);
                        }
                        else
                        {
                            OrphanLinesList.Add(line);
                        }

                    }
                    else
                    {
                        OrphanLinesList.Add(line);
                    }
                }
            }

            OrphanLines = OrphanLinesList.ToArray();

            return this;
        }
    }
}
