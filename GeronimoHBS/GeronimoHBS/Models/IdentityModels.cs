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

        // Foriegn key 
        public int GymOverviewID { get; set; }
        // Corresponding navigation property - each hotel might have a gym 
        public virtual GymOverview GymOverview { get; set; }



        // Foriegn key 
        public int SpaOverviewID { get; set; }
        // Corresponding navigation property - each hotel might have a gym 
        public virtual SpaOverview SpaOverview { get; set; }
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












    public class GymOverview
    {
        [Key]
        public int GymOverviewID { get; set; }

        public string Header { get; set; }

        public string Content { get; set; }



        // Navigation property. 
        public virtual ICollection<Equipment> Equipment { get; set; }

        // Navigation property. 
        public virtual ICollection<GymClasses> GymClasses { get; set; }

        // Navigation property. 
        public virtual ICollection<Timetable> Timetable { get; set; }

    }

    public class Equipment
    {
        [Key]
        public int EquipmentID { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public virtual ICollection<GymOverview> GymOverview { get; set; }

    }


    public class GymClasses
    {
        [Key]
        public int GymClassesID { get; set; }

        public string Title { get; set; }

        public string Introduction { get; set; }
        public string Description { get; set; }
        public string Benefits { get; set; }


        public virtual ICollection<ClassFocus> Focus { get; set; }

        public virtual ICollection<GymOverview> GymOverview { get; set; }


    }

    public class ClassFocus
    {
        [Key]
        public int ClassFocusID { get; set; }

        public string Title { get; set; }
        public string DisplayTitle { get; set; }
        public virtual ICollection<GymClasses> GymClasses { get; set; }

    }




    public class Timetable
    {
        public Timetable()
        {
            GymClassStatus = GymClassStatus.AVAILABLE;
        }


        [Key]
        public int TimetableID { get; set; }

        [Required]
        public Day Day { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }


        public string Instructor { get; set; }




        [Required]
        public GymClassStatus GymClassStatus { get; set; }

        [Required]
        // Foriegn key 
        public int GymClassesID { get; set; }
        // Corresponding navigation property 
        public virtual GymClasses GymClasses { get; set; }

   


    }


    public enum GymClassStatus
    {
        AVAILABLE, FULLYBOOKED, CANCELLED
    }

    public enum Day
    {
        // Days of gym classes
        MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY, SATURDAY, SUNDAY
    }




    public class SpaOverview
    {
        [Key]
        public int SpaOverviewID { get; set; }

        public string Header { get; set; }

        public string IntroductionParagraph { get; set; }
        public string MainContent { get; set; }

        public string SecondaryContent { get; set; }


        // Navigation property - multiple promotions per spa:  
        // the same promotions can be used between locations. 
        public virtual ICollection<SpaPromotion> SpaPromotions { get; set; }
    }



    public class SpaPromotion
    {
        public int SpaPromotionID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        public virtual ICollection<SpaOverview> SpaOverview { get; set; }

        // Foriegn key 
        public int PromotionCategoryID { get; set; }
        // Corresponding navigation property - each promotion has a type/category 
        public virtual PromotionCategory PromotionCategory { get; set; }


    }

    public class PromotionCategory
    {
        public int PromotionCategoryID { get; set; }

        public string PromotionName { get; set; }
    }






    public class Event
    {


    }
    public class Dining
    {

    }


}