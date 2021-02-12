using MultiPlug.Base;
using MultiPlug.Ext.HostAPd.Config.Components.About;
using MultiPlug.Ext.HostAPd.Config.Components.Home;

namespace MultiPlug.Ext.HostAPd.Config
{
    public class Core : MultiPlugBase
    {
        private static Core m_Instance = null;

        //private ILoggingService m_LoggingService;
        //private IMultiPlugActions m_MultiPlugActions;

        //private SharedProperties[] m_AllComponents;

        public static Core Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Core();
                }
                return m_Instance;
            }
        }


        internal HomeComponent Home { get; private set; } = new HomeComponent();
        internal AboutComponent About { get; private set; } = new AboutComponent();
    }
}
