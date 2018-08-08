using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NFC_MVC.Startup))]
namespace NFC_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
