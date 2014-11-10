using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalWebService.Models
{
    public class CarModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        public bool AutoTransmission { get; set; }
        public bool Aircondition { get; set; }
        public int Seats{ get; set; }
        public int Doors { get; set; }
        public int LargeBags { get; set; }
        public int SmallBags { get; set; }

        [Display(Name = "Price per Day")]
        public int PricePerDay { get; set; }

        [Display(Name="Price per Hour")]
        public int PricePerHour { get; set; }

        public int Quantity { get; set; }

        [Required]
        [ForeignKey("Brand")]
        [Display(Name = "Brand")]
        public int Brand_Id { get; set; }

        public virtual CarBrand Brand { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<CarFeature> Features { get; set; }
    }
}