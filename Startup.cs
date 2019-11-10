using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineJewelryShoppingMVC.Startup))]
namespace OnlineJewelryShoppingMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
