using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class FulltimeStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }

        // Constructor taking a name parameter and initializing the base class's Name property
        public FulltimeStudent(string name, string type) : base(name, type)
        {
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int totalHours = 0;
            foreach (var course in selectedCourses)
            {
                totalHours += course.WeeklyHours;
            }

            if (totalHours <= MaxWeeklyHours)
            {
                base.RegisterCourses(selectedCourses);
            } else
            {
                throw new InvalidOperationException($"{Type} students cannot exceed {MaxWeeklyHours} hours in a week");
            }
        }

        public override string ToString()
        {
            return $"{Id} - {Name} ({Type})";
        }
    }
}