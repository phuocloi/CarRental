using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalWebService.Models
{
    public class CarFeature
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<CarModel> CarModels { get; set; }
    }
}