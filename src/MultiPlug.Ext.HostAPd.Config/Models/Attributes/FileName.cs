using System;

namespace MultiPlug.Ext.HostAPd.Config.Models.Attributes
{
    internal class FileName :Attribute
    {
        private string m_FileName;
        internal FileName( string theName)
        {
            m_FileName = theName;
        }

        public string Name
        {
            get
            {
                return m_FileName;
            }
        }
    }
}
