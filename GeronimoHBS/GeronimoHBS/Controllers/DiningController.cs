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
        public ActionResult Index()
        {
            return View();
        }

        // GET: Dining/Menu
        public ActionResult Menu()
        {
            return View();
        }

    }
}
