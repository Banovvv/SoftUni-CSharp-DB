using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProductShop.Models
{
    public class User
    {
        public User()
        {
            ProductsBought = new HashSet<Product>();
            ProductsSold = new HashSet<Product>();
        }

        public int Id { get; set; }
        [XmlElement("firstName")]
        public string FirstName { get; set; }
        [Required]
        [XmlElement("lastName")]
        public string LastName { get; set; }
        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlIgnore]
        public virtual ICollection<Product> ProductsBought { get; set; }
        [XmlIgnore]
        public virtual ICollection<Product> ProductsSold { get; set; }
    }
}
