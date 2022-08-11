using BookShopSystem.Models.Enums;
using System;
using System.Collections.Generic;

namespace BookShopSystem.Models
{
    public class Book
    {
        public Book()
        {
            BookCategories = new HashSet<BookCategory>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int Copies { get; set; }
        public decimal Price { get; set; }

        public EditionType EditionType { get; set; }
        public AgeRestriction AgeRestriction { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}
