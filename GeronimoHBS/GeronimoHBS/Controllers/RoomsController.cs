using System;
using System.Collections.Generic;
using System.Linq;
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
            if (Id != null)
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


    }
}
