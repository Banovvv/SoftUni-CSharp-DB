using System.Collections.Generic;

namespace BookShopSystem.Models
{
    public class Category
    {
        public Category()
        {
            CategoryBooks = new HashSet<BookCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BookCategory> CategoryBooks { get; set; }
    }
}
