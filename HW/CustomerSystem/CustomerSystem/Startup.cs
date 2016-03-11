using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomerSystem.Startup))]
namespace CustomerSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
