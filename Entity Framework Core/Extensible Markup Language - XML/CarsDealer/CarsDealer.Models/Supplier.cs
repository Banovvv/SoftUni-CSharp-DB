using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarsDealer.Models
{
    public class Supplier
    {
        public Supplier()
        {
            Parts = new HashSet<Part>();
        }

        public int Id { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }

        [XmlIgnore]
        public virtual ICollection<Part> Parts { get; set; }
    }
}
