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
    public class SpaPromotionsController : BaseController
    {
        // GET: SpaPromotions
        public ActionResult Index()
        {
            var spaPromotion = db.SpaPromotion.Include(s => s.PromotionCategory);
            return View(spaPromotion.ToList());
        }

        // GET: SpaPromotions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpaPromotion spaPromotion = db.SpaPromotion.Find(id);
            if (spaPromotion == null)
            {
                return HttpNotFound();
            }
            return View(spaPromotion);
        }

        // GET: SpaPromotions/Create
        public ActionResult Create()
        {
            ViewBag.PromotionCategoryID = new SelectList(db.PromotionCategory, "PromotionCategoryID", "PromotionName");
            return View();
        }

        // POST: SpaPromotions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpaPromotionID,Title,Description,StartDate,EndDate,SpaOverviewID,PromotionCategoryID")] SpaPromotion spaPromotion)
        {
            if (ModelState.IsValid)
            {
                db.SpaPromotion.Add(spaPromotion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PromotionCategoryID = new SelectList(db.PromotionCategory, "PromotionCategoryID", "PromotionName", spaPromotion.PromotionCategoryID);
            return View(spaPromotion);
        }

        // GET: SpaPromotions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpaPromotion spaPromotion = db.SpaPromotion.Find(id);
            if (spaPromotion == null)
            {
                return HttpNotFound();
            }
            ViewBag.PromotionCategoryID = new SelectList(db.PromotionCategory, "PromotionCategoryID", "PromotionName", spaPromotion.PromotionCategoryID);
            return View(spaPromotion);
        }

        // POST: SpaPromotions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpaPromotionID,Title,Description,StartDate,EndDate,SpaOverviewID,PromotionCategoryID")] SpaPromotion spaPromotion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spaPromotion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PromotionCategoryID = new SelectList(db.PromotionCategory, "PromotionCategoryID", "PromotionName", spaPromotion.PromotionCategoryID);
            return View(spaPromotion);
        }

        // GET: SpaPromotions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpaPromotion spaPromotion = db.SpaPromotion.Find(id);
            if (spaPromotion == null)
            {
                return HttpNotFound();
            }
            return View(spaPromotion);
        }

        // POST: SpaPromotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpaPromotion spaPromotion = db.SpaPromotion.Find(id);
            db.SpaPromotion.Remove(spaPromotion);
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
