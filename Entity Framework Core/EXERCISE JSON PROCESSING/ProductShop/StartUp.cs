using Microsoft.EntityFrameworkCore.Internal;

namespace ProductShop
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using Dtos.Export;
    using System.Linq;
    using Newtonsoft.Json;
    using Models;
    using Data;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();


            //var userJson = File.ReadAllText(@"C:\CSharp\SoftUni-Software-Engineering\Entity Framework Core\EXERCISE JSON PROCESSING\ProductShop\Datasets\users.json");
            //var result = ImportUsers(context, userJson);
            var productsJson = File.ReadAllText(@"C:\CSharp\SoftUni-Software-Engineering\Entity Framework Core\EXERCISE JSON PROCESSING\ProductShop\Datasets\products.json");
            var result = ImportProducts(context, productsJson);
            //var categoriesJson = File.ReadAllText(@"C:\CSharp\SoftUni-Software-Engineering\Entity Framework Core\EXERCISE JSON PROCESSING\ProductShop\Datasets\categories.json");
            //var result = ImportCategories(context, categoriesJson);
            //var categoryProductsJson = File.ReadAllText(@"C:\CSharp\SoftUni-Software-Engineering\Entity Framework Core\EXERCISE JSON PROCESSING\ProductShop\Datasets\categories-products.json");
            //var result = ImportCategoryProducts(context, categoryProductsJson);

            //Console.WriteLine(GetProductsInRange(context));
            // Console.WriteLine(GetSoldProducts(context));
            // Console.WriteLine(GetCategoriesByProductsCount(context));
            // Console.WriteLine(GetUsersWithProducts(context));

            //Console.WriteLine(result);
        }
        //Query 1. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson)
                .Where(u=>u.LastName != null && u.LastName.Length >=3)
                .ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();
            //var countUsersImportToDatabase = context.SaveChanges();

            return $"Successfully imported {users.Length}"; ;
        }
        //Query 2. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            Product[] products = JsonConvert.DeserializeObject<Product[]>(inputJson)
               .Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.Length>=3 )
                .ToArray();

            context.Products.AddRange(products);
            //context.SaveChanges();
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
        //Query 3. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            Category[] categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(c => !string.IsNullOrEmpty(c.Name))
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Length}";
        }
        //Query 4. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var validCategory = context
                .Categories
                .Select(c => c.Id)
                .ToHashSet();
            var validProductIds = context
                .Products
                .Select(p => p.Id)
                .ToHashSet();

            CategoryProduct[] categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson)
                .ToArray();

            var validEntities = new List<CategoryProduct>();

            foreach (var categoryProduct in categoryProducts)
            {
                bool isValid = validCategory.Contains(categoryProduct.CategoryId) &&
                               validProductIds.Contains(categoryProduct.CategoryId);
                if (!isValid)
                {
                    validEntities.Add(categoryProduct);
                }
            }
            context.CategoryProducts.AddRange(validEntities);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }
        //Query 5. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productInRange = context
                .Products
                .Where(p => p.Price > 500 && p.Price < 1000)
                .Select(p => new ProductDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    //Seller = p.Seller.FirstName == null ? p.Seller.LastName 
                      //  :$"{p.Seller.FirstName} {p.Seller.LastName}"
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .OrderBy(p=>p.Price)
                .ToList();

            var json = JsonConvert.SerializeObject(productInRange, Formatting.Indented);
            return json;
        }
        //Query 6. Export Successfully Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {

            var soldProduct = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                        .ToList()
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName)
                .ToList();
            var json = JsonConvert.SerializeObject(soldProduct, Formatting.Indented);
            return json;
        }
        //Query 7. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductsCount = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = $"{c.CategoryProducts.Average(p => p.Product.Price):f2}",
                    totalRevenue = $"{c.CategoryProducts.Sum(p => p.Product.Price):f2}"
                })
                .OrderByDescending(c => c.productsCount)
                .ToList();
            var json = JsonConvert.SerializeObject(categoriesByProductsCount, Formatting.Indented);
            return json;
        }
        //Query 8. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count(b => b.Buyer != null),
                        products = u.ProductsSold
                            .Where(b => b.Buyer != null)
                            .Select(p => new
                            {
                                name = p.Name,
                                price = p.Price
                            })
                    }
                })
                .ToList();

            var userOutput = new
            {
                usersCount = users.Count,
                users = users
            };
            var json = JsonConvert.SerializeObject(userOutput, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }
    }
}