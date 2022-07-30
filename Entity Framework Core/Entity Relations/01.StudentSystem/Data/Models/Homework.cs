using System;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        public Homework()
        {

        }

        public int Id { get; set; }
        // (string, linking to a file, not unicode)
        public string Content { get; set; }
        // (enum – can be Application, Pdf or Zip)
        public string ContentType { get; set; }
        public DateTime SubmissionTime { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
