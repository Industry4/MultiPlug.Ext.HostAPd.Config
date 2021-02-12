using MultiPlug.Base.Attribute;
using MultiPlug.Base.Http;
using MultiPlug.Ext.HostAPd.Config.Models.Components.Home;

namespace MultiPlug.Ext.HostAPd.Config.Controllers.Settings.Home
{
    [Route("")]
    public class HomeController : SettingsApp
    {
        public Response Get()
        {
            return new Response
            {
                Model = Core.Instance.Home.RepopulateAndGetProperties(),
                Template = "HostAPdConfig_Settings_Home"
            };
        }

        public Response Post(HomeProperties thePostProperties)
        {
            Core.Instance.Home.UpdateProperties(thePostProperties);

            var Response = Get();

            Response.StatusCode = System.Net.HttpStatusCode.Created;

            return Response;
        }
    }
}
