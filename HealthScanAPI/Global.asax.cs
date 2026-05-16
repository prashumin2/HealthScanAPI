using System.Web.Http;

namespace HealthScanAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest()
        {
            if (Request.Url.AbsolutePath == "/")
            {
                Response.Redirect("/swagger");
            }
        }
    }
}
