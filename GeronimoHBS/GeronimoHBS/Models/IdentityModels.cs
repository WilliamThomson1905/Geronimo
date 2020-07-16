using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GeronimoHBS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Title { get; set; }

        [Required]
        [StringLength(25)]
        public string Forename { get; set; }

        [Required]
        [StringLength(25)]
        public string Surname { get; set; }


    

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class Guest : ApplicationUser
    {
    }

    public class Staff : ApplicationUser
    {
    }
    public class Manager : Staff
    {
        // the hotel location that they manage
        public string Location { get; set; }
    }
    public class Admin : Manager
    {
    }

    /// <summary>
    /// There are five Geronimo Hotel locations: Glasgow, Paris, New York, amsterdam and London. 
    /// There could be more hotels distributed in other locations in the future. 
    /// </summary>
    public class Location
    {
        public int LocationID { get; set; }

        [Required]
        [StringLength(50)]
        public string LocationName { get; set; }



    }





}