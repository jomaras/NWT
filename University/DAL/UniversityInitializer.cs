using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University.Models;

using System.Data.Entity;

namespace University.DAL
{
    public class UniversityInitializer : DropCreateDatabaseAlways<UniversityContext>
    {
        protected override void Seed(UniversityContext context)
        {
            var student1 = new Student() { Name = "Ivo", Surname = "Ivić", Year = 1, Program = "250" };
            var student2 = new Student() { Name = "Mate", Surname = "Matić", Year = 2, Program = "120" };
            var student3 = new Student() { Name = "Mijo", Surname = "Mijić", Year = 3, Program = "220" };
            var student4 = new Student() { Name = "Stipe", Surname = "Stipić", Year = 4, Program = "250" };
            var student5 = new Student() { Name = "Ante", Surname = "Antić", Year = 4, Program = "220" };

            var professor1 = new Professor() { Name = "Ivica", Surname = "Puljak", Department = "Physics", Title = "prof. dr. sc" };
            var professor2 = new Professor() { Name = "Ivan", Surname = "Slapničar", Department = "Math", Title = "prof. dr. sc" };
            var professor3 = new Professor() { Name = "Maja", Surname = "Štula", Department = "Electrical Engineering", Title = "prof. dr. sc" };

            student1.Professors = new List<Professor>() { professor1, professor2 };
            student2.Professors = new List<Professor>() { professor1, professor3 };
            student3.Professors = new List<Professor>() { professor1, professor2, professor3 };
            student4.Professors = new List<Professor>() { professor2, professor3 };
            student5.Professors = new List<Professor>() { professor2, professor3 };

            professor1.Students = new List<Student>() { student1, student2, student3 };
            professor2.Students = new List<Student>() { student1, student3, student4, student5 };
            professor3.Students = new List<Student>() { student2, student3, student4, student5 };

            context.Students.Add(student1);
            context.Students.Add(student2);
            context.Students.Add(student3);
            context.Students.Add(student4);
            context.Students.Add(student5);

            context.Professors.Add(professor1);
            context.Professors.Add(professor2);
            context.Professors.Add(professor3);

            context.SaveChanges();
        }
    }
}