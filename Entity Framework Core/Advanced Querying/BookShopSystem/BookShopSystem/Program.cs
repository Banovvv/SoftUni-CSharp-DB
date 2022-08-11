using BookShopSystem.Initializer;
using BookShopSystem.Data;
using System;
using System.Text;
using System.Linq;
using BookShopSystem.Models.Enums;

namespace BookShopSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            using(var context = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(context);

                // 2. Age Restriction
                //Console.WriteLine(GetBooksByAgeRestriction(context, "miNor"));

                // 3. Golden Books
                //Console.WriteLine(GetGoldenBooks(context));

                // 4. Books by Price
                Console.WriteLine(GetBooksByPrice(context));
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string ageGroup = null)
        {
            if (ageGroup == null)
            {
                ageGroup = Console.ReadLine();
            }

            var books = context.Books
                    .ToList()
                    .Where(x => x.AgeRestriction.ToString().Equals(ageGroup, StringComparison.OrdinalIgnoreCase))
                    .Select(x => x.Title)
                    .OrderBy(x => x);

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books.Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .Select(x => x.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach(var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books.Where(x => x.Price >= 40)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .OrderByDescending(x=>x.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();
            
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().Trim();
        }
    }
}
