using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University.Models.ViewModel
{
    public class StudentProfessorsViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Professor> Professors { get; set; }
    }
}