using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Cinema.Data.Models;
using Cinema.Data.Models.Enums;
using Cinema.DataProcessor.ImportDto;
using Newtonsoft.Json;

namespace Cinema.DataProcessor
{
    using System;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDtos = JsonConvert.DeserializeObject<ImportMoviesDto[]>(jsonString);

            List<Movie> movies = new List<Movie>();

            StringBuilder sb = new StringBuilder();

            TimeSpan timeSpan;

            foreach (var moviesDto in moviesDtos)
            {

                var isValidTitle = movies.Any(x => x.Title == moviesDto.Title);
                var isValidEnum = Enum.TryParse(typeof(Genre), moviesDto.Genre, out object genre);

                var isValidDuration = TimeSpan.TryParseExact(moviesDto.Duration, @"hh\:mm\:ss", CultureInfo.InvariantCulture, out timeSpan);



                if (!IsValid(moviesDto) || !isValidDuration || isValidTitle)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie
                {
                    Title = moviesDto.Title,
                    Genre = Enum.Parse<Genre>(moviesDto.Genre),
                    Duration = TimeSpan.ParseExact(moviesDto.Duration, @"hh\:mm\:ss", CultureInfo.InvariantCulture),
                    Rating = moviesDto.Rating,
                    Director = moviesDto.Director
                };

                movies.Add(movie);

                sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre, movie.Rating.ToString("F2")));

            }
            context.Movies.AttachRange(movies);
            context.SaveChanges();


            return sb.ToString().TrimEnd();


        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsDtos = JsonConvert.DeserializeObject<ImportHallsDto[]>(jsonString);

            List<Hall> halls = new List<Hall>();

            StringBuilder sb = new StringBuilder();

            foreach (var hallsDto in hallsDtos)
            {

                if (!IsValid(hallsDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallsDto.Name,
                    Is4Dx = hallsDto.Is4Dx,
                    Is3D = hallsDto.Is3D,
                };

                for (int i = 0; i < hallsDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }

                halls.Add(hall);

                var status = string.Empty;

                if (hall.Is3D && hall.Is4Dx)
                {
                    status = "4Dx/3D";
                }
                else if (!hall.Is3D && hall.Is4Dx)
                {
                    status = "4Dx";
                }
                else if (hall.Is3D && !hall.Is4Dx)
                {
                    status = "3D";
                }
                else
                {
                    status = "Normal";
                }


                //Successfully imported {name}({projection type}) with {seats count} seats!
                sb.AppendLine(String.Format(SuccessfulImportHallSeat, hall.Name, status, hall.Seats.Count()));
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            return sb.ToString().ToString();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectionsDto[]), new XmlRootAttribute("Projections"));

            var projectionsDto = (ImportProjectionsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Projection> projections = new List<Projection>();

            StringBuilder sb = new StringBuilder();


            foreach (var dto in projectionsDto)
            {
                var movie = context.Movies.Find(dto.MovieId);

                var hall = context.Halls.Find(dto.HallId);
                if (movie == null || hall == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    MovieId = dto.MovieId,
                    HallId = dto.HallId,
                    DateTime = DateTime.ParseExact(dto.DateTime, @"yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)

                };

                projections.Add(projection);

              //  var date = DateTime.ParseExact(dto.DateTime, @"MM/dd/yyyy", CultureInfo.InvariantCulture);
                //Successfully imported projection {movie title} on {projection datetime}!
              //  sb.AppendLine(String.Format(SuccessfulImportProjection, projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));

                sb.AppendLine(string.Format(SuccessfulImportProjection, movie.Title, projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
            }
            context.Projections.AddRange(projections);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomersDto[]), new XmlRootAttribute("Customers"));

            var customersDto = (ImportCustomersDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Customer> customers = new List<Customer>();

            StringBuilder sb = new StringBuilder();

            foreach (var dto in customersDto)
            {

                if (!IsValid(dto) || !dto.Tickets.Any(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var customer = new Customer
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age,
                    Balance = dto.Balance
                };
                foreach (var dtoTicket in dto.Tickets)
                {
                    var isValidProject = context.Projections.Find(dtoTicket.ProjectionId);

                    if (!IsValid(dtoTicket) || isValidProject == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    customer.Tickets.Add(new Ticket
                    {
                        ProjectionId = dtoTicket.ProjectionId,
                        Price = dtoTicket.Price
                    });
                }
                customers.Add(customer);

                //Successfully imported customer {customer first name} {customer last name} with bought tickets: {tickets count}!
                sb.AppendLine(String.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName,
                    customer.Tickets.Count));
            }
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return sb.ToString().ToString();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return result;
        }
    }
}