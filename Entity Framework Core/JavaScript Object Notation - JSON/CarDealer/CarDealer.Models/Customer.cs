using System;
using System.Collections.Generic;

namespace CarDealer.Models
{
    public class Customer
    {
        public Customer()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsYoungDriver { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
