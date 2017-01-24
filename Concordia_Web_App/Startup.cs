using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Concordia_Web_App.Startup))]
namespace Concordia_Web_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
