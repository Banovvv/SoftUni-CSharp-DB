using System;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {

        }

        public int Id { get; set; }
        // (up to 100 characters, unicode)
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        // (exactly 10 characters, not unicode, not required)
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime RegisteredOn { get; set; }
        // (not required)
        public DateTime? Birthday { get; set; }
    }
}
