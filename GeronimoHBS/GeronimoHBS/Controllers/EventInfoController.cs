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
    public class EventInfoController : BaseController
    {
        // GET: EventInfo
        public ActionResult Index()
        {
            return View(db.EventInfo.ToList());
        }

        // GET: EventInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventInfo eventInfo = db.EventInfo.Find(id);
            if (eventInfo == null)
            {
                return HttpNotFound();
            }
            return View(eventInfo);
        }

        // GET: EventInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventInfoID,Name,Description,IsPublic,EventOverviewID")] EventInfo eventInfo)
        {
            if (ModelState.IsValid)
            {
                db.EventInfo.Add(eventInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventInfo);
        }

        // GET: EventInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventInfo eventInfo = db.EventInfo.Find(id);
            if (eventInfo == null)
            {
                return HttpNotFound();
            }
            return View(eventInfo);
        }

        // POST: EventInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventInfoID,Name,Description,IsPublic,EventOverviewID")] EventInfo eventInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventInfo);
        }

        // GET: EventInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventInfo eventInfo = db.EventInfo.Find(id);
            if (eventInfo == null)
            {
                return HttpNotFound();
            }
            return View(eventInfo);
        }

        // POST: EventInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventInfo eventInfo = db.EventInfo.Find(id);
            db.EventInfo.Remove(eventInfo);
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
