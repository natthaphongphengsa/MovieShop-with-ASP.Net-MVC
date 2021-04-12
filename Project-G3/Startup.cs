using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_G3.Startup))]
namespace Project_G3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
