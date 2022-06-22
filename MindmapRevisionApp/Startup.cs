using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MindmapRevisionApp.Startup))]
namespace MindmapRevisionApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
