using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeronimoHBS.Controllers
{
    public class EventsController : BaseController
    {
        // GET: Events
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


            ViewBag.Location = db.Location.Find(Id);
            ViewBag.Collection = breadcrumbs;
            return View(currentLocation);
        }





        public ActionResult EventSelection(int? Id)
        {
            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index/" + Id },
                new string []{ "Event", "../../Events/Index/" + Id }
            };
            ViewBag.Collection = breadcrumbs;


            var currentLocation = db.Location.Find(Id);
            ViewBag.LocationID = new SelectList(db.Location, "LocationID", "LocationName");
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName");

            return View(currentLocation);

        }


    }
}
