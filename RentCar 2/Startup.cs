using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentCar_2.Startup))]
namespace RentCar_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
