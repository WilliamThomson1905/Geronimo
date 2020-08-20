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
    public class ClassFocusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClassFocus
        public ActionResult Index()
        {
            return View(db.ClassFocus.ToList());
        }

        // GET: ClassFocus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassFocus classFocus = db.ClassFocus.Find(id);
            if (classFocus == null)
            {
                return HttpNotFound();
            }
            return View(classFocus);
        }

        // GET: ClassFocus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassFocus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassFocusID,Title,DisplayTitle")] ClassFocus classFocus)
        {
            if (ModelState.IsValid)
            {
                db.ClassFocus.Add(classFocus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classFocus);
        }

        // GET: ClassFocus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassFocus classFocus = db.ClassFocus.Find(id);
            if (classFocus == null)
            {
                return HttpNotFound();
            }
            return View(classFocus);
        }

        // POST: ClassFocus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassFocusID,Title,DisplayTitle")] ClassFocus classFocus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classFocus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classFocus);
        }

        // GET: ClassFocus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassFocus classFocus = db.ClassFocus.Find(id);
            if (classFocus == null)
            {
                return HttpNotFound();
            }
            return View(classFocus);
        }

        // POST: ClassFocus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassFocus classFocus = db.ClassFocus.Find(id);
            db.ClassFocus.Remove(classFocus);
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
