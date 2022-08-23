using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarsDealer.Models.DTOs
{
    [XmlType("car")]
    public class ExportCarWithPartsDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }
        [XmlElement("model")]
        public string Model { get; set; }
        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public List<ExportPartDTO> Parts { get; set; }
    }
}
