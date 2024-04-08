using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class Student
    {
        private static Random random = new Random();
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Type {  get; private set; }
        public List<Course> RegisteredCourses { get; set; }

        // Constructor to initialize Name and generate a random 6-digit Id
        public Student(string name, string type)
        {
            Id = GenerateRandomId();
            Name = name;
            RegisteredCourses = new List<Course>();
            Type = type;
        }

        // Method to generate a random 6-digit Id
        private int GenerateRandomId()
        {
            return random.Next(100000, 999999); // Generates a random number between 100000 and 999999
        }

        public virtual void RegisterCourses(List<Course> selectedCourses)
        {            
            RegisteredCourses.Clear(); // Remove all elements in RegisteredCourses
            RegisteredCourses.AddRange(selectedCourses); // Add selectedCourses to RegisteredCourses           
        }

        public int TotalWeeklyHours()
        {
            int totalHours = 0;
            foreach (var course in RegisteredCourses)
            {
                totalHours += course.WeeklyHours;
            }
            return totalHours;
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}