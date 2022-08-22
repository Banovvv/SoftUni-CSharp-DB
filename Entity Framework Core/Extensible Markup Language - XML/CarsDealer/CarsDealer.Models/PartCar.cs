using System.Xml.Serialization;

namespace CarsDealer.Models
{
    public class PartCar
    {
        [XmlElement("id")]
        public int PartId { get; set; }
        public virtual Part Part { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
