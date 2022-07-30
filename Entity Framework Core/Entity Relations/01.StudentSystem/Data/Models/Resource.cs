using _01.StudentSystem.Data.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public Resource()
        {

        }

        public int Id { get; set; }
        //  (up to 50 characters, unicode)
        [MaxLength(50)]
        public string Name { get; set; }
        // (not unicode)
        public string Url { get; set; }
        // (enum – can be Video, Presentation, Document or Other)
        public ResourceType ResourceType { get; set; }
        public int CourseId { get; set; }
    }
}
