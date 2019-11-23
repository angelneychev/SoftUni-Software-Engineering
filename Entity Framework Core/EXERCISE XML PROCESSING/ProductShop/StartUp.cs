using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ProductShopProfile>();

            });

            using (var db = new ProductShopContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();
                // var xmlPath = File.ReadAllText(@"Datasets/parts.xml");
               // var xmlPath = File.ReadAllText(@"./../../../Datasets/categories-products.xml");

                  var result = GetSoldProducts(db);

                   Console.WriteLine(result);
            }
        }

        // 1. Import Data
        // Query 1.Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            var usersDto = (ImportUserDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<User> users = new List<User>();

            foreach (var userDto in usersDto)
            {
                var user = Mapper.Map<User>(userDto);
                users.Add(user);
            }
            context.Users.AddRange(users);

            int count = context.SaveChanges();


            return $"Successfully imported {count}";
        }
        //Query 2. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            var productsDto = (ImportProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var products = Mapper.Map<Product[]>(productsDto);

            context.Products.AddRange(products);

            int count = context.SaveChanges();

            
            return $"Successfully imported {count}";
        }
        //Query 3. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

            var categoriesDto = ((ImportCategoryDto[])xmlSerializer.Deserialize(new StringReader(inputXml)))
                .Where(x=>x.Name != null);

            var categories = Mapper.Map<Category[]>(categoriesDto);

            context.Categories.AddRange(categories);
            
            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }
        //Query 4. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer =
                new XmlSerializer(typeof(ImportCategoriesProductsDto[]),
                    new XmlRootAttribute("CategoryProducts"));

            var categoryProductsDto =
                ((ImportCategoriesProductsDto[])xmlSerializer.Deserialize(new StringReader(inputXml)))
                .ToList();

            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoryProductsDto)
            {
                var targetProduct = context.Products.Find(categoryProductDto.ProductId);
                var targetCategory = context.Categories.Find(categoryProductDto.CategoryId);

                if (targetProduct != null && targetCategory != null)
                {
                    var category = Mapper.Map<CategoryProduct>(categoryProductDto);
                    categoryProducts.Add(category);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            int count = context.SaveChanges();

            return $"Successfully imported {count}";

        }
        //Query 5. Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ExportProductsInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .Take(10)
                .ToArray();

            var xmlSerializer =
                new XmlSerializer(typeof(ExportProductsInRangeDto[]), new XmlRootAttribute("Products"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Query 6. Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportGetSoldProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Products = u.ProductsSold.Select(p => new ExportSoldProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToArray()
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportGetSoldProductsDto[]), new XmlRootAttribute("Users"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }
        //Query 7. Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new ExportCategoriesByProductsCount
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCategoriesByProductsCount[]), new XmlRootAttribute("Categories"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            xmlSerializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }
        //Query 8. Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(p => p.ProductsSold.Count())
                .Select(u => new ExportUsersWithSoldProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductsCountDto
                    {
                        Count = u.ProductsSold.Count(),
                        Products = u.ProductsSold
                            .Select(p => new ExportSoldProductsDto
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            var result = new ExportUsersAndProductsDto
            {
                Count = context.Users.Count(p => p.ProductsSold.Any()),
                Users = users
            };

            var xmlSerializer = new XmlSerializer(typeof(ExportUsersAndProductsDto), new XmlRootAttribute("Users"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            xmlSerializer.Serialize(new StringWriter(sb), result, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}