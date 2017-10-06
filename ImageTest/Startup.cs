using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImageTest.Startup))]
namespace ImageTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
