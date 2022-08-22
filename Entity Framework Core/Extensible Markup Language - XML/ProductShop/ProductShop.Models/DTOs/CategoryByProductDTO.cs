using System.Xml.Serialization;

namespace ProductShop.Models.DTOs
{
    [XmlType("Category")]
    public class CategoryByProductDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlElement("averagePrice")]
        public decimal AveragePrice { get; set; }
        [XmlElement("totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}
