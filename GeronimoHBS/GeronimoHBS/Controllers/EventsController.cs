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
    public class EventsController : BaseController
    {
        // GET: Events
        public ActionResult Index(int? Id)
        {
            var currentLocation = db.Location.First();
            if (Id == null)
            {
                ViewBag.Location = "Welcome to Geronimo Hotel";
            }
            else
            {
                currentLocation = db.Location.Find(Id);
            }


            ViewBag.Location = db.Location.Find(Id);
            ViewBag.Collection = breadcrumbs;
            return View(currentLocation);
        }





        public ActionResult VenueAvailability(int? VenueId, int LocationId)
        {
            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index/" + LocationId },
                new string []{ "Events", "../../Events/Index/" + LocationId }
            };
            ViewBag.Collection = breadcrumbs;


            var currentLocation = db.Location.Find(LocationId);


            var locationsVenues = currentLocation.EventOverview.Venues;
            ViewBag.LocationID = new SelectList(db.Location, "LocationID", "LocationName");
            ViewBag.VenueID = new SelectList(locationsVenues, "VenueID", "VenueName");

            return View(currentLocation);

        }





        // GET: Events1
        public ActionResult AdminIndex()
        {
            var events = db.Events.Include(e => e.EventStatus).Include(e => e.Guest).Include(e => e.Venue);
            return View(events.ToList());
        }

        // GET: Events1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event currentEvent = db.Events.Find(id);
            if (currentEvent == null)
            {
                return HttpNotFound();
            }
            return View(currentEvent);
        }

        // GET: Events1/Create
        public ActionResult Create()
        {
            ViewBag.EventStatusID = new SelectList(db.EventsStatus, "EventStatusID", "EventStatusName");
            ViewBag.GuestId = new SelectList(db.Users, "Id", "Title");
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName");
            return View();
        }

        // POST: Events1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,EventName,Description,StartDate,EndDate,NoOfParticipants,AmountPaid,CalculatedCost,ExtraCost,PublicEvent,EventOverviewID,EventStatusID,VenueID,GuestId")] Event currentEvent)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(currentEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventStatusID = new SelectList(db.EventsStatus, "EventStatusID", "EventStatusName", currentEvent.EventStatusID);
            ViewBag.GuestId = new SelectList(db.Users, "Id", "Title", currentEvent.GuestId);
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", currentEvent.VenueID);
            return View(currentEvent);
        }

        // GET: Events1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event currentEvent = db.Events.Find(id);
            if (currentEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventStatusID = new SelectList(db.EventsStatus, "EventStatusID", "EventStatusName", currentEvent.EventStatusID);
            ViewBag.GuestId = new SelectList(db.Users, "Id", "Title", currentEvent.GuestId);
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", currentEvent.VenueID);
            return View(currentEvent);
        }

        // POST: Events1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,EventName,Description,StartDate,EndDate,NoOfParticipants,AmountPaid,CalculatedCost,ExtraCost,PublicEvent,EventOverviewID,EventStatusID,VenueID,GuestId")] Event currentEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currentEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventStatusID = new SelectList(db.EventsStatus, "EventStatusID", "EventStatusName", currentEvent.EventStatusID);
            ViewBag.GuestId = new SelectList(db.Users, "Id", "Title", currentEvent.GuestId);
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", currentEvent.VenueID);
            return View(currentEvent);
        }

        // GET: Events1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event currentEvent = db.Events.Find(id);
            if (currentEvent == null)
            {
                return HttpNotFound();
            }
            return View(currentEvent);
        }

        // POST: Events1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event currentEvent = db.Events.Find(id);
            db.Events.Remove(currentEvent);
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
