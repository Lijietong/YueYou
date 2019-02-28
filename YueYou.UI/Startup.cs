using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YueYou.UI.Startup))]
namespace YueYou.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
