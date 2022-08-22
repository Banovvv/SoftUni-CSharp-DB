using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.Models.DTOs
{
    [XmlType("User")]
    public class UsersAndProductsDTO
    {
        [XmlElement("firstName")]
        public string FisrtName { get; set; }
        [XmlElement("lastName")]
        public string LastName { get; set; }
        [XmlElement("age")]
        public int? Age { get; set; }
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("soldProducts")]
        public List<ProductSoldDTO> SoldProducts { get; set; }
    }
}
