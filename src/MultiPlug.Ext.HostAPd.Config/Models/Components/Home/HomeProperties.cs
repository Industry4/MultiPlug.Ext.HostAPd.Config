
using MultiPlug.Ext.HostAPd.Config.Models.Attributes;

namespace MultiPlug.Ext.HostAPd.Config.Models.Components.Home
{
    public class HomeProperties : SharedProperties
    {
        public bool HostAPdEnabled { get; set; }

        public bool SSIDSync { get; set; } = true;

        [FileName("interface")]
        public string Interface { get; set; }
        [FileName("hw_mode")]
        public string HWMode { get; set; }
        [FileName("channel")]
        public string Channel { get; set; }
        [FileName("wmm_enabled")]
        public string WmmEnabled { get; set; }
        [FileName("macaddr_acl")]
        public string MACAddressAcl { get; set; }
        [FileName("auth_algs")]
        public string AuthAlgs { get; set; }
        [FileName("ignore_broadcast_ssid")]
        public string IgnoreBroadcastSSID { get; set; }
        [FileName("rsn_pairwise")]
        public string RsnPairwise { get; set; }
        [FileName("ssid")]
        public string SSID { get; set; }
        [FileName("wpa_passphrase")]
        public string WPAPassphrase { get; set; }
        [FileName("wpa_psk")]
        public string WPAPSK { get; set; }
        [FileName("wpa")]
        public string WPA { get; set; }
        [FileName("wpa_key_mgmt")]
        public string WPAKeyManagement { get; set; }
        [FileName("wpa_pairwise")]
        public string WPAPairwise { get; set; }
        public string[] OrphanLines { get; set; }
    }
}
