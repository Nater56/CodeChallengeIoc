using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheIocProject.Startup))]
namespace TheIocProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
