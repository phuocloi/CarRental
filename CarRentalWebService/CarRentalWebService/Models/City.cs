using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalWebService.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int ZipCode { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}