using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalWebService.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Model")]
        public int Model_Id { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Range(1, 5)]
        public int Stars { get; set; }

        [EmailAddress]
        public string email { get; set; }

        public virtual CarModel Model { get; set; }
    }
}