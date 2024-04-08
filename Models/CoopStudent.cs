using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class CoopStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }
        public static int MaxNumOfCourses { get; set; }

        // Constructor taking a name parameter and initializing the base class's Name property
        public CoopStudent(string name, string type) : base(name, type)
        {
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            // Verifica si el número total de cursos seleccionados excede el límite máximo permitido
            if (selectedCourses.Count > MaxNumOfCourses)
            {
                throw new InvalidOperationException($"Your selection exceeds the maximun number of course: {MaxNumOfCourses}");
            }

            // Verifica si el número total de horas semanales excede el límite máximo permitido
            int totalHours = selectedCourses.Sum(course => course.WeeklyHours);
            if (totalHours > MaxWeeklyHours)
            {
                throw new InvalidOperationException($"Your selection exceeds the maximun weekly hours: {MaxWeeklyHours}");
            }

            // Llama al método RegisterCourses de la clase base para registrar los cursos seleccionados
            base.RegisterCourses(selectedCourses);
        }

        public override string ToString()
        {
            return $"{Id} - {Name} (Coop)";
        }
    }
}