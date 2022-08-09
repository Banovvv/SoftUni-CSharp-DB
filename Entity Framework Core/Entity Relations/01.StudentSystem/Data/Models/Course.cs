using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            StudentsEnrolled = new HashSet<StudentCourse>();
            Resources = new HashSet<Resource>();
            HomeworkSubmissions = new HashSet<Homework>();
        }

        public int Id { get; set; }
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

        public virtual ICollection<StudentCourse> StudentsEnrolled { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}
