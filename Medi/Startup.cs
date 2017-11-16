using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Medi.Startup))]
namespace Medi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
