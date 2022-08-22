using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarsDealer.Models
{
    public class Part
    {
        public Part()
        {
            PartCars = new List<PartCar>();
        }

        public int Id { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }
        [XmlElement("quantity")]
        public int Quantity { get; set; }

        [XmlElement("supplierId")]
        public int SupplierId { get; set; }
        [XmlIgnore]
        public virtual Supplier Supplier { get; set; }

        [XmlIgnore]
        public virtual ICollection<PartCar> PartCars { get; set; }
    }
}
