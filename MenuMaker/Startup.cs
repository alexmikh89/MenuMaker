using MenuMaker.Data.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MenuMaker.Startup))]
namespace MenuMaker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //Initializer.Initialize();
        }
    }
}
