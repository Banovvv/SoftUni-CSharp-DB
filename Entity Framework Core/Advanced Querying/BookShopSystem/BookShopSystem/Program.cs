﻿using BookShopSystem.Data;
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
                Console.WriteLine(GetAuthorNamesEndingIn(context, "e"));
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
    }
}
