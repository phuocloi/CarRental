using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;

namespace CarRentalWebClient.Controllers
{
    public class SiteController : Controller
    {
        private Uri Root = new Uri("http://localhost:1499/Services/DataService.svc");
        public CarRentalServiceReference.DbContextModel Db = new CarRentalServiceReference.DbContextModel(new Uri("http://localhost:1499/Services/DataService.svc"));
    }
}