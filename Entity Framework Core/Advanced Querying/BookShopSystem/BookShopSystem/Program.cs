using BookShopSystem.Data;
using BookShopSystem.Initializer;
using BookShopSystem.Models.Enums;
using System;
using System.Linq;
using System.Text;

namespace BookShopSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(context);

                // 2. Age Restriction
                //Console.WriteLine(GetBooksByAgeRestriction(context, "miNor"));

                // 3. Golden Books
                //Console.WriteLine(GetGoldenBooks(context));

                // 4. Books by Price
                //Console.WriteLine(GetBooksByPrice(context));

                // 5. Not Released in
                //Console.WriteLine(GetBooksNotReleasedIn(context, 2000));

                // 6. Book Titles by Category
                //Console.WriteLine(GetBooksByCategory(context, "horror mystery drama"));

                // 7. Released Before Date
                //Console.WriteLine(GetBooksReleasedBefore(context, "12-04-1992"));

                // 8. Author Search
                //Console.WriteLine(GetAuthorNamesEndingIn(context, "e"));

                // 9. Book Search
                //Console.WriteLine(GetBookTitlesContaining(context, "sK"));

                // 10. Book Search by Author
                //Console.WriteLine(GetBooksByAuthor(context, "R"));

                // 11. Count Books
                //Console.WriteLine(CountBooks(context, 12));

                // 12. Total Book Copies
                //Console.WriteLine(CountCopiesByAuthor(context));

                // 13. Profit by Category
                //Console.WriteLine(GetTotalProfitByCategory(context));

                // 14. Most Recent Books
                //Console.WriteLine(GetMostRecentBooks(context));

                // 15. Increase Prices
                IncreasePrices(context);
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

            foreach (var book in books)
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
                .OrderByDescending(x => x.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().Trim();
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year = 0)
        {
            if (year == 0)
            {
                year = int.Parse(Console.ReadLine());
            }

            var books = context.Books.Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.Id)
                .Select(x => x.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }
        public static string GetBooksByCategory(BookShopContext context, string input = null)
        {
            if (input == null)
            {
                input = Console.ReadLine();
            }

            var categories = input.ToLower().Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var books = context.BooksCategories
                .Where(x => categories.Contains(x.Category.Name.ToLower()))
                .Select(x => x.Book.Title)
                .OrderBy(x => x)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date = null)
        {
            if (date == null)
            {
                date = Console.ReadLine();
            }

            var dateTime = DateTime.Parse(date);

            var books = context.Books.Where(x => x.ReleaseDate < dateTime)
                    .OrderByDescending(x => x.ReleaseDate)
                    .Select(x => new
                    {
                        Title = x.Title,
                        Edition = x.EditionType.ToString(),
                        Price = x.Price
                    })
                    .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.Edition} - ${book.Price:F2}");
            }

            return sb.ToString().Trim();
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input = null)
        {
            if (input == null)
            {
                input = Console.ReadLine();
            }

            var authors = context.Authors.Where(x => x.FirstName.EndsWith(input))
                    .Select(x => new
                    {
                        FullName = x.FirstName + " " + x.LastName
                    })
                    .OrderBy(x => x.FullName)
                    .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine(author.FullName);
            }

            return sb.ToString().Trim();
        }
        public static string GetBookTitlesContaining(BookShopContext context, string input = null)
        {
            if (input == null)
            {
                input = Console.ReadLine();
            }

            var books = context.Books.Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }
        public static string GetBooksByAuthor(BookShopContext context, string input = null)
        {
            if (input == null)
            {
                input = Console.ReadLine();
            }

            var books = context.Books.Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.Id)
                .Select(x => new
                {
                    Title = x.Title,
                    Author = x.Author.FirstName + " " + x.Author.LastName
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.Author})");
            }

            return sb.ToString().Trim();
        }
        public static int CountBooks(BookShopContext context, int lengthCheck = 0)
        {
            if (lengthCheck == 0)
            {
                lengthCheck = int.Parse(Console.ReadLine());
            }

            return context.Books.Count(x => x.Title.Length > lengthCheck);
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    Name = x.FirstName + " " + x.LastName,
                    BookCopies = x.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(x => x.BookCopies)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.Name}  - {author.BookCopies}");
            }

            return sb.ToString().Trim();
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    Name = x.Name,
                    TotalProfit = x.CategoryBooks
                        .Select(b => b.Book.Price * b.Book.Copies)
                        .Sum()
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.TotalProfit:F2}");
            }

            return sb.ToString().Trim();
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    Name = c.Name,
                    Books = c.CategoryBooks
                                .OrderByDescending(b => b.Book.ReleaseDate)
                                .Take(3)
                                .Select(b => new
                                {
                                    Title = b.Book.Title,
                                    ReleaseDate = b.Book.ReleaseDate
                                })
                                .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().Trim();
        }
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(x => x.ReleaseDate.Value.Year < 2010).ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }
    }
}
