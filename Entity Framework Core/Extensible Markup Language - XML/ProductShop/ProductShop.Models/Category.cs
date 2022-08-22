using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProductShop.Models
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        [Required]
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlIgnore]
        public virtual ICollection<Product> Products { get; }
    }
}
