using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarRentalWebService.Models;
using CarRentalWebService.ViewModels;

namespace CarRentalWebService.Controllers
{
    public class CarModelsController : Controller
    {
        private DbContextModel db = new DbContextModel();

        // GET: CarModels
        public ActionResult Index()
        {
            var carModels = db.CarModels.Include(c => c.Brand);
            return View(carModels.ToList());
        }

        // GET: CarModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = db.CarModels.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // GET: CarModels/Create
        public ActionResult Create()
        {
            ViewBag.Brand_Id = new SelectList(db.CarBrands, "Id", "Name");
            return View();
        }

        // POST: CarModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Image,AutoTransmission,Aircondition,Seats,Doors,LargeBags,SmallBags,PricePerDay,PricePerHour,Quantity,Brand_Id")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                db.CarModels.Add(carModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Brand_Id = new SelectList(db.CarBrands, "Id", "Name", carModel.Brand_Id);
            return View(carModel);
        }

        // GET: CarModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CarModel carModel = db.CarModels.Find(id);
            CarModel carModel = db.CarModels
                .Include(m => m.Features)
                .Where(m => m.Id == id)
                .Single();
            PopulatedFeatureData(carModel);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Brand_Id = new SelectList(db.CarBrands, "Id", "Name", carModel.Brand_Id);
            return View(carModel);
        }

        // POST: CarModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Image,AutoTransmission,Aircondition,Seats,Doors,LargeBags,SmallBags,PricePerDay,PricePerHour,Quantity,Brand_Id")] CarModel carModel, string[] selectedFeatures)
        {
            if (ModelState.IsValid)
            {
                // Update feature data
                //UpdateFeatureData(selectedFeatures, carModel);

                db.Entry(carModel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Brand_Id = new SelectList(db.CarBrands, "Id", "Name", carModel.Brand_Id);
            return View(carModel);
        }

        // GET: CarModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = db.CarModels.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // POST: CarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarModel carModel = db.CarModels.Find(id);
            db.CarModels.Remove(carModel);
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

        private void PopulatedFeatureData(CarModel carModel)
        {
            var allFeature = db.CarFeatures;
            var modelFeatures = new HashSet<int>(carModel.Features.Select(f => f.Id));
            var viewModel = new List<FeatureData>();
            foreach (var feature in allFeature)
            {
                viewModel.Add(new FeatureData
                    {
                        Feature_Id = feature.Id,
                        Title = feature.Name,
                        Assigned = modelFeatures.Contains(feature.Id)
                    });
            }
            ViewBag.Features = viewModel;
        }

        private void UpdateFeatureData(string[] selectedFeatures, CarModel carModel)
        {
            if (selectedFeatures == null)
            {
                carModel.Features = new List<CarFeature>();
                return;
            }

            var selectedFeaturesHS = new HashSet<string>(selectedFeatures);
            var features = new HashSet<int>(carModel.Features.Select(f => f.Id));
            foreach (var feature in db.CarFeatures)
            {
                if (selectedFeaturesHS.Contains(feature.Id.ToString()))
                {
                    if (!features.Contains(feature.Id))
                    {
                        carModel.Features.Add(feature);
                    }
                }
                else
                {
                    if (features.Contains(feature.Id))
                    {
                        carModel.Features.Remove(feature);
                    }
                }
            }
        }
    }
}
