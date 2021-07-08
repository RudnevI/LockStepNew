using LockStepNew.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            SetupAuth();
        }

        private void SetupAuth()
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole> ( new RoleStore<IdentityRole>(context) );
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!roleManager.RoleExists("Admin")) 
                roleManager.Create(new IdentityRole { Name = "Admin" });
            if (!roleManager.RoleExists("Manager"))
                roleManager.Create(new IdentityRole { Name = "Manager" });
            if (!roleManager.RoleExists("User"))
                roleManager.Create(new IdentityRole { Name = "User" });

            var user = new ApplicationUser { UserName = "stepadmin@gmail.com", Email = "stepadmin@gmail.com" };
            string userPassword = "qwerty";

            var checkUser = userManager.Create(user, userPassword);
            if (checkUser.Succeeded)
                userManager.AddToRole(user.Id, "Admin");

            
        }
    }
}
