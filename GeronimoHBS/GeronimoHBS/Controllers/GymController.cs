﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeronimoHBS.Controllers
{
    public class GymController : Controller
    {
        // GET: Rooms
        public ActionResult Index()
        {
            return View();
        }

        // GET: Rooms/Details/5
        public ActionResult ClassesDetails()
        {
            return View();
        }
        
    }
}