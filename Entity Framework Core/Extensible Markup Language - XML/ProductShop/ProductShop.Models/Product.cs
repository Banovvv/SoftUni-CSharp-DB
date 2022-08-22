using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProductShop.Models
{
    public class Product
    {
        public Product()
        {
            ProductCategories = new HashSet<CategoryProduct>();
        }

        public int Id { get; set; }
        [Required]
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("sellerId")]
        public int SellerId { get; set; }
        [XmlIgnore]
        public virtual User Seller { get; set; }

        [XmlElement("buyerId")]
        public int? BuyerId { get; set; }
        [XmlIgnore]
        public virtual User Buyer { get; set; }

        [XmlIgnore]
        public virtual ICollection<CategoryProduct> ProductCategories { get; }
    }
}
