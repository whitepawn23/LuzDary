using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoLuz.Startup))]
namespace DemoLuz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
