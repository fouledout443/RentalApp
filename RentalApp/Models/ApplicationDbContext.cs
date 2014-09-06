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




