using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidlay.Startup))]
namespace Vidlay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
