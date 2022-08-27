using System.Collections.Generic;

namespace SalesDatabase.Models
{
    public class Product
    {
        public Product()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
