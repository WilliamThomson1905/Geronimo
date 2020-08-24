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
    public class RoomStatusController : BaseController
    {
        // GET: RoomStatus
        public ActionResult Index()
        {
            return View(db.RoomStatus.ToList());
        }

        // GET: RoomStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomStatusID,RoomStatusName")] RoomStatus roomStatus)
        {
            if (ModelState.IsValid)
            {
                db.RoomStatus.Add(roomStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roomStatus);
        }

        // GET: RoomStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomStatus roomStatus = db.RoomStatus.Find(id);
            if (roomStatus == null)
            {
                return HttpNotFound();
            }
            return View(roomStatus);
        }

        // POST: RoomStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoomStatusID,RoomStatusName")] RoomStatus roomStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roomStatus);
        }

        // GET: RoomStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomStatus roomStatus = db.RoomStatus.Find(id);
            if (roomStatus == null)
            {
                return HttpNotFound();
            }
            return View(roomStatus);
        }

        // POST: RoomStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomStatus roomStatus = db.RoomStatus.Find(id);
            db.RoomStatus.Remove(roomStatus);
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
