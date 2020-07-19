using GeronimoHBS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeronimoHBS.Controllers
{
    public class HotelController : BaseController
    {

        [HttpGet]
        public ActionResult Index(int Id, string name)
        {
            var searchLocation = db.Location.Find(Id);
            ViewBag.Location = "Geronimo: " + searchLocation.LocationName.ToString();

            return View(searchLocation);
        }

        [HttpPost]
        public ActionResult Index(int? LocationID)
        {
            var location = db.Location.Find(LocationID);

            if (location.LocationName.Equals("Default"))
            {
                ViewBag.Location = "Welcome to Geronimo Hotel";
            }
            else
            {
                ViewBag.Location = "Geronimo: " + location.LocationName.ToString();
            }
            return View(location);
        }
    }
}
