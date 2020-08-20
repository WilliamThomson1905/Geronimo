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
    public class LocationsController : BaseController
    {


        // GET: Locations
        public ActionResult Index()
        {
            var location = db.Location.Include(l => l.DiningOverview).Include(l => l.EventOverview).Include(l => l.GymOverview).Include(l => l.RoomOverview).Include(l => l.SpaOverview);
            return View(location.ToList());
        }

        // GET: Locations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Location.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: Locations/Create
        public ActionResult Create()
        {
            ViewBag.LocationID = new SelectList(db.DiningOverview, "LocationID", "Header");
            ViewBag.LocationID = new SelectList(db.EventOverview, "LocationID", "Header");
            ViewBag.LocationID = new SelectList(db.GymOverview, "LocationID", "Header");
            ViewBag.LocationID = new SelectList(db.RoomOverview, "LocationID", "Header");
            ViewBag.LocationID = new SelectList(db.SpaOverview, "LocationID", "Header");
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocationID,LocationName,LocationIntroduction")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Location.Add(location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationID = new SelectList(db.DiningOverview, "LocationID", "Header", location.LocationID);
            ViewBag.LocationID = new SelectList(db.EventOverview, "LocationID", "Header", location.LocationID);
            ViewBag.LocationID = new SelectList(db.GymOverview, "LocationID", "Header", location.LocationID);
            ViewBag.LocationID = new SelectList(db.RoomOverview, "LocationID", "Header", location.LocationID);
            ViewBag.LocationID = new SelectList(db.SpaOverview, "LocationID", "Header", location.LocationID);
            return View(location);
        }

        // GET: Locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Location.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationID = new SelectList(db.DiningOverview, "LocationID", "Header", location.LocationID);
            ViewBag.LocationID = new SelectList(db.EventOverview, "LocationID", "Header", location.LocationID);
            ViewBag.LocationID = new SelectList(db.GymOverview, "LocationID", "Header", location.LocationID);
            ViewBag.LocationID = new SelectList(db.RoomOverview, "LocationID", "Header", location.LocationID);
            ViewBag.LocationID = new SelectList(db.SpaOverview, "LocationID", "Header", location.LocationID);
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocationID,LocationName,LocationIntroduction")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationID = new SelectList(db.DiningOverview, "LocationID", "Header", location.LocationID);
            ViewBag.LocationID = new SelectList(db.EventOverview, "LocationID", "Header", location.LocationID);
            ViewBag.LocationID = new SelectList(db.GymOverview, "LocationID", "Header", location.LocationID);
            ViewBag.LocationID = new SelectList(db.RoomOverview, "LocationID", "Header", location.LocationID);
            ViewBag.LocationID = new SelectList(db.SpaOverview, "LocationID", "Header", location.LocationID);
            return View(location);
        }

        // GET: Locations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Location.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Location location = db.Location.Find(id);
            db.Location.Remove(location);
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
