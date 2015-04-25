using Autofac;

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
            var builder = new ContainerBuilder();
            // Register dependencies, then...
            var container = builder.Build();

            // Register the Autofac middleware FIRST.
            app.UseAutofacMiddleware(container);
        }
    }
}
