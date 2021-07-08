using Owin;
using System;

namespace PingApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            try
            {
                app.UseErrorPage();
                app.UseWelcomePage("/");
                ConfigureWebApi(app);
                app.UseWebApi(config);
                
            }
            catch(Exception e)
            {
                app.Use(e.Message);
            }
        }
    }
}
