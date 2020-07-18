using System;
using System.Collections.Generic;
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
    public class Admin : Staff
    {
    }

    /// <summary>
    /// There are five Geronimo Hotel locations: Glasgow, Paris, New York, amsterdam and London. 
    /// There could be more hotels distributed in other locations in the future. 
    /// </summary>
    public class Location
    {

        [Key]
        public int LocationID { get; set; }

        [Required]
        [StringLength(500)]
        public string LocationName { get; set; }

        [Required]
        [StringLength(500)]
        public string LocationIntroduction { get; set; }



        // Foriegn key 
        public int RoomOverviewID { get; set; }
        // Corresponding navigation property - each hotel has rooms 
        public virtual RoomOverview RoomOverview { get; set; }
    }


    public class RoomOverview
    {
        [Key]
        public int RoomOverviewID { get; set; }

        public string Header { get; set; }

        public string Content { get; set; }

      


        // Navigation property - multiple types of room:  standard, premium etc. 
        public virtual ICollection<RoomType> RoomType { get; set; }
    }


    public class RoomType 
    {
        [Key]
        public int RoomTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RoomOverview> RoomOverview { get; set; }


    }





    public class Room
    {
        //Primary Key  
        public int RoomID { get; set; }

        public int FloorNumber { get; set; }
        public int RoomNumber { get; set; }
        public int NumberOfBeds { get; set; }


        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }


    }


    // Example: wifi
    public class Amenity
    {
        public int AmenityID { get; set; }

        public string Name { get; set; }

    }












    public class Gymm
    {

    }
    public class Spa
    {

    }

    public class Events
    {


    }
    public class Dining
    {

    }


}