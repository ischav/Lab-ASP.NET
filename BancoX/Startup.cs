using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BancoX.Startup))]
namespace BancoX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
