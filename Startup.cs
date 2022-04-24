using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CuoiKy.Startup))]
namespace CuoiKy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
