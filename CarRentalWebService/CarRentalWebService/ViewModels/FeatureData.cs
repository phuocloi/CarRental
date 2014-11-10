using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalWebService.ViewModels
{
    public class FeatureData
    {
        public int Feature_Id { get; set; }
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }
}