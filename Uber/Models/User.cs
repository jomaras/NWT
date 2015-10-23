using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Uber.Models
{
    public class User : Person
    {
        [DisplayName("Taken Rides")]
        public virtual ICollection<Ride> TakenRides { get; set; }
    }
}