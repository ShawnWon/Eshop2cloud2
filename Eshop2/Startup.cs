using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eshop2.Startup))]
namespace Eshop2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            /*app.UseGoogleAuthentication(
               clientId: "000-000.apps.googleusercontent.com",
               clientSecret: "00000000000");*/
        }
    }
}
