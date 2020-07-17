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
        public ActionResult Index()
        {
            return View();
        }
    }
}
