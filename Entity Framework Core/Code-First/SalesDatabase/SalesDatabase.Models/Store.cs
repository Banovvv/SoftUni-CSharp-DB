﻿using System.Collections.Generic;

namespace SalesDatabase.Models
{
    public class Store
    {
        public Store()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
