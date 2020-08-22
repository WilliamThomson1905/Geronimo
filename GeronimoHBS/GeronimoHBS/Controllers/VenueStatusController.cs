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
    public class VenueStatusController : BaseController
    {
        // GET: VenueStatus
        public ActionResult Index()
        {
            var venuesStatus = db.VenuesStatus.Include(v => v.Venue);
            return View(venuesStatus.ToList());
        }

        // GET: VenueStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VenueStatus venueStatus = db.VenuesStatus.Find(id);
            if (venueStatus == null)
            {
                return HttpNotFound();
            }
            return View(venueStatus);
        }

        // GET: VenueStatus/Create
        public ActionResult Create()
        {
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName");
            return View();
        }

        // POST: VenueStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VenueStatusID,VenueStatusName,StartDate,EndDate,VenueID")] VenueStatus venueStatus)
        {
            if (ModelState.IsValid)
            {
                db.VenuesStatus.Add(venueStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", venueStatus.VenueID);
            return View(venueStatus);
        }

        // GET: VenueStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VenueStatus venueStatus = db.VenuesStatus.Find(id);
            if (venueStatus == null)
            {
                return HttpNotFound();
            }
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", venueStatus.VenueID);
            return View(venueStatus);
        }

        // POST: VenueStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VenueStatusID,VenueStatusName,StartDate,EndDate,VenueID")] VenueStatus venueStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venueStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", venueStatus.VenueID);
            return View(venueStatus);
        }

        // GET: VenueStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VenueStatus venueStatus = db.VenuesStatus.Find(id);
            if (venueStatus == null)
            {
                return HttpNotFound();
            }
            return View(venueStatus);
        }

        // POST: VenueStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VenueStatus venueStatus = db.VenuesStatus.Find(id);
            db.VenuesStatus.Remove(venueStatus);
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
