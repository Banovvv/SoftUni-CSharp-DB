using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.Models
{
    public class Product
    {
        public Product()
        {
            Categories = new HashSet<Category>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int SellerId { get; set; }
        public virtual User Seller { get; set; }

        public int? BuyerId { get; set; }
        public virtual User Buyer { get; set; }

        public virtual ICollection<Category> Categories { get; }
    }
}
