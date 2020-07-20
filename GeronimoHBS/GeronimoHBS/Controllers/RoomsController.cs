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
        public ActionResult Index()
        {
            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index" }
            };
            ViewBag.Collection = breadcrumbs;

            return View();
        }
        public ActionResult RoomSelection()
        {
            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index" },
                new string []{ "Room Info", "../../Rooms/Index"}
            };
            ViewBag.Collection = breadcrumbs;

            return View();
        }

        public ActionResult Availability()
        {
            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index" },
                new string []{ "Room Info", "../../Rooms/Index"},
                new string []{ "Room Selection", "../../Rooms/RoomSelection"}
            };
            ViewBag.Collection = breadcrumbs;

            return View();
        }


        public ActionResult Payment()
        {
            return View();
        }


    }
}
