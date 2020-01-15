using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using MusicHub.Data.Models;
using MusicHub.Data.Models.Enums;
using MusicHub.DataProcessor.ImportDtos;
using Newtonsoft.Json;

namespace MusicHub.DataProcessor
{
    using System;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter 
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone 
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong 
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersDto = JsonConvert.DeserializeObject<ImportWriterstDto[]>(jsonString);

            List<Writer> writers = new List<Writer>();

            StringBuilder sb = new StringBuilder();

            foreach (var dto in writersDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var writer = new Writer
                {
                    Name = dto.Name,
                    Pseudonym = dto.Pseudonym
                };
                
                writers.Add(writer);
                //Imported {writer name} 
                sb.AppendLine(String.Format(SuccessfullyImportedWriter, writer.Name));
            }
            context.Writers.AddRange(writers);
            context.SaveChanges();
            
            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersDto = JsonConvert.DeserializeObject<ImportProducersDto[]>(jsonString);

            List<Producer> producers = new List<Producer>();

            StringBuilder sb = new StringBuilder();

            foreach (var dto in producersDto)
            {

                if (!IsValid(dto) || !dto.Albums.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var producer = new Producer
                {
                    Name = dto.Name,
                    Pseudonym = dto.Pseudonym,
                    PhoneNumber = dto.PhoneNumber
                };

                foreach (var dtoAlbum in dto.Albums)
                {

                    var album = new Album
                    {
                        Name = dtoAlbum.Name,
                        ReleaseDate = DateTime.ParseExact(dtoAlbum.ReleaseDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture)
                    };

                    producer.Albums.Add(album);
                }

                //if (producer.PhoneNumber == null)
                //{
                //    sb.AppendLine(String.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count));
                //}
                //else
                //{
                //    sb.AppendLine(String.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber,
                //        producer.Albums.Count));
                //}
                string message = producer.PhoneNumber == null
                    ? string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count)
                    : string.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count);
                sb.AppendLine(message);

                producers.Add(producer);
            }
            context.Producers.AddRange(producers);
            context.SaveChanges();
            
            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongsDto[]), new XmlRootAttribute("Songs"));

            var songsDto = (ImportSongsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Song> songs = new List<Song>();
            StringBuilder sb = new StringBuilder();

            foreach (var dto in songsDto)
            {

              //  bool isGenreValid = Enum.TryParse(dto.Genre, out Genre genre);
               // bool isCreatedOnValid = DateTime.ParseExact(dto.Duration, @"hh\:mm\:ss", CultureInfo.InvariantCulture);

                var genre = Enum.TryParse(dto.Genre, out Genre genreResult);
                var album = context.Albums.Find(dto.AlbumId);
                var writer = context.Writers.Find(dto.WriterId);
                var songTitle = songs.Any(s => s.Name == dto.Name);//проверява в листа 

                if (!IsValid(dto) || !genre || songTitle || album ==null || writer == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = new Song
                {
                    Name = dto.Name,
                    Duration = TimeSpan.ParseExact(dto.Duration, @"hh\:mm\:ss", CultureInfo.InvariantCulture),
                    CreatedOn = DateTime.ParseExact(dto.CreatedOn, @"dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre = Enum.Parse<Genre>(dto.Genre),
                    AlbumId = dto.AlbumId,
                    WriterId =dto.WriterId,
                    Price = dto.Price
                };
                songs.Add(song);

                sb.AppendLine(String.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
            }
            context.Songs.AddRange(songs);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPerformerDto[]), new XmlRootAttribute("Performers"));

            var performerDtos = (ImportPerformerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var validPerformers = new List<Performer>();
            var sb = new StringBuilder();

            foreach (var performerDto in performerDtos)
            {
                if (!IsValid(performerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validSongsCount = context.Songs.Count(s => performerDto.PerformerSongs.Any(i => i.Id == s.Id));

                if (validSongsCount != performerDto.PerformerSongs.Length)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var performer = new Performer
                {
                    FirstName = performerDto.FirstName,
                    LastName = performerDto.LastName,
                    Age = performerDto.Age,
                    NetWorth = performerDto.NetWorth,
                };
                foreach (var songPerformersDto in performerDto.PerformerSongs)
                {
                    performer.PerformerSongs.Add(new SongPerformer
                    {
                        SongId = songPerformersDto.Id
                    });
                }

                validPerformers.Add(performer);
                sb.AppendLine(string.Format(SuccessfullyImportedPerformer, performer.FirstName,
                    performer.PerformerSongs.Count));
            }

            context.Performers.AddRange(validPerformers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
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