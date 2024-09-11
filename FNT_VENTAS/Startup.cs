using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FNT_VENTAS.Startup))]
namespace FNT_VENTAS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
