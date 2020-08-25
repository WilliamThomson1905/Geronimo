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
    public class RoomsController : BaseController
    {
        // GET: Rooms
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


            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index/2" }
            };

            ViewBag.Collection = breadcrumbs;
            return View(currentLocation);            
        }



        public ActionResult RoomSelection(int? Id)
        {
            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index/2" },
                new string []{ "Room Info", "../../Rooms/Index"}
            };
            ViewBag.Collection = breadcrumbs;
            var currentLocation = db.Location.Find(Id);
            ViewBag.LocationID = new SelectList(db.Location, "LocationID", "LocationName");
            ViewBag.RoomTypeID = new SelectList(db.RoomType, "RoomTypeID", "Name");

            return View(currentLocation);
        }


        public ActionResult Availability(int? Id)
        {
            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index/2" },
                new string []{ "Room Info", "../../Rooms/Index"},
                new string []{ "Room Selection", "../../Rooms/RoomSelection"}
            };
            ViewBag.Collection = breadcrumbs;

            var currentLocation = db.Location.Find(Id);

            return View(currentLocation);
        }


        [HttpPost]
        public ActionResult Availability(int LocationId, string roomsCount, string roomTypeId, string startDate, string endDate)
        {
            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index/" + LocationId  },
                new string []{ "Room Info", "../../Rooms/Index/" + LocationId },
                new string []{ "Room Selection", "../../Rooms/RoomSelection/" + LocationId }
            };
            ViewBag.Collection = breadcrumbs;
            var currentLocation = db.Location.Find(LocationId);
            ViewBag.RoomsCount = roomsCount;
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            int roomTypeIdint = int.Parse(roomTypeId);

            var roomType = db.RoomType.Find(roomTypeIdint);
            ViewBag.RoomType = roomType;

            //get rooms for locations which are vacant from a specific location
            ViewBag.Rooms = db.Room.Where(e => e.RoomOverviewID == (LocationId) && e.RoomStatus.RoomStatusName.Equals("vacant")).AsQueryable().ToList();


            // e.RoomStatusID.Equals("vacant")
            return View(currentLocation);
        }



        public ActionResult Payment(int? Id)
        {

            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index" },
                new string []{ "Room Info", "../../Rooms/Index"},
                new string []{ "Room Selection", "../../Rooms/RoomSelection"},
                new string []{ "Availability", "../../Rooms/Availability" }
            };


            ViewBag.Collection = breadcrumbs;

            return View();
        }

        [HttpPost]
        public ActionResult Payment(int[] RoomsSelected)
        {

            breadcrumbs = new string[][] {
                new string [] { "Geronimo Hotel", "../../Hotel/Index" },
                new string []{ "Room Info", "../../Rooms/Index"},
                new string []{ "Room Selection", "../../Rooms/RoomSelection"},
                new string []{ "Availability", "../../Rooms/Availability" }
            };


            ViewBag.Collection = breadcrumbs;

            return View();
        }





        // GET: Rooms1
        public ActionResult AdminIndex()
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
