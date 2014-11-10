using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarRentalWebService.Models;
using System.Collections;

namespace CarRentalWebService.Controllers
{
    public class RequestsController : Controller
    {
        private DbContextModel db = new DbContextModel();

        private List<SelectListItem> states = new List<SelectListItem>
            {
                new SelectListItem {Value = "0", Text = "Pending"},
                new SelectListItem {Value = "1", Text = "Paid"}
            };

        // GET: Requests
        public ActionResult Index()
        {
            var requests = db.Requests.Include(r => r.City).Include(r => r.Model);
            return View(requests.ToList());
        }

        // GET: Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            ViewBag.State = new SelectList(states,"Value", "Text");
            ViewBag.City_Id = new SelectList(db.Cities, "Id", "Name");
            ViewBag.Model_Id = new SelectList(db.CarModels, "Id", "Name");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Phone,FromDate,ToDate,PriceTotal,State,Model_Id,City_Id")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.State = new SelectList(states, request.State);
            ViewBag.City_Id = new SelectList(db.Cities, "Id", "Name", request.City_Id);
            ViewBag.Model_Id = new SelectList(db.CarModels, "Id", "Name", request.Model_Id);
            return View(request);
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }

            ViewBag.State = new SelectList(states, "Value", "Text");
            ViewBag.City_Id = new SelectList(db.Cities, "Id", "Name", request.City_Id);
            ViewBag.Model_Id = new SelectList(db.CarModels, "Id", "Name", request.Model_Id);
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Phone,FromDate,ToDate,PriceTotal,State,Model_Id,City_Id")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.State = new SelectList(states, "Value", "Text");
            ViewBag.City_Id = new SelectList(db.Cities, "Id", "Name", request.City_Id);
            ViewBag.Model_Id = new SelectList(db.CarModels, "Id", "Name", request.Model_Id);
            return View(request);
        }

        // GET: Requests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
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
