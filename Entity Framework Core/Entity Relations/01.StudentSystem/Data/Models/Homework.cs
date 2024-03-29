﻿using _01.StudentSystem.Data.Models.Enum;
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
        public DateTime SubmissionTime { get; set; }
        public int ContentTypeId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public ContentType ContentType { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
