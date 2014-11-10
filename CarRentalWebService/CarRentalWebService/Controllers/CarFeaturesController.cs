using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarRentalWebService.Models;

namespace CarRentalWebService.Controllers
{
    public class CarFeaturesController : Controller
    {
        private DbContextModel db = new DbContextModel();

        // GET: CarFeatures
        public ActionResult Index()
        {
            return View(db.CarFeatures.ToList());
        }

        // GET: CarFeatures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarFeature carFeature = db.CarFeatures.Find(id);
            if (carFeature == null)
            {
                return HttpNotFound();
            }
            return View(carFeature);
        }

        // GET: CarFeatures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarFeatures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] CarFeature carFeature)
        {
            if (ModelState.IsValid)
            {
                db.CarFeatures.Add(carFeature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carFeature);
        }

        // GET: CarFeatures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarFeature carFeature = db.CarFeatures.Find(id);
            if (carFeature == null)
            {
                return HttpNotFound();
            }
            return View(carFeature);
        }

        // POST: CarFeatures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] CarFeature carFeature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carFeature).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carFeature);
        }

        // GET: CarFeatures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarFeature carFeature = db.CarFeatures.Find(id);
            if (carFeature == null)
            {
                return HttpNotFound();
            }
            return View(carFeature);
        }

        // POST: CarFeatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarFeature carFeature = db.CarFeatures.Find(id);
            db.CarFeatures.Remove(carFeature);
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
