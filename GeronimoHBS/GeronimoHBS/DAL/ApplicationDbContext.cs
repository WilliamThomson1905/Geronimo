using GeronimoHBS.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GeronimoHBS.DAL
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       
        public DbSet<Staff> Staff { get; set; } 



        public ApplicationDbContext() : base("ApplicationDbContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }
    }
}