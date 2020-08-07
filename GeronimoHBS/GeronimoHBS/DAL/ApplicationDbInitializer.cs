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







            var amenities = new List<Amenity>
            {
                new Amenity{
                    Name = "Free WiFi"
                },
                new Amenity{
                    Name = "Mini Bar"
                },
                new Amenity{
                    Name = "Coffee Maker"
                },
                new Amenity{
                    Name = "Iron & Ironing Board"
                },
                new Amenity{
                    Name = "Microwave"
                },
                new Amenity{
                    Name = "Private Balcony"
                },
                new Amenity{
                    Name = "Crib"
                },
                new Amenity{
                    Name = "TV Facilities"
                },
                new Amenity{
                    Name = "Air Conditioned"
                }

            };
            amenities.ForEach(l => context.Amenities.Add(l));
            context.SaveChanges();




            var roomStatus = new List<RoomStatus>
            {
                new RoomStatus{
                    RoomStatusName = "vacant"
                },
                new RoomStatus{
                    RoomStatusName = "occupied"
                },
                new RoomStatus{
                    RoomStatusName = "dirty"
                },
                new RoomStatus{
                    RoomStatusName = "clean"
                },
                new RoomStatus{
                    RoomStatusName = "ready"
                },
                new RoomStatus{
                    RoomStatusName = "outOfOrder"
                },
                //occupied, vacant, dirty, clean, ready and out of order.
            };
            roomStatus.ForEach(l => context.RoomStatus.Add(l));
            context.SaveChanges();











            var glasgowRooms = new List<Room>
            {
                new Room{
                    RoomNumber = 1,
                    Name = "GRoom One",
                    Description = "",
                    FloorNumber = 1,
                    NumberOfBeds = 12,
                    Price = 20.00,
                    RoomType = roomTypes[1],
                    Amenities = amenities,
                    Capacity = 4,
                    RoomStatus = roomStatus[0],
                    RoomStatusID = roomStatus[0].RoomStatusID

                },
                new Room{
                    RoomNumber = 2,
                    Name = "GRoom Two",
                    Description = "GRoom Two GRoom Two GRoom Two",
                    FloorNumber = 1,
                    NumberOfBeds = 1,
                    Price = 20.00,
                    RoomType = roomTypes[1],
                    Amenities = amenities,
                    Capacity = 4,
                    RoomStatus = roomStatus[1],
                    RoomStatusID = roomStatus[1].RoomStatusID
                },
                new Room{
                    RoomNumber = 3,
                    Name = "GRoom Three",
                    Description = "GRoom Three GRoom Three GRoom Three ",
                    FloorNumber = 1,
                    NumberOfBeds = 2,
                    Price = 20.00,
                    RoomType = roomTypes[0],
                    Amenities = amenities,
                    Capacity = 4,
                    RoomStatus = roomStatus[0],
                    RoomStatusID = roomStatus[0].RoomStatusID
                },
                new Room{
                    RoomNumber = 4,
                    Name = "GRoom Four",
                    Description = "GRoom Four GRoom Four GRoom Four",
                    FloorNumber = 2,
                    NumberOfBeds = 1,
                    Price = 20.00,
                    RoomType = roomTypes[0],
                    Amenities = amenities,
                    Capacity = 4,
                    RoomStatus = roomStatus[0],
                    RoomStatusID = roomStatus[0].RoomStatusID
                },
                new Room{
                    RoomNumber = 5,
                    Name = "GRoom Five",
                    Description = "GRoom Five GRoom Five GRoom Five",
                    FloorNumber = 2,
                    NumberOfBeds = 2,
                    Price = 50.00,
                    RoomType = roomTypes[1],
                    Amenities = amenities,
                    Capacity = 4,
                    RoomStatus = roomStatus[0],
                    RoomStatusID = roomStatus[0].RoomStatusID
                }

            };
            glasgowRooms.ForEach(l => context.Room.Add(l));
            context.SaveChanges();



            var londonRooms = new List<Room>
            {
                new Room{
                    RoomNumber = 1,
                    Name = "LRoom One",
                    Description = "",
                    FloorNumber = 1,
                    NumberOfBeds = 12,
                    Price = 60.00,
                    RoomType = roomTypes[1],
                    Amenities = amenities,
                    Capacity = 4,
                    RoomStatus = roomStatus[0],
                    RoomStatusID = roomStatus[0].RoomStatusID
                },
                new Room{
                    RoomNumber = 2,
                    Name = "LRoom Two",
                    Description = "LRoom Two LRoom Two LRoom Two",
                    FloorNumber = 1,
                    NumberOfBeds = 1,
                    Price = 20.00,
                    RoomType = roomTypes[1],
                    Amenities = amenities,
                    Capacity = 4,
                    RoomStatus = roomStatus[1],
                    RoomStatusID = roomStatus[1].RoomStatusID
                },
                new Room{
                    RoomNumber = 3,
                    Name = "LRoom Three",
                    Description = "LRoom Three LRoom Three LRoom Three ",
                    FloorNumber = 1,
                    NumberOfBeds = 2,
                    Price = 50.00,
                    RoomType = roomTypes[0],
                    Amenities = amenities,
                    Capacity = 4,
                    RoomStatus = roomStatus[0],
                    RoomStatusID = roomStatus[0].RoomStatusID
                },
                new Room{
                    RoomNumber = 4,
                    Name = "LRoom Four",
                    Description = "LRoom Four LRoom Four LRoom Four",
                    FloorNumber = 2,
                    NumberOfBeds = 1,
                    Price = 20.00,
                    RoomType = roomTypes[0],
                    Amenities = amenities,
                    Capacity = 4,
                    RoomStatus = roomStatus[0],
                    RoomStatusID = roomStatus[0].RoomStatusID
                },
                new Room{
                    RoomNumber = 5,
                    Name = "LRoom Five",
                    Description = "LRoom Five LRoom Five LRoom Five",
                    FloorNumber = 2,
                    NumberOfBeds = 2,
                    Price = 30.00,
                    RoomType = roomTypes[1],
                    Amenities = amenities,
                    Capacity = 4,
                    RoomStatus = roomStatus[0],
                    RoomStatusID = roomStatus[0].RoomStatusID
                }

            };
            londonRooms.ForEach(l => context.Room.Add(l));
            context.SaveChanges();




            var roomOverview = new List<RoomOverview>
            {
                new RoomOverview
                {
                    Header = "Geronimo Rooms",
                    IntroductionParagraph = "Regardless of the location Geronimo Hotels.  ",
                    MainContent = "Regardless of the location Geronimo Hotels has a range of rooms available to be booked. " +
                    "There are Standard rooms and premium rooms available.Regardless of the location Geronimo Hotels has a range of rooms available to be booked. " +
                    "There are Standard rooms and premium rooms available.Regardless of the location Geronimo Hotels has a range of rooms available to be booked. " +
                    "There are Standard rooms and premium rooms available.Regardless of the location Geronimo Hotels has a range of rooms available to be booked. " +
                    "There are Standard rooms and premium rooms available. ",
                    SecondaryContent = "Regardless of the location Geronimo Hotels has a range of rooms available to be booked. " +
                    "There are Standard rooms and premium rooms available.Regardless of the location Geronimo Hotels has a range of rooms available to be booked. " +
                    "There are Standard rooms and premium rooms available.Regardless of the location Geronimo Hotels has a range of rooms available to be booked. " +
                    "There are Standard rooms and premium rooms available.Regardless of the location Geronimo Hotels has a range of rooms available to be booked. " +
                    "There are Standard rooms and premium rooms available.Regardless of the location Geronimo Hotels has a range of rooms available to be booked. " +
                    "There are Standard rooms and premium rooms available.Regardless of the location Geronimo Hotels has a range of rooms available to be booked. " +
                    "There are Standard rooms and premium rooms available.Regardless of the location Geronimo Hotels has a range of rooms available to be booked. " +
                    "There are Standard rooms and premium rooms available.Regardless of the location Geronimo Hotels has a range of rooms available to be booked. " +
                    "There are Standard rooms and premium rooms available.Regardless of the location Geronimo Hotels has a range of rooms available to be booked. " +
                    "There are Standard rooms and premium rooms available.Regardless of the location Geronimo Hotels has a range of rooms available to be booked. " +
                    "There are Standard rooms and premium rooms available.",
                    RoomType = roomTypes
                },
                new RoomOverview
                {
                    Header = "Glasgow Rooms",
                    IntroductionParagraph = "",
                    MainContent = "When booking a room at the Glasgow Geronimo Hotel " +
                    "you can choose from either a standard or premium room. ",
                    SecondaryContent = "", 
                    RoomType = roomTypes
                },
                new RoomOverview
                {
                    Header = "Paris Rooms",
                    IntroductionParagraph = "When booking a room premium room. ",
                    MainContent = "When booking a room at the Paris Geronimo Hotel " +
                    "you can choose from either a standard or premium room. ",  
                    SecondaryContent = "When booking a room at the Paris Geronimo Hotel " +
                    "you can choose from either a standard or premium room. When booking a room at the Paris Geronimo Hotel " +
                    "you can choose from either a standard or premium room. ",
                    RoomType = roomTypes
                },
                new RoomOverview
                {
                    Header = "Amsterdam Rooms",
                    IntroductionParagraph = "When booking a room at the Amsterdam Geronimo Hotel",
                    MainContent = "When booking a room at the Amsterdam Geronimo Hotel " +
                    "you can choose from either a standard or premium room. " +
                    "When booking a room at the Amsterdam Geronimo Hotel " +
                    "you can choose from either a standard or premium room. ",
                    SecondaryContent = "When booking a room at the Amsterdam Geronimo HotelWhen booking a room at the Amsterdam Geronimo HotelWhen booking a room at the Amsterdam Geronimo HotelWhen booking a room at the Amsterdam Geronimo HotelWhen booking a room at the Amsterdam Geronimo HotelWhen booking a room at the Amsterdam Geronimo Hotel",
                    RoomType = roomTypes
                }, 
                new RoomOverview
                {
                    Header = "New York Rooms",
                    IntroductionParagraph = "When When booking a room at the New York New York Geronimo Hotelbooking a room at the New York New York Geronimo Hotel", 
                    MainContent = "When booking a room at the New York New York Geronimo Hotel " +
                    "you can choose from either a standard or premium room. "+
                    "When booking a room at the New York Geronimo Hotel " +
                    "you can choose from either a standard or premium room. ",
                    SecondaryContent = "When booking a room at the New York New York Geronimo Hotel " +
                    "you can choose from either a standard or premium room. "+
                    "When booking a room at the New York Geronimo HotelWhen booking a room at the New York Geronimo HotelWhen booking a room at the New York Geronimo Hotel " +
                    "you can choose from either a standard or premium room. ",
                    RoomType = roomTypes
                },
                new RoomOverview
                {
                    Header = "London Rooms", 
                    IntroductionParagraph = "", 
                    MainContent = "When booking a room at the London Geronimo Hotel " +
                    "you can choose from either a standard or premium room. "+
                    "When booking a room at the London Geronimo Hotel " +
                    "you can choose from either a standard or premium room. ",
                    RoomType = roomTypes
                },

            };
            roomOverview.ForEach(l => context.RoomOverview.Add(l));
            context.SaveChanges();





            // DEFAULTY DATA
            // Seeded Equipment - Default
            //var equipmentDefault = new List<Equipment>
            //{
            //    new Equipment
            //    {
            //        Name = "D_item1",
            //        Description = "item1 description item1 description item1 description. ",
            //        Quantity = 13
            //    },
            //    new Equipment
            //    {
            //        Name = "D_item2",
            //        Description = "item2 description item2 description item2 description. ",
            //        Quantity = 21

            //    },
            //    new Equipment
            //    {
            //        Name = "D_item3",
            //        Description = "item3 description item3 description item3 description. ",
            //        Quantity = 7

            //    }

            //};
            //equipmentDefault.ForEach(l => context.Equipment.Add(l));
            //context.SaveChanges();

            // Seeded Gym Classes - Default    
            //var gymClassesDefault = new List<GymClasses>()
            //{
            //    new GymClasses {
            //        Title ="D_Gym Class 1",
            //        Description = "Gym Class 1 description. ",

            //    },
            //    new GymClasses {
            //        Title ="D_Gym Class 2",
            //        Description = "Gym Class 2 description. "
            //    },
            //    new GymClasses {
            //        Title ="D_Gym Class 3",
            //        Description = "Gym Class 3 description. "
            //    },
            //    new GymClasses {
            //        Title ="D_Gym Class 4",
            //        Description = "Gym Class 4 description. "
            //    },
            //    new GymClasses {
            //        Title ="D_Gym Class 5",
            //        Description = "Gym Class 5 description. "
            //    },


            //};
            //gymClassesDefault.ForEach(l => context.GymClasses.Add(l));
            //context.SaveChanges();

            // Seeded Timetable - Default
            //var timetableDefault = new List<Timetable>
            //{
            //    // MONDAY
            //    new Timetable()
            //    {
            //        Day = Day.MONDAY,
            //        StartTime = new TimeSpan(7, 0, 0),
            //        EndTime = new TimeSpan(12, 0, 0),
            //        GymClassStatus = GymClassStatus.FULLYBOOKED,
            //        Instructor = "Tim Timothy",
            //        GymClasses = gymClassesDefault[0],
            //        GymClassesID = gymClassesDefault[0].GymClassesID
            //    },
            //    new Timetable()
            //    {
            //        Day = Day.TUESDAY,
            //        StartTime = new TimeSpan(8, 0, 0),
            //        EndTime = new TimeSpan(10, 0, 0),
            //        GymClassStatus = GymClassStatus.AVAILABLE,
            //        Instructor = "Tim Timothy",
            //        GymClasses = gymClassesDefault[0],
            //        GymClassesID = gymClassesDefault[0].GymClassesID
            //    },
            //    new Timetable()
            //    {
            //        Day = Day.WEDNESDAY,
            //        StartTime = new TimeSpan(7, 0, 0),
            //        EndTime = new TimeSpan(12, 0, 0),
            //        GymClassStatus = GymClassStatus.AVAILABLE,
            //        Instructor = "Tim Timothy",
            //        GymClasses = gymClassesDefault[1],
            //        GymClassesID = gymClassesDefault[1].GymClassesID
            //    },
            //    new Timetable()
            //    {
            //        Day = Day.THURSDAY,
            //        StartTime = new TimeSpan(7, 0, 0),
            //        EndTime = new TimeSpan(12, 0, 0),
            //        GymClassStatus = GymClassStatus.CANCELLED,
            //        Instructor = "Tim Timothy",
            //        GymClasses = gymClassesDefault[3],
            //        GymClassesID = gymClassesDefault[3].GymClassesID
            //    },
            //    new Timetable()
            //    {
            //        Day = Day.FRIDAY,
            //        StartTime = new TimeSpan(7, 0, 0),
            //        EndTime = new TimeSpan(12, 0, 0),
            //        GymClassStatus = GymClassStatus.AVAILABLE,
            //        Instructor = "Tim Timothy",
            //        GymClasses = gymClassesDefault[1],
            //        GymClassesID = gymClassesDefault[1].GymClassesID
            //    },
            //    new Timetable()
            //    {
            //        Day = Day.SATURDAY,
            //        StartTime = new TimeSpan(7, 0, 0),
            //        EndTime = new TimeSpan(12, 0, 0),
            //        GymClassStatus = GymClassStatus.AVAILABLE,
            //        Instructor = "Tim Timothy",
            //        GymClasses = gymClassesDefault[4],
            //        GymClassesID = gymClassesDefault[4].GymClassesID
            //    },
            //    new Timetable()
            //    {
            //        Day = Day.SUNDAY,
            //        StartTime = new TimeSpan(14, 0, 0),
            //        EndTime = new TimeSpan(18, 0, 0),
            //        GymClassStatus = GymClassStatus.AVAILABLE,
            //        Instructor = "Tim Timothy",
            //        GymClasses = gymClassesDefault[2],
            //        GymClassesID = gymClassesDefault[2].GymClassesID
            //    }
            //};
            //timetableDefault.ForEach(l => context.Timetable.Add(l));
            //context.SaveChanges();


            // FLEXIBILITY, MOBILITY, MUSCULARENDURANCE, MUSCULARSTRENGTH, CARDIOVASCULARENDURANCE, BODYCOMPOSITION

            // GLASGOW DATA
            // Seeded Equipment - Glasgow
            var classFocus = new List<ClassFocus>
            {
                new ClassFocus
                {
                    Title = "FLEXIBILITY",
                    DisplayTitle = "Flexibility"
                },
                new ClassFocus
                {
                    Title = "MOBILITY",
                    DisplayTitle = "Mobility"

                },new ClassFocus
                {
                    Title = "MUSCULARENDURANCE",
                    DisplayTitle = "Muscular Endurance"
                },
                 new ClassFocus
                {
                    Title = "MUSCULARSTRENGTH",
                    DisplayTitle = "Muscular Strength"
                },
                new ClassFocus
                {
                    Title = "CARDIOVASCULARENDURANCE",
                    DisplayTitle = "Cardiovascular Endurance"

                },
                new ClassFocus
                {
                    Title = "BODYCOMPOSITION",
                    DisplayTitle = "Body Composition"
                },

            };
            classFocus.ForEach(l => context.ClassFocus.Add(l));
            context.SaveChanges();





            // GLASGOW DATA
            // Seeded Equipment - Glasgow
            var equipmentGlasgow = new List<Equipment>
            {
                new Equipment
                {
                    Name = "Glasgow Gym Item 1",
                    Description = "Glasgow Gym Item 1 description item1 description item1 description. Glasgow Gym Item 1 description item1 description item1 description. ",
                    Quantity = 13
                },
                new Equipment
                {
                    Name = "Glasgow Gym Item 2",
                    Description = "item2 description item2 description item2 description. ",
                    Quantity = 21

                },new Equipment
                {
                    Name = "Glasgow Gym Item 3",
                    Description = "item3 description item3 description item3 description. ",
                    Quantity = 7

                }

            };
            equipmentGlasgow.ForEach(l => context.Equipment.Add(l));
            context.SaveChanges();

            // Seeded Gym Classes - Glasgow    
            var gymClassesGlasgow = new List<GymClasses>()
            {
                new GymClasses {
                    Title ="HIIT the Floor",
                    Introduction = "HIIT the Floor introduction. Gym Class 1 introduction. Gym Class 1 introduction. " +
                    "Gym Class 1 introduction. Gym Class 1 introduction. Gym Class 1 introduction. ",
                    Description = "Gym Class 1 description. Gym Class 1 description. Gym Class 1 description. Gym Class 1 description. Gym Class 1 description. Gym Class 1 description. Gym Class 1 description. Gym Class 1 description. Gym Class 1 description. Gym Class 1 description. Gym Class 1 description. Gym Class 1 description. ",
                    Focus = new List<ClassFocus>
                    {
                        classFocus[0],
                        classFocus[1]
                    },
                    Benefits = "A1 lengthy descro=iption of the benefits of attending this class. " +
                    "A lengthy descro=iption of the benefits of attending this class. " +
                    "A lengthy descro=iption of the benefits of attending this class. "


                },
                new GymClasses {
                    Title ="G_Gym Class 2", 
                    Introduction = "Gym Class 2 introduction. Gym Class 1 introduction. Gym Class 1 introduction. " +
                    "Gym Class 1 introduction. Gym Class 1 introduction. Gym Class 1 introduction. ",
                    Description = "Gym Class 2 description. ",
                    Focus = new List<ClassFocus>
                    {
                        classFocus[2],
                        classFocus[3]
                    }, 
                    Benefits = "A2 lengthy descro=iption of the benefits of attending this class. " +
                    "A lengthy descro=iption of the benefits of attending this class. " +
                    "A lengthy descro=iption of the benefits of attending this class. "
                },
                new GymClasses {
                    Title ="G_Gym Class 3",
                    Description = "Gym Class 3 description. ",
                     Introduction = "Gym Class 3 introduction. Gym Class 1 introduction. Gym Class 1 introduction. " +
                    "Gym Class 1 introduction. Gym Class 1 introduction. Gym Class 1 introduction. ",
                    Focus = new List<ClassFocus>
                    {
                        classFocus[4],
                        classFocus[5]
                    },
                    Benefits = "A3 lengthy descro=iption of the benefits of attending this class. " +
                    "A lengthy descro=iption of the benefits of attending this class. " +
                    "A lengthy descro=iption of the benefits of attending this class. "

                },
                new GymClasses {
                    Title ="G_Gym Class 4",
                     Introduction = "Gym Class 4 introduction. Gym Class 1 introduction. Gym Class 1 introduction. " +
                    "Gym Class 1 introduction. Gym Class 1 introduction. Gym Class 1 introduction. ",
                    Description = "Gym Class 4 description. ",
                    Focus = new List<ClassFocus>
                    {
                        classFocus[0],
                        classFocus[2]
                    },
                    Benefits = "A4 lengthy descro=iption of the benefits of attending this class. " +
                    "A lengthy descro=iption of the benefits of attending this class. " +
                    "A lengthy descro=iption of the benefits of attending this class. "

                },
                new GymClasses {
                    Title ="G_Gym Class 5",
                    Introduction = "Gym Class 5 introduction. Gym Class 1 introduction. Gym Class 1 introduction. " +
                    "Gym Class 1 introduction. Gym Class 1 introduction. Gym Class 1 introduction. ",
                    Description = "Gym Class 5 description. ",
                    Focus = new List<ClassFocus>
                    {
                        classFocus[0],
                        classFocus[1],
                        classFocus[3]
                    },
                    Benefits = "A5 lengthy descro=iption of the benefits of attending this class. " +
                    "A lengthy descro=iption of the benefits of attending this class. " +
                    "A lengthy descro=iption of the benefits of attending this class. "

                },


            };
            gymClassesGlasgow.ForEach(l => context.GymClasses.Add(l));
            context.SaveChanges();

            // Seeded Timetable - Glasgow
            var timetableGlasgow = new List<Timetable>
            {
                // MONDAY
                new Timetable()
                {
                    Day = Day.MONDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.FULLYBOOKED,
                    Instructor = "G_Tim Timothy",
                    GymClasses = gymClassesGlasgow[0],
                    GymClassesID = gymClassesGlasgow[0].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.MONDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.FULLYBOOKED,
                    Instructor = "G_Tim Timothy",
                    GymClasses = gymClassesGlasgow[0],
                    GymClassesID = gymClassesGlasgow[0].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.MONDAY,
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    GymClassStatus = GymClassStatus.FULLYBOOKED,
                    Instructor = "G_Tim Timothy",
                    GymClasses = gymClassesGlasgow[0],
                    GymClassesID = gymClassesGlasgow[0].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.MONDAY,
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(11, 0, 0),
                    GymClassStatus = GymClassStatus.FULLYBOOKED,
                    Instructor = "G_Tim Timothy",
                    GymClasses = gymClassesGlasgow[1],
                    GymClassesID = gymClassesGlasgow[1].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.MONDAY,
                    StartTime = new TimeSpan(17, 0, 0),
                    EndTime = new TimeSpan(19, 0, 0),
                    GymClassStatus = GymClassStatus.FULLYBOOKED,
                    Instructor = "G_Tim Timothy",
                    GymClasses = gymClassesGlasgow[2],
                    GymClassesID = gymClassesGlasgow[2].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.TUESDAY,
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(10, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "G_Tim Timothy",
                    GymClasses = gymClassesGlasgow[0],
                    GymClassesID = gymClassesGlasgow[0].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.WEDNESDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "G_Tim Timothy",
                    GymClasses = gymClassesGlasgow[1],
                    GymClassesID = gymClassesGlasgow[1].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.THURSDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.CANCELLED,
                    Instructor = "G_Tim Timothy",
                    GymClasses = gymClassesGlasgow[3],
                    GymClassesID = gymClassesGlasgow[3].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.FRIDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "G_Tim Timothy",
                    GymClasses = gymClassesGlasgow[1],
                    GymClassesID = gymClassesGlasgow[1].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.SATURDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "G_Tim Timothy",
                    GymClasses = gymClassesGlasgow[4],
                    GymClassesID = gymClassesGlasgow[4].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.SUNDAY,
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(18, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "G_Tim Timothy",
                    GymClasses = gymClassesGlasgow[2],
                    GymClassesID = gymClassesGlasgow[2].GymClassesID
                }
            };
            timetableGlasgow.ForEach(l => context.Timetable.Add(l));
            context.SaveChanges();



            // PARIS DATA
            // Seeded Equipment - Paris
            var equipmentParis = new List<Equipment>
            {
                new Equipment
                {
                    Name = "P_item1",
                    Description = "item1 description item1 description item1 description. ",
                    Quantity = 13
                },
                new Equipment
                {
                    Name = "P_item2",
                    Description = "item2 description item2 description item2 description. ",
                    Quantity = 21

                },new Equipment
                {
                    Name = "P_item3",
                    Description = "item3 description item3 description item3 description. ",
                    Quantity = 7

                }

            };
            equipmentParis.ForEach(l => context.Equipment.Add(l));
            context.SaveChanges();


            // Seeded Gym Classes - Paris    
            var gymClassesParis = new List<GymClasses>()
            {
                new GymClasses {
                    Title ="P_Gym Class 1",
                    Description = "Gym Class 1 description. Gym Class 1 description. Gym Class 1 description. Gym Class 1 description. ",

                },
                new GymClasses {
                    Title ="P_Gym Class 2",
                    Description = "Gym Class 2 description. Gym Class 2 description. Gym Class 2 description. "
                },
                new GymClasses {
                    Title ="Gym Class 3",
                    Description = "Gym Class 3 description. "
                },
                new GymClasses {
                    Title ="P_Gym Class 4",
                    Description = "Gym Class 4 description. "
                },
                new GymClasses {
                    Title ="P_Gym Class 5",
                    Description = "Gym Class 5 description. "
                },


            };
            gymClassesParis.ForEach(l => context.GymClasses.Add(l));
            context.SaveChanges();

            // Seeded Timetable - Paris
            var timetableParis = new List<Timetable>
            {
                // MONDAY
                new Timetable()
                {
                    Day = Day.MONDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.FULLYBOOKED,
                    Instructor = "P_Tim Timothy",
                    GymClasses = gymClassesParis[0],
                    GymClassesID = gymClassesParis[0].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.TUESDAY,
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(10, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "P_Tim Timothy",
                    GymClasses = gymClassesParis[0],
                    GymClassesID = gymClassesParis[0].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.WEDNESDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "P_Tim Timothy",
                    GymClasses = gymClassesParis[1],
                    GymClassesID = gymClassesParis[1].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.THURSDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.CANCELLED,
                    Instructor = "P_Tim Timothy",
                    GymClasses = gymClassesParis[3],
                    GymClassesID = gymClassesParis[3].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.FRIDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "P_Tim Timothy",
                    GymClasses = gymClassesParis[1],
                    GymClassesID = gymClassesParis[1].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.SATURDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "P_Tim Timothy",
                    GymClasses = gymClassesParis[4],
                    GymClassesID = gymClassesParis[4].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.SUNDAY,
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(18, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "P_Tim Timothy",
                    GymClasses = gymClassesParis[2],
                    GymClassesID = gymClassesParis[2].GymClassesID
                }
            };
            timetableParis.ForEach(l => context.Timetable.Add(l));
            context.SaveChanges();



            // AMSTERDAM DATA
            // Seeded Equipment - Amsterdam
            var equipmentAmsterdam = new List<Equipment>
            {
                new Equipment
                {
                    Name = "A_item1",
                    Description = "item1 description item1 description item1 description. ",
                    Quantity = 13
                },
                new Equipment
                {
                    Name = "A_item2",
                    Description = "item2 description item2 description item2 description. ",
                    Quantity = 21

                },new Equipment
                {
                    Name = "A_item3",
                    Description = "item3 description item3 description item3 description. ",
                    Quantity = 7

                }

            };
            equipmentAmsterdam.ForEach(l => context.Equipment.Add(l));
            context.SaveChanges();

            // Seeded Gym Classes - Amsterdam    
            var gymClassesAmsterdam = new List<GymClasses>()
            {
                new GymClasses {
                    Title ="A_Gym Class 1",
                    Description = "Gym Class 1 description. ",

                },
                new GymClasses {
                    Title ="A_Gym Class 2",
                    Description = "Gym Class 2 description. "
                },
                new GymClasses {
                    Title ="A_Gym Class 3",
                    Description = "Gym Class 3 description. "
                },
                new GymClasses {
                    Title ="A_Gym Class 4",
                    Description = "Gym Class 4 description. "
                },
                new GymClasses {
                    Title ="A_Gym Class 5",
                    Description = "Gym Class 5 description. "
                },


            };
            gymClassesAmsterdam.ForEach(l => context.GymClasses.Add(l));
            context.SaveChanges();

            // Seeded Timetable - Amsterdam
            var timetableAmsterdam = new List<Timetable>
            {
                // MONDAY
                new Timetable()
                {
                    Day = Day.MONDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.FULLYBOOKED,
                    Instructor = "A_Tim Timothy",
                    GymClasses = gymClassesAmsterdam[0],
                    GymClassesID = gymClassesAmsterdam[0].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.TUESDAY,
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(10, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "A_Tim Timothy",
                    GymClasses = gymClassesAmsterdam[0],
                    GymClassesID = gymClassesAmsterdam[0].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.WEDNESDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "A_Tim Timothy",
                    GymClasses = gymClassesAmsterdam[1],
                    GymClassesID = gymClassesAmsterdam[1].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.THURSDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.CANCELLED,
                    Instructor = "A_Tim Timothy",
                    GymClasses = gymClassesAmsterdam[3],
                    GymClassesID = gymClassesAmsterdam[3].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.FRIDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "A_Tim Timothy",
                    GymClasses = gymClassesAmsterdam[1],
                    GymClassesID = gymClassesAmsterdam[1].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.SATURDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "A_Tim Timothy",
                    GymClasses = gymClassesAmsterdam[4],
                    GymClassesID = gymClassesAmsterdam[4].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.SUNDAY,
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(18, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "A_Tim Timothy",
                    GymClasses = gymClassesAmsterdam[2],
                    GymClassesID = gymClassesAmsterdam[2].GymClassesID
                }
            };
            timetableAmsterdam.ForEach(l => context.Timetable.Add(l));
            context.SaveChanges();



            // NEW YORK DATA
            // Seeded Equipment - NewYork
            var equipmentNewYork = new List<Equipment>
            {
                new Equipment
                {
                    Name = "NY_item1",
                    Description = "item1 description item1 description item1 description. ",
                    Quantity = 13
                },
                new Equipment
                {
                    Name = "NY_item2",
                    Description = "item2 description item2 description item2 description. ",
                    Quantity = 21

                },new Equipment
                {
                    Name = "NY_item3",
                    Description = "item3 description item3 description item3 description. ",
                    Quantity = 7

                }

            };
            equipmentNewYork.ForEach(l => context.Equipment.Add(l));
            context.SaveChanges();

            // Seeded Gym Classes - NewYork    
            var gymClassesNewYork = new List<GymClasses>()
            {
                new GymClasses {
                    Title ="NY_Gym Class 1",
                    Description = "Gym Class 1 description. ",

                },
                new GymClasses {
                    Title ="NY_Gym Class 2",
                    Description = "Gym Class 2 description. "
                },
                new GymClasses {
                    Title ="NY_Gym Class 3",
                    Description = "Gym Class 3 description. "
                },
                new GymClasses {
                    Title ="NY_Gym Class 4",
                    Description = "Gym Class 4 description. "
                },
                new GymClasses {
                    Title ="NY_Gym Class 5",
                    Description = "Gym Class 5 description. "
                },


            };
            gymClassesNewYork.ForEach(l => context.GymClasses.Add(l));
            context.SaveChanges();

            // Seeded Timetable - NewYork
            var timetableNewYork = new List<Timetable>
            {
                // MONDAY
                new Timetable()
                {
                    Day = Day.MONDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.FULLYBOOKED,
                    Instructor = "NY_Tim Timothy",
                    GymClasses = gymClassesNewYork[0],
                    GymClassesID = gymClassesNewYork[0].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.TUESDAY,
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(10, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "NY_Tim Timothy",
                    GymClasses = gymClassesNewYork[0],
                    GymClassesID = gymClassesNewYork[0].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.WEDNESDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "NY_Tim Timothy",
                    GymClasses = gymClassesNewYork[1],
                    GymClassesID = gymClassesNewYork[1].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.THURSDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.CANCELLED,
                    Instructor = "NY_Tim Timothy",
                    GymClasses = gymClassesNewYork[3],
                    GymClassesID = gymClassesNewYork[3].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.FRIDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "NY_Tim Timothy",
                    GymClasses = gymClassesNewYork[1],
                    GymClassesID = gymClassesNewYork[1].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.SATURDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "NY_Tim Timothy",
                    GymClasses = gymClassesNewYork[4],
                    GymClassesID = gymClassesNewYork[4].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.SUNDAY,
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(18, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "NY_Tim Timothy",
                    GymClasses = gymClassesNewYork[2],
                    GymClassesID = gymClassesNewYork[2].GymClassesID
                }
            };
            timetableNewYork.ForEach(l => context.Timetable.Add(l));
            context.SaveChanges();



            // LONDON DATA
            // Seeded Equipment - London
            var equipmentLondon = new List<Equipment>
            {
                new Equipment
                {
                    Name = "L_item1",
                    Description = "item1 description item1 description item1 description. ",
                    Quantity = 13
                },
                new Equipment
                {
                    Name = "L_item2",
                    Description = "item2 description item2 description item2 description. ",
                    Quantity = 21

                },new Equipment
                {
                    Name = "L_item3",
                    Description = "item3 description item3 description item3 description. ",
                    Quantity = 7

                }

            };
            equipmentLondon.ForEach(l => context.Equipment.Add(l));
            context.SaveChanges();

            // Seeded Gym Classes - London    
            var gymClassesLondon = new List<GymClasses>()
            {
                new GymClasses {
                    Title ="L_Gym Class 1",
                    Description = "Gym Class 1 description. ",

                },
                new GymClasses {
                    Title ="L_Gym Class 2",
                    Description = "Gym Class 2 description. "
                },
                new GymClasses {
                    Title ="L_Gym Class 3",
                    Description = "Gym Class 3 description. "
                },
                new GymClasses {
                    Title ="L_Gym Class 4",
                    Description = "Gym Class 4 description. "
                },
                new GymClasses {
                    Title ="L_Gym Class 5",
                    Description = "Gym Class 5 description. "
                },


            };
            gymClassesLondon.ForEach(l => context.GymClasses.Add(l));
            context.SaveChanges();

            // Seeded Timetable - London
            var timetableLondon = new List<Timetable>
            {
                // MONDAY
                new Timetable()
                {
                    Day = Day.MONDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.FULLYBOOKED,
                    Instructor = "L_Tim Timothy",
                    GymClasses = gymClassesLondon[0],
                    GymClassesID = gymClassesLondon[0].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.TUESDAY,
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(10, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "L_Tim Timothy",
                    GymClasses = gymClassesLondon[0],
                    GymClassesID = gymClassesLondon[0].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.WEDNESDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "L_Tim Timothy",
                    GymClasses = gymClassesLondon[1],
                    GymClassesID = gymClassesLondon[1].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.THURSDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.CANCELLED,
                    Instructor = "L_Tim Timothy",
                    GymClasses = gymClassesLondon[3],
                    GymClassesID = gymClassesLondon[3].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.FRIDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "L_Tim Timothy",
                    GymClasses = gymClassesLondon[1],
                    GymClassesID = gymClassesLondon[1].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.SATURDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "L_Tim Timothy",
                    GymClasses = gymClassesLondon[4],
                    GymClassesID = gymClassesLondon[4].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.SUNDAY,
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(18, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "Tim Timothy",
                    GymClasses = gymClassesLondon[2],
                    GymClassesID = gymClassesLondon[2].GymClassesID
                }
            };
            timetableLondon.ForEach(l => context.Timetable.Add(l));
            context.SaveChanges();




            // Seeding GymOverview data for each hotel instance
            var gymOverview = new List<GymOverview>
            {
                new GymOverview
                {
                    GymOverviewID = 1,
                    Header = "Geronimo Gym",
                    Content = "All Geronimo Hotels sports a fantabulous gym, equipped with  the lastest and greatest gym equipment. " +
                    "All Geronimo Hotels sports a fantabulous gym, equipped with  the lastest and greatest gym equipment. ",
                    // Equipment = equipmentDefault,
                    // GymClasses = gymClassesDefault,
                    // Timetable = timetableDefault
                },
                new GymOverview
                {
                    GymOverviewID = 2,
                    Header = "Glasgow Gym",
                    Content = "Geronimo Hotels - Glasgow sports a fantabulous gym with the lastest and greatest gym equipment. ",
                    Equipment = equipmentGlasgow,
                    GymClasses = gymClassesGlasgow,
                    Timetable = timetableGlasgow

                },
                new GymOverview
                {                    
                    GymOverviewID = 3,
                    Header = "Paris Gym",
                    Content = "Geronimo Hotels - Glasgow sports a fantabulous gym with the lastest and greatest gym equipment. ",
                    Equipment = equipmentParis,
                    GymClasses = gymClassesParis,
                    Timetable = timetableParis
                },
                new GymOverview
                {
                    GymOverviewID = 4,
                    Header = "Amsterdam Gym",
                    Content = "Geronimo Hotels - Amsterdam sports a fantabulous gym with the lastest and greatest gym equipment. ",
                    Equipment = equipmentAmsterdam,
                    GymClasses = gymClassesAmsterdam,
                    Timetable = timetableAmsterdam
                },
                new GymOverview
                {
                    GymOverviewID = 5,
                    Header = "New York Gym",
                    Content = "Geronimo Hotels - New York sports a fantabulous gym with the lastest and greatest gym equipment. ",
                    Equipment = equipmentNewYork,
                    GymClasses = gymClassesNewYork,
                    Timetable = timetableNewYork
                },
                new GymOverview
                {
                    GymOverviewID = 6,
                    Header = "London Gym",
                    Content = "Geronimo Hotels - London sports a fantabulous gym with the lastest and greatest gym equipment. ",
                    Equipment = equipmentLondon,
                    GymClasses = gymClassesLondon,
                    Timetable = timetableLondon
                }

            };
            gymOverview.ForEach(l => context.GymOverview.Add(l));
            context.SaveChanges();
































            // SPA DATA
            // Seeded Promotion Categories
            var promotionCategories = new List<PromotionCategory>
            {
                new PromotionCategory
                {
                    PromotionName = "Coupon Promotion"
                },
                new PromotionCategory
                {
                    PromotionName = "Loyalty Promotion"
                },
                new PromotionCategory
                {
                    PromotionName = "Marketing Promotion"
                }


            };
            promotionCategories.ForEach(l => context.PromotionCategory.Add(l));
            context.SaveChanges();


            // Seeded Spa Promotions - Using PromotionCategories above    
            var spaPromotions = new List<SpaPromotion>()
            {
                new SpaPromotion {
                    Title ="Spa Promotion 1",
                    Description = "Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. Spa Promotion 1 description. ",
                    StartDate = new DateTime(2020, 9, 21),
                    EndDate = new DateTime(2020, 10, 21),
                    PromotionCategoryID = 1,
                    PromotionCategory = promotionCategories[0]
                    
                },
                new SpaPromotion {
                    Title ="Spa Promotion 2",
                    Description = "Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. Spa Promotion 2 description. ",
                    StartDate = new DateTime(2020, 9, 21),
                    EndDate = new DateTime(2020, 10, 21),
                    PromotionCategoryID = 2,
                    PromotionCategory = promotionCategories[1]

                },
                new SpaPromotion {
                    Title ="Spa Promotion 3",
                    Description = "Spa Promotion 3 description. Spa Promotion 3 description. Spa Promotion 3 description. Spa Promotion 3 description. Spa Promotion 3 description. Spa Promotion 3 description. Spa Promotion 3 description. Spa Promotion 3 description. Spa Promotion 3 description. Spa Promotion 3 description. Spa Promotion 3 description. Spa Promotion 3 description. Spa Promotion 3 description. Spa Promotion 3 description. Spa Promotion 3 description. Spa Promotion 3 description. Spa Promotion 3 description. Spa Promotion 3 description. Spa Promotion 3 description. Spa Promotion 3 description. ",
                    StartDate = new DateTime(2020, 9, 21),
                    EndDate = new DateTime(2020, 10, 21),
                    PromotionCategoryID = 2,
                    PromotionCategory = promotionCategories[1]
                },
                new SpaPromotion {
                    Title ="Spa Promotion 4",
                    Description = "Spa Promotion 4 description. Spa Promotion 4 description. Spa Promotion 4 description. Spa Promotion 4 description. Spa Promotion 4 description. Spa Promotion 4 description. Spa Promotion 4 description. Spa Promotion 4 description. Spa Promotion 4 description. Spa Promotion 4 description. Spa Promotion 4 description. Spa Promotion 4 description. Spa Promotion 4 description. ",
                    StartDate = new DateTime(2020, 9, 21),
                    EndDate = new DateTime(2021, 10, 21),
                    PromotionCategoryID = 3,
                    PromotionCategory = promotionCategories[2]
                },
                new SpaPromotion {
                    Title ="Spa Promotion 5",
                    Description = "Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. Spa Promotion 5 description. ",
                    StartDate = new DateTime(2020, 7, 10),
                    EndDate = new DateTime(2020, 11, 1),
                    PromotionCategoryID = 1,
                    PromotionCategory = promotionCategories[0]
                },


            };
            spaPromotions.ForEach(l => context.SpaPromotion.Add(l));
            context.SaveChanges();

        
            // Seeding SpaOverview data for each hotel instance
            var spaOverview = new List<SpaOverview>
            {
                new SpaOverview
                {
                    SpaOverviewID = 1,
                    Header = "Geronimo Spa",
                    MainContent = "All Geronimo Hotels sports a fantabulous spa, equipped with  the lastest and greatest gym equipment. " +
                    "All Geronimo Hotels sports a fantabulous spa, equipped with  the lastest and greatest gym equipment. ",
                    // Equipment = equipmentDefault,
                    // GymClasses = gymClassesDefault,
                    // Timetable = timetableDefault
                },
                new SpaOverview
                {
                    SpaOverviewID = 2,
                    Header = "Glasgow Spa",
                    IntroductionParagraph = "Glasgow Spa - basic overview of location's spa. Glasgow Spa - basic overview of location's spa. ",
                    MainContent = "Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. " +
                    "Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. " +
                    "Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. ",
                    SecondaryContent = "Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. " +
                    "Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. " +
                    "Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. ",
                    SpaPromotions = spaPromotions
                },
                new SpaOverview
                {
                    SpaOverviewID = 3,
                    Header = "Paris Spa",
                    IntroductionParagraph = "Paris Spa - basic overview of location's spa. ",
                    MainContent = "Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. ",
                    SecondaryContent = "Geronimo Hotels - Glasgow sports a fantabulous Spa with the lastest and greatest Spa equipment. ",
                    SpaPromotions = spaPromotions
                },
                new SpaOverview
                {
                    SpaOverviewID = 4,
                    Header = "Amsterdam Spa",
                    IntroductionParagraph = "Amsterdam Spa - basic overview of location's spa. ",
                    MainContent = "Geronimo Hotels - Amsterdam sports a fantabulous Spa with the lastest and greatest Spa equipment. ",
                    SecondaryContent = "Geronimo Hotels - Amsterdam sports a fantabulous Spa with the lastest and greatest Spa equipment. ",
                    SpaPromotions = spaPromotions
                },
                new SpaOverview
                {
                    SpaOverviewID = 5,
                    Header = "New York Spa",
                    IntroductionParagraph = "New York Spa - basic overview of location's spa. ",
                    MainContent = "Geronimo Hotels - New York sports a fantabulous Spa with the lastest and greatest Spa equipment. ",
                    SecondaryContent = "Geronimo Hotels - New York sports a fantabulous Spa with the lastest and greatest Spa equipment. ",
                    SpaPromotions = spaPromotions
                },
                new SpaOverview
                {
                    SpaOverviewID = 6,
                    Header = "London Spa",
                    IntroductionParagraph = "London Spa - basic overview of location's spa. ",
                    MainContent = "Geronimo Hotels - London sports a fantabulous Spa with the lastest and greatest Spa equipment. ",
                    SecondaryContent = "Geronimo Hotels - London sports a fantabulous Spa with the lastest and greatest Spa equipment. ",
                    SpaPromotions = spaPromotions
                }

            };
            spaOverview.ForEach(l => context.SpaOverview.Add(l));
            context.SaveChanges();












            // EVENTS DATA
            // Seeded EventsStatus  
            var eventsStatus = new List<EventStatus>
            {
                new EventStatus
                {
                    EventStatusName = "Requested"
                },
                new EventStatus
                {
                    EventStatusName = "On-hold"
                },
                new EventStatus
                {
                    EventStatusName = "Booked"
                },
                new EventStatus
                {
                    EventStatusName = "Registered"
                }


            };
            eventsStatus.ForEach(l => context.EventsStatus.Add(l));
            context.SaveChanges();



            // Seeded VenueStatus     
            var venueStatus = new List<VenueStatus>()
            {
                new VenueStatus {
                    VenueStatusName = "Unavailable"
                },
                new VenueStatus {
                    VenueStatusName = "Available"
                }
            };
            venueStatus.ForEach(l => context.VenuesStatus.Add(l));
            context.SaveChanges();



            // Seeded Venues     
            var venues = new List<Venue>()
            {
                new Venue {
                    VenueName = "Hall A",
                    VenueCapacity = 150,
                    RateForDay = 200.00,
                    VenueStatusID = 1
                },
                new Venue {
                    VenueName = "Hall B",
                    VenueCapacity = 250,
                    RateForDay = 300.00,
                    VenueStatusID = 1                }
            };
            venues.ForEach(l => context.Venues.Add(l));
            context.SaveChanges();


            // Seeded Events     
            var events = new List<Event>()
            {
                new Event {
                    EventName = "BDay Party 2020!!",
                    StartDate = new DateTime(2020, 9, 29),
                    EndDate = new DateTime(2020, 9, 29),
                    AmountPaid = 0.00,
                    CalculatedCost = 350.00,
                    PublicEvent = false,
                    ExtraCost = 0.00,
                    NoOfParticipants = 100,
                    VenueID = venues[0].VenueID,
                    Venue = venues[0],
                    EventStatusID = 1,
                    EventStatus = eventsStatus[0]
                },
                new Event {
                    EventName = "Man-Droid Conference",
                    StartDate = new DateTime(2020, 9, 29),
                    EndDate = new DateTime(2020, 9, 29),
                    AmountPaid = 0.00,
                    CalculatedCost = 350.00,
                    PublicEvent = false,
                    ExtraCost = 0.00,
                    NoOfParticipants = 100,
                    VenueID = venues[0].VenueID,
                    Venue = venues[0],
                    EventStatusID = 1,
                    EventStatus = eventsStatus[0]
                },
                new Event {
                    EventName = "Wedding 2020",
                    StartDate = new DateTime(2020, 9, 29),
                    EndDate = new DateTime(2020, 9, 29),
                    AmountPaid = 0.00,
                    CalculatedCost = 350.00,
                    PublicEvent = false,
                    ExtraCost = 0.00,
                    NoOfParticipants = 100,
                    VenueID = venues[0].VenueID,
                    Venue = venues[0],
                    EventStatusID = 1,
                    EventStatus = eventsStatus[0]
                },

            };
            events.ForEach(l => context.Events.Add(l));
            context.SaveChanges();



            // Seeding EventOverview data for each hotel instance
            var eventOverview = new List<EventOverview>
            {
                new EventOverview
                {
                    EventOverviewID = 1,
                    Header = "Geronimo Events",
                    MainContent = "All Geronimo Hotels sports a fantabulous Events, equipped with  the lastest and greatest gym equipment. " +
                    "All Geronimo Hotels sports a fantabulous Events, equipped with  the lastest and greatest gym equipment. ",
                    // Menus = menus,
                    // GymClasses = gymClassesDefault,
                    // Timetable = timetableDefault
                },
                new EventOverview
                {
                    EventOverviewID = 2,
                    Header = "Glasgow Events ",
                    IntroductionParagraph = "Glasgow Events - basic overview of location's Events. Glasgow Events - basic overview of location's Events. ",
                    MainContent = "Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. " +
                    "Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. " +
                    "Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. ",
                    SecondaryContent = "Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. " +
                    "Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. " +
                    "Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. ",
                    Events = events
                    
                },
                new EventOverview
                {
                    EventOverviewID = 3,
                    Header = "Paris Events",
                    IntroductionParagraph = "Paris Events - basic overview of location's Events. ",
                    MainContent = "Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. ",
                    SecondaryContent = "Geronimo Hotels - Glasgow sports a fantabulous Events with the lastest and greatest Events equipment. ",
                    Events = events
                },
                new EventOverview
                {
                    EventOverviewID = 4,
                    Header = "Amsterdam Events",
                    IntroductionParagraph = "Amsterdam Events - basic overview of location's Events. ",
                    MainContent = "Geronimo Hotels - Amsterdam sports a fantabulous Events with the lastest and greatest Events equipment. ",
                    SecondaryContent = "Geronimo Hotels - Amsterdam sports a fantabulous Events with the lastest and greatest Events equipment. ",
                    Events = events
                },
                new EventOverview
                {
                    EventOverviewID = 5,
                    Header = "New York Events",
                    IntroductionParagraph = "New York Events - basic overview of location's Events. ",
                    MainContent = "Geronimo Hotels - New York sports a fantabulous Events with the lastest and greatest Events equipment. ",
                    SecondaryContent = "Geronimo Hotels - New York sports a fantabulous Events with the lastest and greatest Events equipment. " ,
                    Events = events
                },
                new EventOverview
                {
                    EventOverviewID = 6,
                    Header = "London Events",
                    IntroductionParagraph = "London Events - basic overview of location's Events. ",
                    MainContent = "Geronimo Hotels - London sports a fantabulous Events with the lastest and greatest Events equipment. ",
                    SecondaryContent = "Geronimo Hotels - London sports a fantabulous Events with the lastest and greatest Events equipment. ",
                    Events = events
                }

            };

            eventOverview.ForEach(l => context.EventOverview.Add(l));
            context.SaveChanges();

















            // DINING DATA
            // Seeded Menu Items 
            var menuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    MenuItemName = "Salmon w/ Ayrshire Potatoes",
                    MenuItemDescription = "Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. ",
                    MenuItemCost = 20,
                    MealType = MealType.MAINCOURSE,
                    IsVegan = false,
                    IsVegetarian = false
                },
                new MenuItem
                {
                    MenuItemName = "Salmon w/ Ayrshire Potatoes",
                    MenuItemDescription = "Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. ",
                    MenuItemCost = 21,
                    MealType = MealType.MAINCOURSE,
                    IsVegan = true,
                    IsVegetarian = false
                },
                new MenuItem
                {
                    MenuItemName = "Salmon w/ Ayrshire Potatoes",
                    MenuItemDescription = "Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. ",
                    MenuItemCost = 22,
                    MealType = MealType.MAINCOURSE,
                    IsVegan = false,
                    IsVegetarian = false
                },
                new MenuItem
                {
                    MenuItemName = "Salmon w/ Ayrshire Potatoes",
                    MenuItemDescription = "Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. ",
                    MenuItemCost = 23,
                    MealType = MealType.STARTER,
                    IsVegan = false,
                    IsVegetarian = false

                },
                new MenuItem
                {
                    MenuItemName = "Salmon w/ Ayrshire Potatoes",
                    MenuItemDescription = "Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. ",
                    MenuItemCost = 24,
                    MealType = MealType.STARTER,
                    IsVegan = false,
                    IsVegetarian = false
                },
                new MenuItem
                {
                    MenuItemName = "Salmon w/ Ayrshire Potatoes",
                    MenuItemDescription = "Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. ",
                    MenuItemCost = 25,
                    MealType = MealType.MAINCOURSE,
                    IsVegan = true,
                    IsVegetarian = true
                },
                new MenuItem
                {
                    MenuItemName = "Salmon w/ Ayrshire Potatoes",
                    MenuItemDescription = "Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. ",
                    MenuItemCost = 26,
                    MealType = MealType.MAINCOURSE,
                    IsVegan = true,
                    IsVegetarian = true
                },
                new MenuItem
                {
                    MenuItemName = "Salmon w/ Ayrshire Potatoes",
                    MenuItemDescription = "Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. ",
                    MenuItemCost = 27,
                    MealType = MealType.STARTER,
                    IsVegan = false,
                    IsVegetarian = true
                },
                new MenuItem
                {
                    MenuItemName = "Salmon w/ Ayrshire Potatoes",
                    MenuItemDescription = "Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. ",
                    MenuItemCost = 28,
                    MealType = MealType.DESSERT,
                    IsVegan = false,
                    IsVegetarian = true
                },
                new MenuItem
                {
                    MenuItemName = "Salmon w/ Ayrshire Potatoes",
                    MenuItemDescription = "Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. Salmon with Ayrshire Potatoes. ",
                    MenuItemCost = 29,
                    MealType = MealType.STARTER,
                    IsVegan = true,
                    IsVegetarian = true
                },


            };
            menuItems.ForEach(l => context.MenuItems.Add(l));
            context.SaveChanges();

            // Seeded Menus for restaurants    
            var menus = new List<Menu>()
            {
                new Menu {
                    Name ="Autumn Time Menu",
                    Description = "Autumn Time Menu description. Autumn Time Menu description. Autumn Time Menu description. Autumn Time Menu description. Autumn Time Menu description. ",
                    AvailableFrom = new DateTime(2020, 9, 22),
                    AvailableTo = new DateTime(2020, 12, 21),
                    IsAvailable = false,
                    MenuItems = menuItems
                },
                new Menu {
                    Name ="Winter Time Menu",
                    Description = "Winter Time Menu description. Winter Time Menu description. Winter Time Menu description. Winter Time Menu description. Winter Time Menu description. Winter Time Menu description. ",
                    AvailableFrom = new DateTime(2020, 12, 21),
                    AvailableTo = new DateTime(2020, 3, 20),
                    IsAvailable = false,
                    MenuItems = menuItems
                },
                new Menu {
                    Name ="Spring Time Menu",
                    Description = "Spring Time Menu description. Spring Time Menu description. Spring Time Menu description. Spring Time Menu description. Spring Time Menu description. ",
                    AvailableFrom = new DateTime(2020, 3, 20),
                    AvailableTo = new DateTime(2020, 6, 21),
                    IsAvailable = false,
                    MenuItems = menuItems
                },
                new Menu {
                    Name ="Summer Time Menu",
                    Description = "Summer Time Menu description. Summer Time Menu description. Summer Time Menu description. Summer Time Menu description. Summer Time Menu description. Summer Time Menu description. ",
                    AvailableFrom = new DateTime(2020, 6, 21),
                    AvailableTo = new DateTime(2020, 9, 22),
                    IsAvailable = true,
                    MenuItems = menuItems
                }


            };
            menus.ForEach(l => context.Menus.Add(l));
            context.SaveChanges();


            // Seeding SpaOverview data for each hotel instance
            var diningOverview = new List<DiningOverview>
            {
                new DiningOverview
                {
                    DiningOverviewID = 1,
                    Header = "Geronimo Dining",
                    MainContent = "All Geronimo Hotels sports a fantabulous Dining, equipped with  the lastest and greatest gym equipment. " +
                    "All Geronimo Hotels sports a fantabulous Dining, equipped with  the lastest and greatest gym equipment. ",
                    // Menus = menus,
                    // GymClasses = gymClassesDefault,
                    // Timetable = timetableDefault
                },
                new DiningOverview
                {
                    DiningOverviewID = 2,
                    Header = "Glasgow Dining",
                    IntroductionParagraph = "Glasgow Dining - basic overview of location's Dining. Glasgow Dining - basic overview of location's Dining. ",
                    MainContent = "Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. " +
                    "Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. " +
                    "Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. ",
                    SecondaryContent = "Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. " +
                    "Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. " +
                    "Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. ",
                    Menus = menus
                },
                new DiningOverview
                {
                    DiningOverviewID = 3,
                    Header = "Paris Dining",
                    IntroductionParagraph = "Paris Dining - basic overview of location's Dining. ",
                    MainContent = "Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. ",
                    SecondaryContent = "Geronimo Hotels - Glasgow sports a fantabulous Dining with the lastest and greatest Dining equipment. ",
                    Menus = menus
                },
                new DiningOverview
                {
                    DiningOverviewID = 4,
                    Header = "Amsterdam Dining",
                    IntroductionParagraph = "Amsterdam Dining - basic overview of location's Dining. ",
                    MainContent = "Geronimo Hotels - Amsterdam sports a fantabulous Dining with the lastest and greatest Dining equipment. ",
                    SecondaryContent = "Geronimo Hotels - Amsterdam sports a fantabulous Dining with the lastest and greatest Dining equipment. ",
                    Menus = menus
                },
                new DiningOverview
                {
                    DiningOverviewID = 5,
                    Header = "New York Dining",
                    IntroductionParagraph = "New York Dining - basic overview of location's Dining. ",
                    MainContent = "Geronimo Hotels - New York sports a fantabulous Dining with the lastest and greatest Dining equipment. ",
                    SecondaryContent = "Geronimo Hotels - New York sports a fantabulous Dining with the lastest and greatest Dining equipment. " ,
                    Menus = menus
                },
                new DiningOverview
                {
                    DiningOverviewID = 6,
                    Header = "London Dining",
                    IntroductionParagraph = "London Dining - basic overview of location's Dining. ",
                    MainContent = "Geronimo Hotels - London sports a fantabulous Dining with the lastest and greatest Dining equipment. ",
                    SecondaryContent = "Geronimo Hotels - London sports a fantabulous Dining with the lastest and greatest Dining equipment. ",
                    Menus = menus
                }

            };
            diningOverview.ForEach(l => context.DiningOverview.Add(l));
            context.SaveChanges();






















            var locations = new List<Location>
            {
                new Location{
                    LocationName="Geronimo Hotels", 
                    LocationIntroduction="Geronimo Hotels is a international hotels - but there's more - it also possess magical abilities. Loved and adored by every damn person on the planet. " + 
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor " + 
                    "incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " + 
                    "exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", 
                    RoomOverviewID = 1,
                    GymOverviewID = 1,
                    SpaOverviewID = 1,
                    DiningOverviewID = 1,
                    EventOverviewID = 1
                },
                new Location{
                    LocationName="Glasgow",
                    LocationIntroduction="Geronimo Hotels - Glasgow is a lovely hotel - but there's more - anyone who attends the gym acquires great Scottish powers. They can speak sooo fast that it's almost incomprehensible. Loved and adored by every damn person on the planet. " +
                    "Lorem ipsum dolor sit amet, consectetur aliqua consectetur consectetur adipiscing elit, sed do eiusmod tempor " +
                    "incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                    "exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    RoomOverviewID = 2,
                    GymOverviewID = 2,
                    SpaOverviewID = 2,
                    DiningOverviewID = 2,
                    EventOverviewID = 2,
                    Rooms = glasgowRooms

                },
                new Location{
                    LocationName="Paris",
                    LocationIntroduction="Geronimo Hotels - Paris is a international hotels - but there's more - it also possess magical abilities. Loved and adored by every damn person on the planet. " +
                    "Lorem ipsum dolor sit amet, consectetur amet, consectetur amet, consectetur adipiscing elit, sed do eiusmod tempor " +
                    "incididunt ut labore et doloredoloredoloredolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                    "exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    RoomOverviewID = 3,
                    GymOverviewID = 3,
                    SpaOverviewID = 3,
                    DiningOverviewID = 3,
                    EventOverviewID = 3

                },
                new Location{
                    LocationName="Amsterdam",
                    LocationIntroduction="Geronimo Hotels - Amsterdam is a international hotels - but there's more - it also possess magical abilities. Loved and adored by every damn person on the planet. " +
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor " +
                    "incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                    "exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    RoomOverviewID = 4,
                    GymOverviewID = 4,
                    SpaOverviewID = 4,
                    DiningOverviewID = 4,
                    EventOverviewID = 4
                },
                new Location{
                    LocationName="New York",
                    LocationIntroduction="Geronimo Hotels - New York is a international hotels - but there's more - it also possess magical abilities. Loved and adored by every damn person on the planet. " +
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor " +
                    "incididunt ut labore et dolore magna aliqua. Ut enim didunt ut labore et dolore magna aliqua. Ut enim didunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                    "exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    RoomOverviewID = 5,
                    GymOverviewID = 5,
                    SpaOverviewID = 5,
                    DiningOverviewID = 5,
                    EventOverviewID = 5
                },
                new Location{
                    LocationName="London",
                    LocationIntroduction="Geronimo Hotels - London is located in the centre of London - but there's more - it's situated . Loved and adored by every damn person on the planet. " +
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor " +
                    "exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",                     
                    RoomOverviewID = 6,
                    GymOverviewID = 6,
                    SpaOverviewID = 6,
                    DiningOverviewID = 6,
                    EventOverviewID = 6,
                    Rooms = londonRooms
                }

            };
            locations.ForEach(l => context.Location.Add(l));
            context.SaveChanges();




        }
    }
}