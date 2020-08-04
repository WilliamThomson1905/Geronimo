using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeronimoHBS.Controllers
{
    public class DiningController : BaseController
    {
        // GET: Dining
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

        // GET: Dining/Menu
        public ActionResult Menu()
        {

            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index/2" },
                new string [] { "Geronimo Hotel", "../../Dining/Index/2" }
            };

            ViewBag.Collection = breadcrumbs;
            return View();
        }

    }
}
