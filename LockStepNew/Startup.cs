using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LockStepNew.Startup))]
namespace LockStepNew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
