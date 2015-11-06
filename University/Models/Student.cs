using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University.Models
{
    public class Student : Person
    {
        public int Year { get; set; }
        public string Program { get; set; }

        public virtual ICollection<Professor> Professors { get; set; }
    }
}