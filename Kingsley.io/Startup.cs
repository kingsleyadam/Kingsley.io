using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kingsley.io.Startup))]
namespace Kingsley.io
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}