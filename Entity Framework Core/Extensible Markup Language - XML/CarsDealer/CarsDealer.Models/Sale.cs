using System.Xml.Serialization;

namespace CarsDealer.Models
{
    public class Sale
    {
        public Sale()
        {
        }

        public int Id { get; set; }
        [XmlElement("discount")]
        public int Discount { get; set; }

        [XmlElement("carId")]
        public int CarId { get; set; }
        [XmlIgnore]
        public virtual Car Car { get; set; }

        [XmlElement("customerId")]
        public int CustomerId { get; set; }
        [XmlIgnore]
        public virtual Customer Customer { get; set; }
    }
}
