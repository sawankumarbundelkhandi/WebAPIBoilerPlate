using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebAPIBoilerPlate.Startup))]

namespace WebAPIBoilerPlate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}