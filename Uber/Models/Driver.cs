using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Uber.Models
{
    public class Driver : Person
    {
        [Required]
        [StringLength(160, MinimumLength = 2)]
        public string Car { get; set; }

        [DisplayName("Given Rides")]
        public virtual ICollection<Ride> GivenRides { get; set; }
    }
}