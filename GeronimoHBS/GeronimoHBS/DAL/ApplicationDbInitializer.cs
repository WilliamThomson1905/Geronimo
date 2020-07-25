﻿using System;
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





            // DEFAULTY DATA
            // Seeded Equipment - Default
            var equipmentDefault = new List<Equipment>
            {
                new Equipment
                {
                    Name = "D_item1",
                    Description = "item1 description item1 description item1 description. ",
                    Quantity = 13
                },
                new Equipment
                {
                    Name = "D_item2",
                    Description = "item2 description item2 description item2 description. ",
                    Quantity = 21

                },
                new Equipment
                {
                    Name = "D_item3",
                    Description = "item3 description item3 description item3 description. ",
                    Quantity = 7

                }

            };
            equipmentDefault.ForEach(l => context.Equipment.Add(l));
            context.SaveChanges();

            // Seeded Gym Classes - Default    
            var gymClassesDefault = new List<GymClasses>()
            {
                new GymClasses {
                    Title ="D_Gym Class 1",
                    Description = "Gym Class 1 description. ",

                },
                new GymClasses {
                    Title ="D_Gym Class 2",
                    Description = "Gym Class 2 description. "
                },
                new GymClasses {
                    Title ="D_Gym Class 3",
                    Description = "Gym Class 3 description. "
                },
                new GymClasses {
                    Title ="D_Gym Class 4",
                    Description = "Gym Class 4 description. "
                },
                new GymClasses {
                    Title ="D_Gym Class 5",
                    Description = "Gym Class 5 description. "
                },


            };
            gymClassesDefault.ForEach(l => context.GymClasses.Add(l));
            context.SaveChanges();

            // Seeded Timetable - Default
            var timetableDefault = new List<Timetable>
            {
                // MONDAY
                new Timetable()
                {
                    Day = Day.MONDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.FULLYBOOKED,
                    Instructor = "Tim Timothy",
                    GymClasses = gymClassesDefault[0],
                    GymClassesID = gymClassesDefault[0].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.TUESDAY,
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(10, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "Tim Timothy",
                    GymClasses = gymClassesDefault[0],
                    GymClassesID = gymClassesDefault[0].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.WEDNESDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "Tim Timothy",
                    GymClasses = gymClassesDefault[1],
                    GymClassesID = gymClassesDefault[1].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.THURSDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.CANCELLED,
                    Instructor = "Tim Timothy",
                    GymClasses = gymClassesDefault[3],
                    GymClassesID = gymClassesDefault[3].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.FRIDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "Tim Timothy",
                    GymClasses = gymClassesDefault[1],
                    GymClassesID = gymClassesDefault[1].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.SATURDAY,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "Tim Timothy",
                    GymClasses = gymClassesDefault[4],
                    GymClassesID = gymClassesDefault[4].GymClassesID
                },
                new Timetable()
                {
                    Day = Day.SUNDAY,
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(18, 0, 0),
                    GymClassStatus = GymClassStatus.AVAILABLE,
                    Instructor = "Tim Timothy",
                    GymClasses = gymClassesDefault[2],
                    GymClassesID = gymClassesDefault[2].GymClassesID
                }
            };
            timetableDefault.ForEach(l => context.Timetable.Add(l));
            context.SaveChanges();


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
                    Name = "G_item1",
                    Description = "item1 description item1 description item1 description. ",
                    Quantity = 13
                },
                new Equipment
                {
                    Name = "G_item2",
                    Description = "item2 description item2 description item2 description. ",
                    Quantity = 21

                },new Equipment
                {
                    Name = "G_item3",
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
                    Title ="G_Gym Class 1",
                    Introduction = "Gym Class 1 introduction. Gym Class 1 introduction. Gym Class 1 introduction. " +
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
                    Header = "Default Gym",
                    Content = "dssssss",
                    Equipment = equipmentDefault,
                    GymClasses = gymClassesDefault,
                    Timetable = timetableDefault
                },
                new GymOverview
                {
                    Header = "Glasgow Gym",
                    Content = "gssssss",
                    Equipment = equipmentGlasgow,
                    GymClasses = gymClassesGlasgow,
                    Timetable = timetableGlasgow

                },
                new GymOverview
                {
                    Header = "Paris Gym",
                    Content = "ssgggssss",
                    Equipment = equipmentParis,
                    GymClasses = gymClassesParis,
                    Timetable = timetableParis
                },
                new GymOverview
                {
                    Header = "Amsterdam Gym",
                    Content = "ssssdassss",
                    Equipment = equipmentAmsterdam,
                    GymClasses = gymClassesAmsterdam,
                    Timetable = timetableAmsterdam
                },
                new GymOverview
                {
                    Header = "New York Gym",
                    Content = "ssaassss",
                    Equipment = equipmentNewYork,
                    GymClasses = gymClassesNewYork,
                    Timetable = timetableNewYork
                },
                new GymOverview
                {
                    Header = "London Gym",
                    Content = "ssaassss",
                    Equipment = equipmentLondon,
                    GymClasses = gymClassesLondon,
                    Timetable = timetableLondon
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