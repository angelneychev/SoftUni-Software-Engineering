using BookShop.Data.Models;
using BookShop.Data.Models.Enums;
using BookShop.DataProcessor.ImportDto;

namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportBooksDto[]), new XmlRootAttribute("Books"));

            var booksDto = (ImportBooksDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Book> books = new List<Book>();
            StringBuilder sb = new StringBuilder();

            foreach (var dto in booksDto)
            {

             //   bool isValidGenre = Enum.IsDefined(typeof(Genre), dto.Genre);
                //  var genre = Enum.Parse<Genre>(dto.Genre);
              //    var validGenre = IsValid(Enum.(typeof(Genre), dto.Genre) == true);
                //  var isValidEnum = Enum.TryParse(typeof(Genre), dto.Genre, out object genre);
                //if (!IsValid(dto) || Enum.TryParse<Genre>(dto.Genre) != Genre.Biography  || Enum.TryParse<Genre>(dto.Genre) != Genre.Business || Enum.TryParse<Genre>(dto.Genre) != Genre.Science)

                var genre = Enum.TryParse(dto.Genre, out Genre genreValid);
                if (!IsValid(dto) || !genre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var book = new Book
                {
                    Name = dto.Name,
                    Genre = genreValid,
                    Price = dto.Price,
                    Pages = dto.Pages,
                    PublishedOn = DateTime.ParseExact(dto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture)
                };
                books.Add(book);
                //Successfully imported book {bookName} for {bookPrice}.
                sb.AppendLine(String.Format(SuccessfullyImportedBook, book.Name, book.Price.ToString("F2")));
            }

            context.Books.AddRange(books);
            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorsDto = JsonConvert.DeserializeObject<ImportAuthorsDto[]>(jsonString);
            List<Author> authors = new List<Author>();

            StringBuilder sb = new StringBuilder();

            foreach (var dto in authorsDto)
            {
                var validAuthor = authors.All(x => x.Email == dto.Email);

                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!validAuthor)
                {
                    continue;
                }
                var author = new Author
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Phone = dto.Phone,
                    Email = dto.Email,
                };

                foreach (var bookDto in dto.Books)
                {
                    var validBook = context.Books.Find(bookDto.BookId);

                    if (validBook != null)
                    {
                        continue;
                    }
                    var authorBook = new AuthorBook
                    {
                        AuthorId = bookDto.BookId
                    };
                }

                var validAutorBook = authors.Count;

                if (validAutorBook <=0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                authors.Add(author);
            }
            context.Authors.AddRange(authors);
            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}