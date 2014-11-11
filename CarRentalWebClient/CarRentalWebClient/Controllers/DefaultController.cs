using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;

namespace CarRentalWebClient.Controllers
{
    public class DefaultController : SiteController
    {
        // GET: Default
        public ActionResult Index()
        {
            var items = Db.CarModels.ToList();
            List<CarRentalServiceReference.CarModel> results = new List<CarRentalServiceReference.CarModel>();

            foreach (var item in items)
            {
                item.Brand = Db.CarBrands.Where(b => b.Id == item.Brand_Id).Single();
                results.Add(item);
            }

            ViewBag.Models = results;
            return View();
        }
    }
}