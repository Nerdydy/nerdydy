using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(nerdydy.Startup))]
namespace nerdydy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
