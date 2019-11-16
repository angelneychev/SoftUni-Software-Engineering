using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BookShop.Models;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                // DbInitializer.ResetDatabase(db);
                // int input = int.Parse(Console.ReadLine());
                //string input = Console.ReadLine();
                //var result = GetBooksByAgeRestriction(db, "teEN");
                //Console.WriteLine(result);

                // var result = GetGoldenBooks(db);
                // var result = GetBooksByPrice(db);
                //var result = GetBooksNotReleasedIn(db, input);
                //var result = GetBooksByCategory(db, input);
                // var result = GetBooksReleasedBefore(db, "12-04-1992");
                //var result = GetAuthorNamesEndingIn(db, "dy");
                //  var result = GetBookTitlesContaining(db, "sK");
                // var result = GetBooksByAuthor(db, "R");
                // var result = CountBooks(db, 12);
                // var result = CountCopiesByAuthor(db);
                //var result = GetTotalProfitByCategory(db);
                var result = GetMostRecentBooks(db);

                

                Console.WriteLine(result);
            }
        }
        ////1.Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var AgeRestriction = Enum.Parse<AgeRestriction>(command, true);
            StringBuilder sb = new StringBuilder();
            var book = context.Books
                .Select(b => new
                {
                    b.Title,
                    b.AgeRestriction
                })
                .Where(b => b.AgeRestriction == AgeRestriction)
                .OrderBy(b => b.Title)
                .ToList();
            foreach (var b in book)
            {
                sb.AppendLine(b.Title);
            }
         //   var result = string.Join(Environment.NewLine, book);

            return sb.ToString().TrimEnd();
        }
        //2.Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var book = context.Books
                .Select(b=> new
                {
                    b.EditionType,
                    b.Title,
                    b.BookId,
                    b.Copies
                })
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000 )
                .OrderBy(b=>b.BookId)
                .ToList();

            foreach (var b in book)
            {
                sb.AppendLine(b.Title);
            }

            //var result = string.Join(Environment.NewLine, book);

            return sb.ToString().TrimEnd();
        }

        //3.	Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var book = context.Books
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToList();
            foreach (var b in book)
            {
                sb.AppendLine($"{b.Title} - ${b.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        //4.	Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();
            var book = context.Books
                .Select(b => new
                {
                    b.ReleaseDate,
                    b.BookId,
                    b.Title
                })
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .ToList();
           
            foreach (var b in book)
            {
                sb.AppendLine(b.Title);
            }

            return sb.ToString().TrimEnd();
        }
        //5.	Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var bookCategory = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var book = context.Books
                .Where(b => b.BookCategories.Any(c => bookCategory.Contains(c.Category.Name)))
                .Select(t => t.Title)
                .OrderBy(t => t)
                .ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var b in book)
            {
                sb.AppendLine(b);
            }

            return sb.ToString().TrimEnd();
        }
        //6.	Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var book = context.Books
                .Where(d => d.ReleaseDate.Value < targetDate)
                .OrderByDescending(r => r.ReleaseDate.Value)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var b in book)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:f2}");
            }
            return sb.ToString().TrimEnd();
        }
        //7.Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var autor = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    fullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.fullName)
                .ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var a in autor)
            {
                sb.AppendLine(a.fullName);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookSearch = input.ToLower();

            var book = context.Books
                .Where(b => b.Title.ToLower().Contains(bookSearch))
                .Select(b => b.Title)
                .OrderBy(x => x)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var b in book)
            {
                sb.AppendLine(b);
            }

            return sb.ToString().TrimEnd();
        }
        //9.Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(a => EF.Functions.Like(a.Author.LastName, $"{input}%"))
                .OrderBy(a => a.BookId)
                .Select(x => new
                {
                    x.Title,
                    x.Author.FirstName,
                    x.Author.LastName
                });

            string result = string.Join(Environment.NewLine,
                books.Select(x => $"{x.Title} ({x.FirstName} {x.LastName})"));
            return result;
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
           return context.Books
               .Count(t => t.Title.Length > lengthCheck);

        }

        //11.	Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    BooksCount = x.Books.Sum(c => c.Copies)
                })
                .OrderByDescending(b=>b.BooksCount);

            string result = string.Join(Environment.NewLine,
                authors.Select(x => $"{x.FirstName} {x.LastName} - {x.BooksCount}"));
            return result;
        }

        //12.	Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categorys = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    TotalProfit = x.CategoryBooks.Sum(e => e.Book.Price * e.Book.Copies)
                })
                .OrderByDescending(t=>t.TotalProfit)
                .ThenBy(c=>c.CategoryName)
                .ToList();
            string result = string.Join(Environment.NewLine,
                categorys.Select(x => $"{x.CategoryName} ${x.TotalProfit:f2}"));
            return result;
        }

        //13.	Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoriess = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    Books = x.CategoryBooks.Select(e => new
                        {
                            e.Book.Title,
                            e.Book.ReleaseDate
                        })
                        .OrderByDescending(e => e.ReleaseDate)
                        .ToList()
                })
                .OrderBy(c => c.CategoryName)
                .ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var c in categoriess)
            {
                sb.AppendLine($"--{c.CategoryName}");
                foreach (var b in c.Books.Take(3))
                {
                    sb.AppendLine($"{b.Title} ({b.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }
        //14.	Increase Prices

    }
}