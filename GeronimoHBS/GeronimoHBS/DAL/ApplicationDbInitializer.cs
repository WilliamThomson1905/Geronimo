using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GeronimoHBS.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GeronimoHBS.DAL
{
    public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var userStore = new UserStore<ApplicationUser>(context);



            if (!roleManager.RoleExists(RoleNames.ROLE_ADMINISTRATOR))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_ADMINISTRATOR));
            }
            if (!roleManager.RoleExists(RoleNames.ROLE_MANAGER))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_MANAGER));
            }
            if (!roleManager.RoleExists(RoleNames.ROLE_STAFF))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_STAFF));
            }
            if (!roleManager.RoleExists(RoleNames.ROLE_GUEST))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_GUEST));
            }
            if (!roleManager.RoleExists(RoleNames.ROLE_SUSPENDED))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_SUSPENDED));
            }









            //_________________________________________________________________
            // Seeding an initial admin user
            string userName = "admin@test.com";
            string password = "Password_1";
            //  var passwordHash = new PasswordHasher();
            //  password = passwordHash.HashPassword(password);

            var user = userManager.FindByName(userName);

            if (user == null)
            {
                var newUser = new Admin()
                {
                    Forename = "William",
                    Surname = "Thomson",
                    Title = "Mr",
                    UserName = userName,
                    Email = userName,
                    EmailConfirmed = true

                };

                userManager.Create(newUser, password);
                userManager.AddToRole(newUser.Id, RoleNames.ROLE_ADMINISTRATOR);
            }


            var guests = new List<Guest>
            {
                new Guest {
                    UserName ="1@guest.com",
                    Email ="1@guest.com",
                    Forename ="Barns",
                    Surname ="Courtney"
                },
                new Guest {
                    UserName ="2@guest.com",
                    Email ="2@guest.com",
                    Forename ="Bob",
                    Surname ="Dylan"
                },
                new Guest {
                    UserName ="3@guest.com",
                    Email = "3@guest.com",
                    Forename ="Bon",
                    Surname ="Jovi"
                }
            };

            foreach (var guest in guests)
            {
                string generalPassword = "Password_1";
                userManager.Create(guest, generalPassword);
                userManager.AddToRole(guest.Id, RoleNames.ROLE_GUEST);
            }
            context.SaveChanges();

            // Seeding Manager staff
            var staffUsers = new List<Staff>
            {
                new Staff {
                    UserName ="1@staff.com",
                    Email = "1@staff.com",
                    Forename = "Danial",
                    Surname = "Barenboim"
                },
                new Staff {
                    UserName ="2@staff.com",
                    Email = "2@staff.com",
                    Forename = "Hilary",
                    Surname = "Hahn"
                },
                new Staff {
                    UserName ="3@staff.com",
                    Email = "3@staff.com",
                    Forename = "Igor",
                    Surname = "Stravinsky"
                },

            };

            foreach (var staff in staffUsers)
            {
                string generalPassword = "Password_1";
                userManager.Create(staff, generalPassword);
                userManager.AddToRole(staff.Id, RoleNames.ROLE_STAFF);
            }
            context.SaveChanges();

            // Seeding managers - one for each hotel
            var managerUsers = new List<Manager>
            {
                new Manager {
                    UserName ="1@manager.com",
                    Email = "1@manager.com",
                    Forename = "James",
                    Surname = "Bay",
                    Location = "Glasgow"
                },
                new Manager {
                    UserName ="2@manager.com",
                    Email = "2@manager.com",
                    Forename = "Janine",
                    Surname = "Jansen",
                    Location = "New York"

                },
                new Manager {
                    UserName ="3@manager.com",
                    Email = "3@manager.com",
                    Forename = "Johannes",
                    Surname = "Brahms",
                    Location = "Paris"
                }

            };

            foreach (var manager in managerUsers)
            {
                string generalPassword = "Password_1";
                userManager.Create(manager, generalPassword);
                userManager.AddToRole(manager.Id, RoleNames.ROLE_MANAGER);
            }
            context.SaveChanges();



            List<RoomType> roomTypes = new List<RoomType>
            {
                new RoomType
                {
                    Name = "Standard Suite",
                    Description = "Standard Suite description extraordinaire. " +
                    "Standard Suite description extraordinaire. Standard Suite description extraordinaire. "
                },
                new RoomType
                {
                    Name = "Premium Suite",
                    Description = "Premium Suite description extraordinaire. " +
                    "Premium Suite description extraordinaire. Premium Suite description extraordinaire. Premium Suite description extraordinaire. "
                }
            };

            roomTypes.ForEach(l => context.RoomType.Add(l));
            context.SaveChanges();

            var roomOverview = new List<RoomOverview>
            {
                new RoomOverview
                {
                    Header = "Default Rooms",
                    Content = "dssssss",
                    RoomType = roomTypes
                },
                new RoomOverview
                {
                    Header = "Glasgow Rooms",
                    Content = "gssssss",
                    RoomType = roomTypes
                },
                new RoomOverview
                {
                    Header = "Paris Rooms",
                    Content = "ssgggssss",
                    RoomType = roomTypes
                },
                new RoomOverview
                {
                    Header = "Amsterdam Rooms",
                    Content = "ssssdassss",
                    RoomType = roomTypes
                }, 
                new RoomOverview
                {
                    Header = "New York Rooms",
                    Content = "ssaassss",
                    RoomType = roomTypes
                },
                new RoomOverview
                {
                    Header = "London Rooms",
                    Content = "ssaassss",
                    RoomType = roomTypes
                },

            };
            roomOverview.ForEach(l => context.RoomOverview.Add(l));
            context.SaveChanges();








            var equipment = new List<Equipment>
            {
                new Equipment
                {
                    Name = "item1",
                    Description = "item1 description item1 description item1 description. ",
                    Quantity = 13
                },
                new Equipment
                {
                    Name = "item2",
                    Description = "item2 description item2 description item2 description. ",
                    Quantity = 21

                },new Equipment
                {
                    Name = "item3",
                    Description = "item3 description item3 description item3 description. ",
                    Quantity = 7

                }

            };
            equipment.ForEach(l => context.Equipment.Add(l));
            context.SaveChanges();





            // Seeding five classes that guest can attend at the gym - these will be used with the Timetable instanes below 
            var gymClasses = new List<GymClasses>()
            {
                new GymClasses {
                    Title ="Gym Class 1",
                    Description = "Gym Class 1 description. ",

                },
                new GymClasses {
                    Title ="Gym Class 2",
                    Description = "Gym Class 2 description. "
                },
                new GymClasses {
                    Title ="Gym Class 3",
                    Description = "Gym Class 3 description. "
                },
                new GymClasses {
                    Title ="Gym Class 4",
                    Description = "Gym Class 4 description. "
                },
                new GymClasses {
                    Title ="Gym Class 5",
                    Description = "Gym Class 5 description. "
                },


            };

            gymClasses.ForEach(l => context.GymClasses.Add(l));
            context.SaveChanges();



            var timetable = new List<Timetable>
            {
                // MONDAY
                new Timetable()
                {
                    Day = Day.MONDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    GymClasses = gymClasses[0],
                    GymClassesID = gymClasses[0].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.TUESDAY,
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(10, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    GymClasses = gymClasses[0],
                    GymClassesID = gymClasses[0].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.WEDNESDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    GymClasses = gymClasses[1],
                    GymClassesID = gymClasses[1].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.THURSDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    GymClasses = gymClasses[3],
                    GymClassesID = gymClasses[3].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.FRIDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    GymClasses = gymClasses[1],
                    GymClassesID = gymClasses[1].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.SATURDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    GymClasses = gymClasses[4],
                    GymClassesID = gymClasses[4].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.SUNDAY,
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(18, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    GymClasses = gymClasses[2],
                    GymClassesID = gymClasses[2].GymClassesID
                }


            };


            timetable.ForEach(l => context.Timetable.Add(l));
            context.SaveChanges();





            var gymOverview = new List<GymOverview>
            {
                new GymOverview
                {
                    Header = "Default Gym",
                    Content = "dssssss",
                    Equipment = equipment,
                    GymClasses = gymClasses
                },
                new GymOverview
                {
                    Header = "Glasgow Gym",
                    Content = "gssssss",                    
                    Equipment = equipment,
                    GymClasses = gymClasses

                },
                new GymOverview
                {
                    Header = "Paris Gym",
                    Content = "ssgggssss",
                    Equipment = equipment,
                    GymClasses = gymClasses
                },
                new GymOverview
                {
                    Header = "Amsterdam Gym",
                    Content = "ssssdassss",
                    Equipment = equipment,
                    GymClasses = gymClasses
                },
                new GymOverview
                {
                    Header = "New York Gym",
                    Content = "ssaassss",
                    Equipment = equipment,
                    GymClasses = gymClasses
                },
                new GymOverview
                {
                    Header = "London Gym",
                    Content = "ssaassss",
                    Equipment = equipment,
                    GymClasses = gymClasses
                }

            };
            gymOverview.ForEach(l => context.GymOverview.Add(l));
            context.SaveChanges();

















            var locations = new List<Location>
            {
                new Location{
                    LocationName="Geronimo Hotels", 
                    LocationIntroduction="Default Data Introduction details. ",
                    RoomOverviewID = 1,
                    GymOverviewID = 1
                },
                new Location{
                    LocationName="Glasgow", 
                    LocationIntroduction="Glasgow Introduction details. Glasgow Introduction details. Glasgow Introduction details. ",
                    RoomOverviewID = 2,
                    GymOverviewID = 2

                },
                new Location{
                    LocationName="Paris", 
                    LocationIntroduction="Paris Introductions details",
                    RoomOverviewID = 3,
                    GymOverviewID = 3

                },
                new Location{
                    LocationName="Amsterdam", 
                    LocationIntroduction="Amsterdam Introduction details.",                 
                    RoomOverviewID = 4,
                    GymOverviewID = 4
                },
                new Location{
                    LocationName="New York", 
                    LocationIntroduction="New York Introduction details.",
                    RoomOverviewID = 5,
                    GymOverviewID = 5
                },
                new Location{
                    LocationName="London", 
                    LocationIntroduction="London Introduction details.",                    
                    RoomOverviewID = 6,
                    GymOverviewID = 6
}

            };
            locations.ForEach(l => context.Location.Add(l));
            context.SaveChanges();






        }
    }
}