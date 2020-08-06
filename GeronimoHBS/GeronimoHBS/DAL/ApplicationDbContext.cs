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


        public DbSet<GymOverview> GymOverview { get; set; }
        public DbSet<GymClasses> GymClasses { get; set; }
        public DbSet<Timetable> Timetable { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<ClassFocus> ClassFocus { get; set; }


        public DbSet<SpaOverview> SpaOverview { get; set; }
        public DbSet<SpaPromotion> SpaPromotion { get; set; }
        public DbSet<PromotionCategory> PromotionCategory { get; set; }
        
        
        
        public DbSet<DiningOverview> DiningOverview { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }





        public DbSet<EventOverview> EventOverview { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventStatus> EventsStatus { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<VenueStatus> VenuesStatus { get; set; }





        public DbSet<RoomOverview> RoomOverview { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Amenity> Amenities { get; set; }


        public DbSet<Location> Location { get; set; }



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