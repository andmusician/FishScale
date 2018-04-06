using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FishScale.Startup))]
namespace FishScale
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
