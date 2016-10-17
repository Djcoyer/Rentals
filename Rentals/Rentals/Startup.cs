using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rentals.Startup))]
namespace Rentals
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
