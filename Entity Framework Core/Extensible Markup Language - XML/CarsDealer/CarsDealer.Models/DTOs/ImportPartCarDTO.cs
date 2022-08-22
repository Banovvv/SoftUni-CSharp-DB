using System.Xml.Serialization;

namespace CarsDealer.Models.DTOs
{
    [XmlType("partId")]
    public class ImportPartCarDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
