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
    public class EventStatusController : BaseController
    {
        // GET: EventStatus
        public ActionResult Index()
        {
            return View(db.EventsStatus.ToList());
        }

        // GET: EventStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventStatus eventStatus = db.EventsStatus.Find(id);
            if (eventStatus == null)
            {
                return HttpNotFound();
            }
            return View(eventStatus);
        }

        // GET: EventStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventStatusID,EventStatusName")] EventStatus eventStatus)
        {
            if (ModelState.IsValid)
            {
                db.EventsStatus.Add(eventStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventStatus);
        }

        // GET: EventStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventStatus eventStatus = db.EventsStatus.Find(id);
            if (eventStatus == null)
            {
                return HttpNotFound();
            }
            return View(eventStatus);
        }

        // POST: EventStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventStatusID,EventStatusName")] EventStatus eventStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventStatus);
        }

        // GET: EventStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventStatus eventStatus = db.EventsStatus.Find(id);
            if (eventStatus == null)
            {
                return HttpNotFound();
            }
            return View(eventStatus);
        }

        // POST: EventStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventStatus eventStatus = db.EventsStatus.Find(id);
            db.EventsStatus.Remove(eventStatus);
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
