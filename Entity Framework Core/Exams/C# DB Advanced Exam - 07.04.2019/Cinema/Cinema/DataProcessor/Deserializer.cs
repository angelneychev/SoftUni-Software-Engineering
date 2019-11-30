﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using AutoMapper;
using Cinema.Data.Models;
using Cinema.Data.Models.Enums;
using Cinema.DataProcessor.ImportDto;
using Newtonsoft.Json;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

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
            var moviesDto = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);
            List<Movie> movies = new List<Movie>();
            StringBuilder sb = new StringBuilder();

            foreach (var movieDto in moviesDto)
            {
                var validateTitle = movies.Any(t => t.Title == movieDto.Title);
                var validDto = IsValid(movieDto);
                var isValidEnum = Enum.TryParse(typeof(Genre), movieDto.Genre, out object genre);

                if (validateTitle || !validDto || !isValidEnum)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = Mapper.Map<Movie>(movieDto);
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

                if (hall.Seats.Count ==0)
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

                if (validMovieId == null || validHallId == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = Mapper.Map<Projection>(projectionDto);
                projections.Add(projection);

                //sb.AppendLine(string.Format(SuccessfulImportProjection, projection.Movie.Title, projection.DateTime));
                sb.AppendLine(string.Format(SuccessfulImportProjection, validMovieId.Title, projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
            }
            context.Projections.AddRange(projections);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            var customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            List<Customer> customers = new List<Customer>();
            foreach (var customerDto in customersDto)
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance,
                };
                foreach (var ticket in customerDto.Tickets)
                {
                    customer.Tickets.Add(new Ticket
                    {
                        ProjectionId = ticket.ProjectionId,
                        Price = ticket.Price
                    });
                }
                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customer.Tickets.Count));

                customers.Add(customer);
            }


            context.Customers.AddRange(customers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}