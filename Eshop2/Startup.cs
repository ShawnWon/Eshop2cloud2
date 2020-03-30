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
        }

        public void ConfigereServices()
        { 
            
        }
    }
}
