using System;

namespace SalesDatabase.Models
{
    public class Sale
    {
        public Sale()
        {
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
    }
}
