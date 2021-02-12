using MultiPlug.Ext.HostAPd.Config.Properties;
using MultiPlug.Extension.Core;
using MultiPlug.Extension.Core.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlug.Ext.HostAPd.Config
{
    public class HostAPdConfig : MultiPlugExtension
    {
        public override RazorTemplate[] RazorTemplates
        {
            get
            {
                return new RazorTemplate[]
                {
                    new RazorTemplate("HostAPdConfig_Settings_Navigation", Resources.SettingsNavigation),
                    new RazorTemplate("HostAPdConfig_Settings_Home", Resources.SettingsHome),
                    new RazorTemplate("HostAPdConfig_Settings_About", Resources.SettingsAbout)
                };
            }
        }

    }
}
