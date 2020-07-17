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

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
           string locationChosen = form["location"].ToString();


            if (locationChosen == "default")
            {
                ViewBag.Location = "Welcome to Geronimo Hotel";
            }
            else
            {
                ViewBag.Location = "Geronimo Hotel: " + locationChosen;
            }
            return View();
        }

    }
}
