using GeronimoHBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GeronimoHBS.Controllers
{
    public class RoomsController : BaseController
    {
        // GET: Rooms
        public ActionResult Index(int? Id)
        {

            var currentLocation = db.Location.First();
            if (Id == null)
            {
                ViewBag.Location = "Welcome to Geronimo Hotel";
            }
            else
            {
                currentLocation = db.Location.Find(Id);
            }


            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index/2" }
            };

            ViewBag.Collection = breadcrumbs;
            return View(currentLocation);            
        }



        public ActionResult RoomSelection(int? Id)
        {
            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index/2" },
                new string []{ "Room Info", "../../Rooms/Index"}
            };
            ViewBag.Collection = breadcrumbs;
            var currentLocation = db.Location.Find(Id);
            ViewBag.LocationID = new SelectList(db.Location, "LocationID", "LocationName");
            ViewBag.RoomTypeID = new SelectList(db.RoomType, "RoomTypeID", "Name");

            return View(currentLocation);
        }


        public ActionResult Availability(int? Id)
        {
            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index/2" },
                new string []{ "Room Info", "../../Rooms/Index"},
                new string []{ "Room Selection", "../../Rooms/RoomSelection"}
            };
            ViewBag.Collection = breadcrumbs;

            var currentLocation = db.Location.Find(Id);

            return View(currentLocation);
        }


        [HttpPost]
        public ActionResult Availability(int LocationId, string roomsCount, string roomTypeId, string startDate, string endDate)
        {
            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index/2" },
                new string []{ "Room Info", "../../Rooms/Index"},
                new string []{ "Room Selection", "../../Rooms/RoomSelection"}
            };
            ViewBag.Collection = breadcrumbs;
            var currentLocation = db.Location.Find(LocationId);
            ViewBag.RoomsCount = roomsCount;
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            int roomTypeIdint = int.Parse(roomTypeId);

            var roomType = db.RoomType.Find(roomTypeIdint);
            ViewBag.RoomType = roomType;

            //get rooms for locations which meets criteria
            ViewBag.Rooms = db.Room.Where(e => e.Location.LocationID == (LocationId) && e.RoomStatus.RoomStatusName.Equals("vacant")).AsQueryable().ToList();


            // e.RoomStatusID.Equals("vacant")
            return View(currentLocation);
        }



        public ActionResult Payment(int? Id)
        {

            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index" },
                new string []{ "Room Info", "../../Rooms/Index"},
                new string []{ "Room Selection", "../../Rooms/RoomSelection"},
                new string []{ "Availability", "../../Rooms/Availability" }
            };


            ViewBag.Collection = breadcrumbs;

            return View();
        }

        [HttpPost]
        public ActionResult Payment(int[] RoomsSelected)
        {

            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index" },
                new string []{ "Room Info", "../../Rooms/Index"},
                new string []{ "Room Selection", "../../Rooms/RoomSelection"},
                new string []{ "Availability", "../../Rooms/Availability" }
            };


            ViewBag.Collection = breadcrumbs;

            return View();
        }


    }
}
