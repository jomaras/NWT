using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Uber.Models
{
    public class Ride
    {
        public int ID { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual Driver Driver { get; set; }

        [Required]
        public String StartLocation { get; set; }

        [Required]
        public String EndLocation { get; set; }

        [Required]
        public float Price { get; set; }

        public int? UserRating { get; set; }
        public int? DriverRating { get; set; }
    }
}