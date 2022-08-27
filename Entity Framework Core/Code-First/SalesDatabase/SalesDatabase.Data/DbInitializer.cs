using SalesDatabase.Models;
using System;
using System.Collections.Generic;

namespace SalesDatabase.Data
{
    public static class DbInitializer
    {
        private static readonly Random _random = new Random();

        public static void Seed(SalesDataContext context)
        {
            IList<Customer> customers = new List<Customer>();
            IList<Product> products = new List<Product>();
            IList<Store> stores = new List<Store>();
            IList<Sale> sales = new List<Sale>();

            for (int i = 0; i < 100; i++)
            {
                customers.Add(
                    new Customer()
                    {
                        Name = GenerateName(_random.Next(4, 11)),
                        Email = $"{GenerateName(_random.Next(4, 11))}@{GenerateName(_random.Next(4, 11))}.com".ToLower(),
                        CreditCardNumber = GenerateCreditCardNumber()
                    });

                products.Add(
                    new Product()
                    {
                        Name = GenerateName(_random.Next(4, 11)),
                        Quantity = _random.Next(1, 100),
                        Price = decimal.Parse($"{_random.Next(1, 100)}.{_random.Next(1, 100)}"),
                        Description = "No description"
                    });

                stores.Add(
                    new Store()
                    {
                        Name = GenerateName(_random.Next(4, 11))
                    });
            }

            for (int i = 0; i < 100; i++)
            {
                sales.Add(
                    new Sale
                    {
                        Date = DateTime.Now.AddDays(-_random.Next(4, 11)),
                        Product = products[_random.Next(0, 100)],
                        Customer = customers[_random.Next(0, 100)],
                        Store = stores[_random.Next(0, 100)]
                    });
            }

            context.Products.AddRange(products);
            context.Customers.AddRange(customers);
            context.Stores.AddRange(stores);
            context.Sales.AddRange(sales);

            context.SaveChanges();

            Console.WriteLine("Database successfully seeded!");
        }

        private static string GenerateName(int desiredLenght)
        {
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "y" };

            string name = string.Empty;

            name += consonants[_random.Next(consonants.Length)].ToUpper();
            name += vowels[_random.Next(vowels.Length)];

            int currentLenght = 2;

            while (currentLenght < desiredLenght)
            {
                name += consonants[_random.Next(consonants.Length)];
                currentLenght++;

                name += vowels[_random.Next(vowels.Length)];
                currentLenght++;
            }

            return name;
        }

        private static string GenerateCreditCardNumber()
        {
            string creditCardNumnber = string.Empty;

            for (int i = 0; i < 10; i++)
            {
                creditCardNumnber += _random.Next(0, 10);
            }

            return creditCardNumnber;
        }
    }
}
