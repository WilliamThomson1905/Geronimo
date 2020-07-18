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

            var defaultLocation = db.Location.Find(0);

            return View(defaultLocation);
        }

        [HttpPost]
        public ActionResult Index(int? LocationID)
        {
            if (LocationID != null)
            {
                var location = db.Location.Find(LocationID);

                if (location.LocationName.Equals("Default"))
                {
                    ViewBag.Location = "Welcome to Geronimo Hotel";
                }
                else
                {
                    ViewBag.Location = "Geronimo Hotel: " + location.LocationName.ToString();
                    return View(location);
                }
            }
            return View();
        }

    }
}
