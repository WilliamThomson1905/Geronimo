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

        // GET: Hotel
        public ActionResult Index()
        {
            ViewBag.Location = "Welcome to Geronimo Hotel";

            var locations = from l in db.Location
                           select l;


            return View(locations.ToList());
        }

        [HttpPost]
        public ActionResult Index(int? LocationID)
        {

            if (LocationID == null)
            {
                ViewBag.Location = "Welcome to Geronimo Hotel";
            }
            else
            {
                var location = db.Location.Find(LocationID);
                ViewBag.Location = "Geronimo Hotel: " + location.LocationName.ToString();
                return View(location);
            }
            return View();
        }

    }
}
