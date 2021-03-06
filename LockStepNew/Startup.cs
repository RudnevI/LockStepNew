using Hangfire;
using LockStepNew.Models;
using LockStepNew.Scheduler;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Linq;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(LockStepNew.Startup))]
namespace LockStepNew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            SetupAuth();

            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            var builder = new ContainerBuilder();


            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ApplicationDbContext>();
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>();
            builder.RegisterType<BookRepository>().As<IBookRepository>();
            builder.RegisterType<GenreRepository>().As<IGenreRepository>();
            builder.RegisterType<BookAuthorRepository>().As<IBookAuthorRepository>();
            builder.RegisterType<BookGenreRepository>().As<IBookGenreRepository>();
            builder.RegisterType<BookCommentRepository>().As<IBookCommentRepository>();
            builder.RegisterType<BookVoteRepository>().As<IBookVoteRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<PriceRepository>().As<IPriceRepository>();






            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();

            new JobFactory().ScheduleJob();
        }


        private void SetupAuth()
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole> ( new RoleStore<IdentityRole>(context) );
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            (new string[] { "Admin", "Manager", "User" })
                .ToList()
                .ForEach(p => CreateRole(roleManager, p));
        

            var adminUser = new ApplicationUser { UserName = "stepadmin@gmail.com", Email = "stepadmin@gmail.com" };
            var managerUser = new ApplicationUser { UserName = "manager@gmail.com", Email = "manager@gmail.com" };
            var user = new ApplicationUser { UserName = "user@gmail.com", Email = "user@gmail.com"};


            string userPassword = "qwerty";

            var checkUserAdmin = userManager.Create(adminUser, userPassword);
            if (checkUserAdmin.Succeeded)
                userManager.AddToRole(adminUser.Id, "Admin");

            var checkManagerUser = userManager.Create(managerUser, userPassword);
            if (checkManagerUser.Succeeded)
                userManager.AddToRole(managerUser.Id, "Manager");

            var checkUser = userManager.Create(user, userPassword);
            if (checkUser.Succeeded)
                userManager.AddToRole(user.Id, "User");
        

            
        }

        private void CreateRole(RoleManager<IdentityRole> manager, string name)
        {
            if(manager.RoleExists(name))
            {
                manager.Create(new IdentityRole { Name = name });
            }
        } 

        private void CreateUsers(UserManager<ApplicationUser>manager, User usr)
        {
            var user = new ApplicationUser { UserName = usr.UserName, Email = usr.Email };

           
        }
        class User
        {
            public string UserName { get; set; }

            public string Email { get; set; }

            public string Pwd { get; set; }
        }
    }
}
