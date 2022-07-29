using System;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {

        }

        public int CourseId { get; set; }
        // (up to 80 characters, unicode)
        public string Name { get; set; }
        // (unicode, not required)
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
    }
}
