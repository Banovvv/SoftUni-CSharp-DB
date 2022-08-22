using System.Xml.Serialization;

namespace ProductShop.Models.DTOs
{
    [XmlType("Product")]
    public class ProductsInRangeDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }
        [XmlElement("buyer")]
        public string Buyer { get; set; }

        public bool ShouldSerializeBuyer()
        {
            return !string.IsNullOrWhiteSpace(Buyer);
        }
    }
}
