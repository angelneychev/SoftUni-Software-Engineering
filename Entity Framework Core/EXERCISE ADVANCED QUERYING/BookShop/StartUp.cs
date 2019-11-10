using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShop.Models;
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
            }

            string input = Console.ReadLine();
            string result = GetBooksByAgeRestriction(input);
            Console.WriteLine(result);


        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            foreach (var b in books)
            {
                sb.AppendLine(b.Title);
            }

            return sb.ToString().TrimEnd();
        }
        //public static string GetGoldenBooks(BookShopContext context)
        //{
        //    List<Book> books = new List<Book>();
        //    string[] categories = input
        //        .Split (' ', StringSplitOptions.RemoveEmptyEntries)
        //        .Select(c=>c.ToLower)
        //        .ToAr
        //}
    }
}
