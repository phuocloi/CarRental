using CarRentalWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRentalWebService.ViewModels;

namespace CarRentalWebService.Controllers
{
    public class DashBoardController : Controller
    {
        private DbContextModel db = new DbContextModel();
        // GET: DashBoard
        public ActionResult Index()
        {
            List<CarModel> carModels = db.CarModels.ToList();
            List<Statistic> statistics = new List<Statistic>();

            foreach (var item in carModels)
            {
                Statistic stat = new Statistic();

                stat.NameCar = item.Name;

                int slthue = db.Requests.Where(r => r.Model_Id == item.Id).Count();

                stat.soluotthue = slthue;

                int sldanhgia = db.Reviews.Where(r => r.Model_Id == item.Id).Count();

                stat.soluotdanhgia = sldanhgia;

                stat.result = "['" + stat.NameCar + "', " + slthue + ", " + sldanhgia + "],";

                statistics.Add(stat);
            }

            ViewBag.Statistics = statistics;

            return View();
        }

        // GET: DashBoard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DashBoard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashBoard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DashBoard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashBoard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DashBoard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashBoard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Top 10 Comment

        public ActionResult _GetTop()
        {
            //var gettop = db.Reviews.LastOrDefault();
            var gettop = (from p in db.Reviews
                          orderby p.Id descending
                          select p).Skip(0).Take(10).ToList();
            return View(gettop);
        }

        public ActionResult GetTopCar()
        {
            //var gettop = db.Reviews.LastOrDefault();
            var gettop = (from p in db.Requests
                          orderby p.Id descending
                          select p).Skip(0).Take(10).ToList();
            return View(gettop);


        }

    }
}
