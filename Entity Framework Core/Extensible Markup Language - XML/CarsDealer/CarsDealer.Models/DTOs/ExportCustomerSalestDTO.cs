using System.Xml.Serialization;

namespace CarsDealer.Models.DTOs
{
    [XmlType("customers")]
    public class ExportCustomerSalestDTO
    {
        [XmlElement("full-name")]
        public string FullName { get; set; }
        [XmlElement("bought-cars")]
        public int BoughtCars { get; set; }
        [XmlElement("spent-money")]
        public decimal SpentMoney { get; set; }
    }
}
