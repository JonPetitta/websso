using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(api.App_Start.Startup))]

namespace api.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application
            // visit https://go.microsoft.com/fwlink/?LinkID=316888

            // allow frontend to call into backend
            app.UseCors(CorsOptions.AllowAll);

            // config web api
            var configuration = new HttpConfiguration();

            FormatterConfig.Configure(configuration);
            RouteConfig.Configure(configuration);

            app.UseWebApi(configuration);

            ConfigureAuth(app);
        }
    }
}
