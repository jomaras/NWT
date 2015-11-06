using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using University.Models;

namespace University.DAL
{
    public class UniversityContext : DbContext
    {
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}