using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeronimoHBS.Controllers
{
    public class GymController : BaseController
    {

        // GET: Rooms
        public ActionResult Index(int Id)
        {
            var currentGym = db.GymOverview.Find(Id);
            ViewBag.Collection = breadcrumbs;


            return View(currentGym);
        }

        // GET: Gym/ClassesDetails/5
        public ActionResult ClassesDetails(int Id)
        {
            var currentGym = db.GymOverview.Find(Id);

            return View(currentGym);
        }
        
    }
}
