﻿namespace CarsDealer.Models
{
    public class Sale
    {
        public Sale()
        {
        }

        public int Id { get; set; }
        public int Discount { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
