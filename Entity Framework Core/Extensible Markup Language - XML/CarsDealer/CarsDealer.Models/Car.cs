using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarsDealer.Models
{
    public class Car
    {
        public Car()
        {
            CarParts = new HashSet<PartCar>();
        }

        public int Id { get; set; }
        [XmlElement("make")]
        public string Make { get; set; }
        [XmlElement("model")]
        public string Model { get; set; }
        [XmlElement("TravelledDistance")]
        public long TravelledDistance { get; set; }

        [XmlIgnore]
        public ICollection<Sale> Sales { get; set; }
        [XmlArray("parts")]
        public virtual ICollection<PartCar> CarParts { get; set; }
    }
}
