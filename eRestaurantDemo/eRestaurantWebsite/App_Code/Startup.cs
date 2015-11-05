using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eRestaurantWebsite.Startup))]
namespace eRestaurantWebsite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
