using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AppRent.WebApi.Startup))]

namespace AppRent.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
