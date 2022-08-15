using System;

namespace ProductsShop.Models
{
    public class User
    {
        public User()
        {
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; } 
    }
}
