using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TicketTrackingSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //Tuesday:1/8/19 Adding a new attribute to Asp.NetUsers Table
        public string FirstName { get; internal set; }
        //Tuesday:1/8/19 Adding a new attribute to Asp.NetUsers Table
        public string LastName { get; internal set; }
        //Tuesday:1/8/19 Adding a new attribute to Asp.NetUsers Table
        public string Address { get; internal set; }
        //Tuesday:1/8/19 Adding a new attribute to Asp.NetUsers Table
        public string City { get; internal set; }
        //Tuesday:1/8/19 Adding a new attribute to Asp.NetUsers Table
        public string Zip { get; internal set; }
        //Tuesday:1/8/19 Adding a new attribute to Asp.NetUsers Table
        public string State { get; internal set; }

        public bool IsActive { get; set; } = true;

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }

        public class TicketTrackingSystemContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx



      
        
            public TicketTrackingSystemContext() : base("name=TicketTrackingSystemContext")
        {
        }

        public static TicketTrackingSystemContext Create()
        {
            return new TicketTrackingSystemContext();
        }

        public System.Data.Entity.DbSet<TicketTrackingSystem.Models.Ticket> Tickets { get; set; }

        public System.Data.Entity.DbSet<TicketTrackingSystem.Models.User> Users { get; set; }
    }
}
