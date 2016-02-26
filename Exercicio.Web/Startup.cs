using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Exercicio.Web.Startup))]
namespace Exercicio.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
