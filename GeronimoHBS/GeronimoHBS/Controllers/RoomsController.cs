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

            if (Id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index/2" }
            };

            ViewBag.Collection = breadcrumbs;

            var currentLocation = this.db.Location.First();
            
            if (currentLocation == null)
            {
                return HttpNotFound();
            }





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
