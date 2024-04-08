using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class ParttimeStudent : Student
    {
        public static int MaxNumOfCourses { get; set; }

        // Constructor taking a name parameter and initializing the base class's Name property
        public ParttimeStudent(string name, string type) : base(name, type)
        {
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            // Verifica si el número total de cursos seleccionados excede el límite máximo permitido
            if (selectedCourses.Count > MaxNumOfCourses)
            {
                throw new InvalidOperationException($"Your selection exceeds the maximun number of course: {MaxNumOfCourses}");
            }

            base.RegisterCourses(selectedCourses);
        }

        public override string ToString()
        {
            return $"{Id} - {Name} (Part time)";
        }
    }
}