using MultiPlug.Base.Http;
using MultiPlug.Extension.Core.Attribute;

namespace MultiPlug.Ext.HostAPd.Config.Controllers.Settings
{
    [HttpEndpointType(HttpEndpointType.Settings)]
    [ViewAs(ViewAs.Partial)]
    [Name("WiFi Access Point")]
    public class SettingsApp : Controller
    {
    }
}
