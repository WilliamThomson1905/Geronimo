using GeronimoHBS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeronimoHBS.Controllers
{
    public class BaseController : Controller
    {
        protected string[][] breadcrumbs;
        protected ApplicationDbContext db = new ApplicationDbContext();


        public BaseController()
        {

            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index/1" }
            };
            ViewBag.Collection = breadcrumbs;


        }
    }
}