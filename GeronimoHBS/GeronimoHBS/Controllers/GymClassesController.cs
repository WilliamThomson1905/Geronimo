using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GeronimoHBS.DAL;
using GeronimoHBS.Models;

namespace GeronimoHBS.Controllers
{
    public class GymClassesController : BaseController
    {
        // GET: GymClasses
        public ActionResult Index()
        {
            return View(db.GymClasses.ToList());
        }

        // GET: GymClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymClasses gymClasses = db.GymClasses.Find(id);
            if (gymClasses == null)
            {
                return HttpNotFound();
            }
            return View(gymClasses);
        }

        // GET: GymClasses/Create
        public ActionResult Create()
        {
            var locations = from location in db.Location
                            where location.LocationID != 1
                            orderby location.LocationID
                            select location;


            ViewBag.GymOverviewID = new SelectList(locations, "LocationID", "LocationName");
            ViewBag.Focus = db.ClassFocus.ToList();

            return View();
        }

        // POST: GymClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GymClassesID,Title,Introduction,Description,Benefits,GymOverviewID")] GymClasses gymClasses)
        {
            var currentGymClass = db.GymOverview.Find(gymClasses.GymOverviewID);
       

            if (ModelState.IsValid)
            {
                currentGymClass.GymClasses.Add(gymClasses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gymClasses);


        }

        // GET: GymClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymClasses gymClasses = db.GymClasses.Find(id);
            if (gymClasses == null)
            {
                return HttpNotFound();
            }
            return View(gymClasses);
        }

        // POST: GymClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GymClassesID,Title,Introduction,Description,Benefits,GymOverviewID")] GymClasses gymClasses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gymClasses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gymClasses);
        }

        // GET: GymClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymClasses gymClasses = db.GymClasses.Find(id);
            if (gymClasses == null)
            {
                return HttpNotFound();
            }
            return View(gymClasses);
        }

        // POST: GymClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GymClasses gymClasses = db.GymClasses.Find(id);
            db.GymClasses.Remove(gymClasses);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
