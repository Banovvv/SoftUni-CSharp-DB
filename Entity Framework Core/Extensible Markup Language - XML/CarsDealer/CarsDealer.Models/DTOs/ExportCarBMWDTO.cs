using System.Xml.Serialization;

namespace CarsDealer.Models.DTOs
{
    [XmlType("Car")]
    public class ExportCarBMWDTO
    {
        [XmlElement("id")]
        public int Id { get; set; }
        [XmlElement("model")]
        public string Model { get; set; }
        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
