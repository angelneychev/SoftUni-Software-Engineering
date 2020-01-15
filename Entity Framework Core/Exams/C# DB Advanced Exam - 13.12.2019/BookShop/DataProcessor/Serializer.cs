using BookShop.Data.Models;
using BookShop.DataProcessor.ExportDto;

namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var author = context
                .Authors
                .Select(x => new
                {
                    AuthorName = x.FirstName + " " + x.LastName,

                    Books = x.AuthorsBooks
                        .Select(b=> new
                        {
                            BookName = b.Book.Name,
                            BookPrice = b.Book.Price.ToString("F2")
                        })
                        .OrderByDescending(b=>b.BookPrice)

                })
                .OrderBy(x=>x.Books.Count())
                .ToArray();
            return JsonConvert.SerializeObject(author, Formatting.Indented);
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {



            var book = context.Books
                .ToArray()
                .Where(x => x.PublishedOn < date)
                .Select(x => new ExportBookDto
                {
                    Pages = x.Pages,
                    Name = x.Name,
                    PublishedOn = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture),

                })
                .OrderByDescending(x=>x.Pages)
                .ThenByDescending(x=>x.PublishedOn)
                .Take(10)
                .ToArray();


            var serializer = new XmlSerializer(typeof(ExportBookDto[]),
                new XmlRootAttribute("Books"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), book, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}