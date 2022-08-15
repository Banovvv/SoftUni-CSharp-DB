using System.Collections.Generic;

namespace ProductsShop.Models
{
    public class User
    {
        public User()
        {
            ProductBought = new HashSet<Product>();
            ProductSold = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }

        public virtual ICollection<Product> ProductBought { get; set; }
        public virtual ICollection<Product> ProductSold { get; }
    }
}
