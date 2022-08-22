using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarsDealer.Models
{
    public class Customer
    {
        public Customer()
        {
            BoughtCars = new HashSet<Sale>();
        }

        public int Id { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("birthDate")]
        public DateTime BirthDate { get; set; }
        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }

        [XmlIgnore]
        public virtual ICollection<Sale> BoughtCars { get; set; }
    }
}
