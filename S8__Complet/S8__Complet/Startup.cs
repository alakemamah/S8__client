using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(S8__Complet.Startup))]
namespace S8__Complet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
