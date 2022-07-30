using System;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {

        }

        [Required]
        public int CourseId { get; set; }
        // (up to 80 characters, unicode)
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        // (unicode, not required)
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
