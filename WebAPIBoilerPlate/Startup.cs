using Microsoft.Owin;
using Owin;
using WebAPIBoilerPlate;

[assembly: OwinStartup(typeof(Startup))]

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