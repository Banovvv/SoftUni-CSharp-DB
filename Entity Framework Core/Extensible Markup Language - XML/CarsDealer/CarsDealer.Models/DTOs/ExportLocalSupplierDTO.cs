using System.Xml.Serialization;

namespace CarsDealer.Models.DTOs
{
    [XmlType("supplier")]
    public class ExportLocalSupplierDTO
    {
        [XmlElement("id")]
        public int Id { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("parts-count")]
        public int PartsCount { get; set; }
    }
}
