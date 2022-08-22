using System.Xml.Serialization;

namespace ProductShop.Models.DTOs
{
    [XmlType("Product")]
    public class ProductSoldDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
