using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestaurantGo.Startup))]
namespace RestaurantGo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
