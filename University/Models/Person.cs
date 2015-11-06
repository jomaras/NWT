using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University.Models
{
    public abstract class Person
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string Fullname { get { return $"{this.Surname} {this.Name}"; } }
    }
}