using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Concordia_Web_App.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Concordia_Web_App.Models.Appointment> Appointments { get; set; }

        //public System.Data.Entity.DbSet<Concordia_Web_App.Models.ApplicationUser> ApplicationUsers { get; set; }

        public System.Data.Entity.DbSet<Concordia_Web_App.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<Concordia_Web_App.Models.Class_Grade> Class_Grade { get; set; }

        public System.Data.Entity.DbSet<Concordia_Web_App.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<Concordia_Web_App.Models.Course_Class> Course_Class { get; set; }

        public System.Data.Entity.DbSet<Concordia_Web_App.Models.Student_Address> Student_Address { get; set; }

        public System.Data.Entity.DbSet<Concordia_Web_App.Models.Student_Graduation_Info> Student_Graduation_Info { get; set; }
    }
}