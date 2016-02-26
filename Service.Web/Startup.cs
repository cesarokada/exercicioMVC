using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Service.Web.Startup))]
namespace Service.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
