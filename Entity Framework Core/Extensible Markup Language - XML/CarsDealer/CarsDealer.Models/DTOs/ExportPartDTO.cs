using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarsDealer.Models.DTOs
{
    [XmlType("part")]
    public class ExportPartDTO
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
