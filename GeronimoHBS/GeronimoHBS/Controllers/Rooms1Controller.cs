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
    public class Rooms1Controller : BaseController
    {
        // GET: Rooms1
        public ActionResult Index()
        {
            var room = db.Room.Include(r => r.RoomStatus).Include(r => r.RoomType);
            return View(room.ToList());
        }

        // GET: Rooms1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Room.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Rooms1/Create
        public ActionResult Create()
        {
            ViewBag.RoomStatusID = new SelectList(db.RoomStatus, "RoomStatusID", "RoomStatusName");
            ViewBag.RoomTypeID = new SelectList(db.RoomType, "RoomTypeID", "Name");
            return View();
        }

        // POST: Rooms1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomID,FloorNumber,RoomNumber,NumberOfBeds,Capacity,Name,Description,Price,RoomTypeID,RoomStatusID,RoomOverviewID")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Room.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoomStatusID = new SelectList(db.RoomStatus, "RoomStatusID", "RoomStatusName", room.RoomStatusID);
            ViewBag.RoomTypeID = new SelectList(db.RoomType, "RoomTypeID", "Name", room.RoomTypeID);
            return View(room);
        }

        // GET: Rooms1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Room.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomStatusID = new SelectList(db.RoomStatus, "RoomStatusID", "RoomStatusName", room.RoomStatusID);
            ViewBag.RoomTypeID = new SelectList(db.RoomType, "RoomTypeID", "Name", room.RoomTypeID);
            return View(room);
        }

        // POST: Rooms1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoomID,FloorNumber,RoomNumber,NumberOfBeds,Capacity,Name,Description,Price,RoomTypeID,RoomStatusID,RoomOverviewID")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomStatusID = new SelectList(db.RoomStatus, "RoomStatusID", "RoomStatusName", room.RoomStatusID);
            ViewBag.RoomTypeID = new SelectList(db.RoomType, "RoomTypeID", "Name", room.RoomTypeID);
            return View(room);
        }

        // GET: Rooms1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Room.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Rooms1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Room.Find(id);
            db.Room.Remove(room);
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
