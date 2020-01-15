using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;
using Cinema.Data.Models;
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
            var moviesDto = JsonConvert.DeserializeObject<ImportMoviesDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<Movie> movies = new List<Movie>();

            foreach (var movieDto in moviesDto)
            {
                if (!IsValid(movieDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = AutoMapper.Mapper.Map<Movie>(movieDto);
                movies.Add(movie);


                sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre, movie.Rating.ToString("F2")));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallSeatsDto = JsonConvert.DeserializeObject<ImportHallSeatDto[]>(jsonString);
            var halls = new List<Hall>();

            var sb = new StringBuilder();

            foreach (var hallSeatDto in hallSeatsDto)
            {
                if (!IsValid(hallSeatDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallSeatDto.Name,
                    Is3D = hallSeatDto.Is3D,
                    Is4Dx = hallSeatDto.Is4Dx,
                };

                for (int i = 0; i < hallSeatDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }

                if (hall.Seats.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                halls.Add(hall);

                string status = "";

                if (hall.Is4Dx)
                {
                    status = hall.Is3D ? "4Dx/3D" : "4Dx";
                }
                else if (hall.Is3D)
                {
                    status = "3D";
                }
                else
                {
                    status = "Normal";
                }

                sb.AppendLine(string.Format(SuccessfulImportHallSeat, hall.Name, status, hall.Seats.Count));
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            return sb.ToString();


        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));

            var projectionsDto = (ImportProjectionDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            List<Projection> projections = new List<Projection>();

            foreach (var projectionDto in projectionsDto)
            {
                var validMovieId = context.Movies.Find(projectionDto.MovieId);
                var validHallId = context.Halls.Find(projectionDto.HallId);

                if (IsValid(projectionsDto) || validMovieId !=null || validHallId == null)
                {
                    var projection = new Projection
                    {
                        MovieId = projectionDto.MovieId,
                        HallId = projectionDto.HallId,
                        DateTime = DateTime.ParseExact(projectionDto.DateTime, "2019-04-27 13:33:20", CultureInfo.InvariantCulture)
                    };

                    projections.Add(projection);
                    context.Projections.Add(projection);

                    sb.AppendLine(string.Format(SuccessfulImportProjection, validMovieId.Title, projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
                
            }

            //context.Projections.AddRange(projections);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            throw new NotImplementedException();
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