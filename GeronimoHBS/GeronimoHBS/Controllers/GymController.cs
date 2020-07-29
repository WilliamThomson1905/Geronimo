using GeronimoHBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeronimoHBS.Controllers
{
    public class GymController : BaseController
    {

        // GET: Rooms
        public ActionResult Index(int? Id)
        {
            ViewBag.ClassFocus = from classFocus in db.ClassFocus
                              select classFocus;

            var currentLocation = db.Location.First();
            if (Id == null)
            {
                ViewBag.Location = "Welcome to Geronimo Hotel";
            }
            else
            {
                currentLocation = db.Location.Find(Id);
                ViewBag.Location = "Geronimo: " + currentLocation.LocationName.ToString();
            }

            ViewBag.Collection = breadcrumbs;
            return View(currentLocation);
        }

        // GET: Gym/GymClassDetails/Id
        public ActionResult GymClassDetails(int Id)
        {
            var currentClassDetails = db.GymClasses.Find(Id);
            
            ViewBag.Collection = breadcrumbs;
            return View(currentClassDetails);
        }

        // GET: Gym/ClassesDetails/5
        public ActionResult Timetable(int? Id)
        {

            var currentLocation = db.Location.First();
            if (Id == null)
            {
                ViewBag.Location = "Welcome to Geronimo Hotel";
            }
            else
            {
                currentLocation = db.Location.Find(Id);
                ViewBag.Location = currentLocation;
            }
            var locationTimetable = currentLocation.GymOverview.Timetable;

            //monday classes
            var monday = from day1 in locationTimetable
                         where day1.Day == Day.MONDAY
                         orderby day1.StartTime
                         select day1;

            var tuesday = from day2 in locationTimetable
                          where day2.Day == Day.TUESDAY
                          orderby day2.StartTime
                          select day2;

            var wednesday = from day3 in locationTimetable
                            where day3.Day == Day.WEDNESDAY
                            orderby day3.StartTime
                            select day3;

            var thursday = from day4 in locationTimetable
                           where day4.Day == Day.THURSDAY
                           orderby day4.StartTime
                           select day4;

            var friday = from day5 in locationTimetable
                         where day5.Day == Day.FRIDAY
                         orderby day5.StartTime
                         select day5;

            var saturday = from day6 in locationTimetable
                           where day6.Day == Day.SATURDAY
                           orderby day6.StartTime
                           select day6;

            var sunday = from day7 in locationTimetable
                         where day7.Day == Day.SUNDAY
                         orderby day7.StartTime
                         select day7;


            TimetableViewModel slvm = new TimetableViewModel()
            {
                Monday = monday.ToList(),
                Tuesday = tuesday.ToList(),
                Wednesday = wednesday.ToList(),
                Thursday = thursday.ToList(),
                Friday = friday.ToList(),
                Saturday = saturday.ToList(),
                Sunday = sunday.ToList(),
            };

            return View(slvm);
        }



    }
}
