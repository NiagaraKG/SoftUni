using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using XmlFacade;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using ProductShopContext context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            ////var userXml = File.ReadAllText("../../../Datasets/users.xml");
            ////var productXml = File.ReadAllText("../../../Datasets/products.xml");
            ////var categoryXml = File.ReadAllText("../../../Datasets/categories.xml");
            //var categoryProductXml = File.ReadAllText("../../../Datasets/categories-products.xml");

            ////ImportUsers(context, userXml);
            ////ImportProducts(context, productXml);
            ////ImportCategories(context, categoryXml);
            //var result = ImportCategoryProducts(context, categoryProductXml);
            //Console.WriteLine(result);

            //var productsInRange = GetProductsInRange(context);
            //File.WriteAllText("../../../results/productsInRange.xml", productsInRange);

            //var soldProducts = GetSoldProducts(context);
            //File.WriteAllText("../../../results/soldProducts.xml", soldProducts); 

            //var categoriesByProductsCount = GetCategoriesByProductsCount(context);
            //File.WriteAllText("../../../results/categoriesByProductsCount.xml", categoriesByProductsCount);
            
            var result = GetUsersWithProducts(context);
            File.WriteAllText("../../../results/result.xml", result);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Users";
            var usersResult = XMLConverter.Deserializer<ImportUserDto>(inputXml, rootElement);

            //List<User> users = new List<User>();
            //foreach (var importUserDto in usersResult)
            //{
            //    var user = new User()
            //    {
            //        FirstName = importUserDto.FirstName,
            //        LastName = importUserDto.LastName,
            //        Age = importUserDto.Age
            //    };
            //    users.Add(user);
            //}
            var users = usersResult
                .Select(u => new User
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age
                })
                .ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();
            //return $"Successfully imported {users.Count}";
            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Products";
            var productsDto = XMLConverter.Deserializer<ImportProductDto>(inputXml, rootElement);

            //var products = new List<Product>();

            //foreach (var productDto in productsDto)
            //{
            //    if (!context.Users.Any(x => x.Id == productDto.SellerId && x.Id == productDto.BuyerId))
            //    {
            //        continue;
            //    }

            //    var product = new Product
            //    {
            //        Name = productDto.Name,
            //        Price = productDto.Price,
            //        SellerId = productDto.SellerId,
            //        BuyerId = productDto.BuyerId
            //    };
            //    products.Add(product);
            //}
            var products = productsDto.Select(p => new Product
            {
                Name = p.Name,
                Price = p.Price,
                SellerId = p.SellerId,
                BuyerId = p.BuyerId
            })
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
            // return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Categories";
            var categoriesDto = XMLConverter.Deserializer<ImportCategoryDto>(inputXml, rootElement);

            var categories = categoriesDto
                .Where(c => c.Name != null)
                .Select(p => new Category
                {
                    Name = p.Name
                })
                .ToArray();
            //List<Category> categories = new List<Category>();

            //foreach (var dto in categoriesDto)
            //{
            //    if (dto.Name == null)
            //    {
            //        continue;
            //    }

            //    var category = new Category
            //    {
            //        Name = dto.Name
            //    };
            //    categories.Add(category);
            //}
            context.Categories.AddRange(categories);
            context.SaveChanges();

            //return $"Successfully imported {categories.Count}";
            return $"Successfully imported {categories.Length}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "CategoryProducts";
            var categoryProductDtos =
                XMLConverter
                .Deserializer<ImportCategoryProductDto>(inputXml, rootElement);

            var categories = categoryProductDtos
                .Where(i =>
                    context.Categories.Any(s => s.Id == i.CategoryId) &&
                    context.Products.Any(s => s.Id == i.ProductId))
                .Select(c => new CategoryProduct()
                {
                    CategoryId = c.CategoryId,
                    ProductId = c.ProductId
                })
                .ToArray();

            //var categories = new List<CategoryProduct>();

            //foreach (var categoryProductDto in categoryProductDtos)
            //{
            //    var isExists = context.Products.Any(x => x.Id == categoryProductDto.ProductId) &&
            //                   context.Categories.Any(x => x.Id == categoryProductDto.CategoryId);
            //    if (!isExists)
            //    {
            //        continue;
            //    }

            //    var categoryProduct = new CategoryProduct
            //    {
            //        CategoryId = categoryProductDto.CategoryId,
            //        ProductId = categoryProductDto.ProductId
            //    };
            //    categories.Add(categoryProduct);
            //}

            context.CategoryProducts.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
            //return $"Successfully imported {categories.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            const string rootElement = "Products";
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(x => new ExportProductInfoDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToList();

            var result = XMLConverter.Serialize(products, rootElement);
            return result;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            const string rootElemet = "Users";

            var usersWithProducts = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .Select(x => new ExportUserSoldProductDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(p => new UserProductDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                        .ToArray()
                })
                .OrderBy(l => l.LastName)
                .ThenBy(f => f.FirstName)
                .Take(5)
                .ToArray();
            var result = XMLConverter.Serialize(usersWithProducts, rootElemet);

            return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string rootElement = "Categories";

            var categories = context
                .Categories
                .Select(c => new ExportCategoryDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price),
                    //TotalRevenue = c.CategoryProducts.Select(x => x.Product).Sum(p => p.Price),
                    AveragePrice = c.CategoryProducts.Average(p => p.Product.Price)
                    //AveragePrice = c.CategoryProducts.Select(x => x.Product).Average(p => p.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(t => t.TotalRevenue).ToArray();

            var result = XMLConverter.Serialize(categories, rootElement);
            return result;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersAndproducts = context
                .Users
                .ToArray()
                .Where(p => p.ProductsSold.Any())
                .Select(u => new ExportUserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProduct = new ExportProductCountDto
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(p => new ExportProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                    }
                })
                .OrderByDescending(x => x.SoldProduct.Count)
                .Take(10)
                .ToArray();

            var resultDto = new ExportUserCountDto
            {
                Count =context.Users.Count(p=>p.ProductsSold.Any()),
                Users = usersAndproducts
            };

            var result = XMLConverter.Serialize(resultDto,"Users");

            return result;
        }
    }
}