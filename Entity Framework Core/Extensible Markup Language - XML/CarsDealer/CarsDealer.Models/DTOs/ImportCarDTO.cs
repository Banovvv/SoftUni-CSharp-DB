﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarsDealer.Models.DTOs
{
    [XmlType("Car")]
    public class ImportCarDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("ТraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public List<ImportPartCarDTO> Parts { get; set; }
    }
}
