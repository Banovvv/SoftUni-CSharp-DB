using System.Xml.Serialization;

namespace CarsDealer.Models.DTOs
{
    public class ExportCarWithDistanceDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }
        [XmlElement("model")]
        public string Model { get; set; }
        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
