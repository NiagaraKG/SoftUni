using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DataTransferObjects;
using ProductShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string inputUsers = File.ReadAllText("../../../Datasets/users.json");
            string inputProducts = File.ReadAllText("../../../Datasets/products.json");
            string inputCategories = File.ReadAllText("../../../Datasets/categories.json");
            string inputCategoriesProducts = File.ReadAllText("../../../Datasets/categories-products.json");
            ImportUsers(context, inputUsers);
            ImportProducts(context, inputProducts);
            ImportCategories(context, inputCategories);
            ImportCategoryProducts(context, inputCategoriesProducts);
            var result = GetUsersWithProducts(context);
            Console.WriteLine(result);
        }

        private static void InitliazeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            { cfg.AddProfile<ProductShopProfile>(); });
            mapper = config.CreateMapper();
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitliazeAutomapper();
            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);
            var users = mapper.Map<IEnumerable<User>>(dtoUsers);
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitliazeAutomapper();
            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);
            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);
            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitliazeAutomapper();
            var dtoCategories = JsonConvert.DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson).Where(x => x.Name != null).ToList();
            var categories = mapper.Map<IEnumerable<Category>>(dtoCategories);
            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitliazeAutomapper();
            var dtoCategoriesProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProductInputModel>>(inputJson);
            var categoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoriesProducts);
            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();
            return $"Successfully imported {categoriesProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products.Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(product => new
                {
                    name = product.Name,
                    price = product.Price,
                    seller = product.Seller.FirstName + " " + product.Seller.LastName
                }).OrderBy(x => x.price).ToArray();
            var result = JsonConvert.SerializeObject(products);
            return result;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithSoldItem = context.Users.Where(u => u.ProductsSold.Any(ps => ps.Buyer != null)).Select(u => new
            {
                firstName = u.FirstName,
                lastName = u.LastName,
                soldProducts = u.ProductsSold
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    buyerFirstName = p.Buyer.FirstName,
                    buyerLastName = p.Buyer.LastName
                })

            }).OrderBy(u => u.lastName).ThenBy(u => u.firstName).ToList();
            var result = JsonConvert.SerializeObject(usersWithSoldItem);
            return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories.Select(c => new
            {
                category = c.Name,
                productsCount = c.CategoryProducts.Count(),
                averagePrice = $"{c.CategoryProducts.Average(p => p.Product.Price):f2}",
                totalRevenue = $"{c.CategoryProducts.Sum(p => p.Product.Price):f2}"
            }).OrderByDescending(c => c.productsCount).ToList();
            var result = JsonConvert.SerializeObject(categories);
            return result;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users.Include(x=>x.ProductsSold).ToList().Where(u => u.ProductsSold.Any(b => b.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Where(x => x.BuyerId != null).Count(),
                        products = u.ProductsSold.Where(x => x.BuyerId != null)
                        .Select(p => new { name = p.Name, price = p.Price })
                    }
                }).OrderByDescending(p => p.soldProducts.products.Count()).ToList();
            var resultObject = new
            {
                usersCount = users.Count(),
                users = users
            };
            var jsonSerializerSettings = new JsonSerializerSettings
            { NullValueHandling = NullValueHandling.Ignore };
            var result = JsonConvert.SerializeObject(resultObject, jsonSerializerSettings);
            return result;
        }
    }
}