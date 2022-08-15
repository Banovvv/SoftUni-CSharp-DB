using System.Collections.Generic;

namespace ProductsShop.Models
{
    public class User
    {
        public User()
        {
            ProductsBought = new HashSet<Product>();
            ProductsSold = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }

        public virtual ICollection<Product> ProductsBought { get; set; }
        public virtual ICollection<Product> ProductsSold { get; }
    }
}
