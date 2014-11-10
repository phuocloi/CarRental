using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRentalWebClient.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            CarRentalServiceReference.DbContextModel db = new CarRentalServiceReference.DbContextModel();
            ViewBag.Models = db.CarModels.
            return View();
        }
    }
}