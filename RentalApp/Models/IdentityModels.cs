using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace RentalApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        //This class creates the 'AspNetUsers' table in the database,
        //I wanted the custom user information to be kept seperate from the aspnet user information, 
        //so adding this virtual field to user info class I created makes a FK to the UserInfo table when the DB is 
        //created
        public virtual UserInfo UserInfo { get; set; }


    }
}