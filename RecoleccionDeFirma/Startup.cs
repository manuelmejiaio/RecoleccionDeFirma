using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecoleccionDeFirma.Startup))]
namespace RecoleccionDeFirma
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
