using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.Models.DTOs
{
    [XmlType("User")]
    public class UsersWithSoldProductsDTO
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }
        [XmlElement("lastName")]
        public string LastName { get; set; }
        [XmlArray("soldProducts")]
        public List<ProductSoldDTO> SoldProducts { get; set; }
    }
}
