using MultiPlug.Base;

namespace MultiPlug.Ext.HostAPd.Config.Models.Components
{
    public class SharedProperties : MultiPlugBase
    {
        public bool RebootUserPrompt { get; set; } = false;
    }
}
