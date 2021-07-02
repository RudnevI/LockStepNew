using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using LockStep.Library.Domain;
using LockStep.Library.Domain.Finance;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LockStepNew.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors{ get; set; }
        public DbSet<BookComment> BookComments{ get; set; }
        public DbSet<BookGenre> BookGenres{ get; set; }
        public DbSet<BookVote> BookVotes{ get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Check> Checks{ get; set; }
        public DbSet<Payment> Payments{ get; set; }
        public DbSet<Price> Prices{ get; set; }

        

        


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}