using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeronimoHBS.Controllers
{
    public class SpaController : BaseController
    {
        // GET: Spa
        public ActionResult Index(int Id)
        {
            var currentSpaDetails = db.SpaOverview.Find(Id);

            ViewBag.Collection = breadcrumbs;
            ViewBag.Location = db.Location.Find(Id);

            return View(currentSpaDetails);
        }
    }
}
