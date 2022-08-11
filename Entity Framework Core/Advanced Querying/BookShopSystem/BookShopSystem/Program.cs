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
                Console.WriteLine(GetBooksByAgeRestriction(context, "miNor"));
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
    }
}
