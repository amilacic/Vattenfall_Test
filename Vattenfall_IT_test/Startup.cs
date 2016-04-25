using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vattenfall_IT_test.Startup))]
namespace Vattenfall_IT_test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
