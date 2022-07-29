using System;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {

        }

        public int StudentId { get; set; }
        // (up to 100 characters, unicode)
        public string Name { get; set; }
        // (exactly 10 characters, not unicode, not required)
        public string PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        // (not required)
        public DateTime Birthday { get; set; }
    }
}
