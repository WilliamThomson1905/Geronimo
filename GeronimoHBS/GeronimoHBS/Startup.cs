using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GeronimoHBS.Startup))]
namespace GeronimoHBS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
