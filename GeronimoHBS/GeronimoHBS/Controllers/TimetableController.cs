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
    public class TimetableController : BaseController
    {

        // GET: Timetable
        public ActionResult Index()
        {
            var timetable = db.Timetable.Include(t => t.GymClasses);
            return View(timetable.ToList());
        }

        // GET: Timetable/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timetable timetable = db.Timetable.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        // GET: Timetable/Create
        public ActionResult Create()
        {
            ViewBag.GymClassesID = new SelectList(db.GymClasses, "GymClassesID", "Title");
            ViewBag.GymOverviewID = new SelectList(db.Location.Where(e => e.LocationID != 1), "LocationID", "LocationName");

            return View();
        }

        // POST: Timetable/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TimetableID,Day,StartTime,EndTime,Instructor,GymClassStatus,GymClassesID,GymOverviewID")] Timetable timetable)
        {

            var currentTimetable = db.GymOverview.Find(timetable.TimetableID);


            if (ModelState.IsValid)
            {
                currentTimetable.Timetable.Add(timetable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.GymClassesID = new SelectList(db.GymClasses, "GymClassesID", "Title", timetable.GymClassesID);
            return View(timetable);
        }

        // GET: Timetable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timetable timetable = db.Timetable.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            ViewBag.GymClassesID = new SelectList(db.GymClasses, "GymClassesID", "Title", timetable.GymClassesID);
            return View(timetable);
        }

        // POST: Timetable/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TimetableID,Day,StartTime,EndTime,Instructor,GymClassStatus,GymClassesID,GymOverviewID")] Timetable timetable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timetable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GymClassesID = new SelectList(db.GymClasses, "GymClassesID", "Title", timetable.GymClassesID);
            return View(timetable);
        }

        // GET: Timetable/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timetable timetable = db.Timetable.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        // POST: Timetable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Timetable timetable = db.Timetable.Find(id);
            db.Timetable.Remove(timetable);
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
