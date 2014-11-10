using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalWebService.Models
{
    public class Request
    {
        public Request()
        {
            State = 0;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? FromDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ToDate { get; set; }

        public int PriceTotal { get; set; }
        public int State { get; set; }

        [ForeignKey("Model")]
        public int Model_Id { get; set; }

        [ForeignKey("City")]
        public int City_Id { get; set; }

        public virtual CarModel Model { get; set; }
        public virtual City City { get; set; }
    }

    //public enum State
    //{
    //    Pending, Paid
    //}
}