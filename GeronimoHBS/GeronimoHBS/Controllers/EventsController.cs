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





        public ActionResult VenueAvailability(int? VenueId, int LocationId)
        {
            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index/" + LocationId },
                new string []{ "Events", "../../Events/Index/" + LocationId }
            };
            ViewBag.Collection = breadcrumbs;


            var currentLocation = db.Location.Find(LocationId);


            var locationsVenues = currentLocation.EventOverview.Venues;
            ViewBag.LocationID = new SelectList(db.Location, "LocationID", "LocationName");
            ViewBag.VenueID = new SelectList(locationsVenues, "VenueID", "VenueName");

            return View(currentLocation);

        }


    }
}
