using AutoMapper;
using Newtonsoft.Json;
using ProductsShop.Data;
using ProductsShop.Initializer;
using ProductsShop.Models;
using ProductsShop.Models.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ProductsShop
{
    public class Program
    {
        private const string DatasetsDirectoryPath = "../../../Datasets";
        private const string ResultsDirectoryPath = "../../../Datasets/Results";

        static void Main(string[] args)
        {
            using (var context = new ProductsShopContext())
            {
                //DbInitializer.Initialize(context);

                var inputJson = File.ReadAllText($"{DatasetsDirectoryPath}/users.json");
                ImportUsers(context, inputJson);
            }
        }

        public static string ImportUsers(ProductsShopContext context, string inputJson)
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var usersDTO = JsonConvert.DeserializeObject<List<UserDTO>>(inputJson, serializerSettings);

            //var users = usersDTO
            //    .Select(udto => Mapper.Map<User>(udto))
            //    .ToList();

            //context.Users.AddRange(users);

            //context.SaveChanges();

            return $"Successfully imported {usersDTO.Count}";
        }
    }
}
