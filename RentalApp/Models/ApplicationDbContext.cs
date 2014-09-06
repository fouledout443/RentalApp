using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RentalApp.Models
{
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Disabling the table pluralization convention
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            //Adding the optional relationship for a residence having a landlord
            modelBuilder.Entity<Residence>()
                .HasOptional<LandLord>(r => r.LandLord)
                .WithOptionalDependent(l => l.Residence).Map(p => p.MapKey("Residence"));
        }

        //Adding these DbSets is creating the tables in the database
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Residence> Residence { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<LandLord> LandLords { get; set; }
    }
}

#region Online Example
//public class User
//{
//    [Key]
//    public string Username { get; set; }

//    public virtual Contact Contact { get; set; }
//}

//public class Contact
//{
//    [Key]
//    public int ID { get; set; }
//    public string Name { get; set; }

//    public virtual User User { get; set; }
//}
//        modelBuilder.Entity<User>()
//            .HasOptional<Contact>(u => u.Contact)
//            .WithOptionalDependent(c => c.User).Map(p => p.MapKey("ContactID"));

#endregion




