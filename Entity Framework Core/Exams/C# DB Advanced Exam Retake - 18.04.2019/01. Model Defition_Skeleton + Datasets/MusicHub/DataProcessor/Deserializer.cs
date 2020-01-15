namespace MusicHub.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    using ImportDtos;
    using Data;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data.Models;
    using Data.Models.Enums;

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
            var writersDto = JsonConvert.DeserializeObject<ImportWriterDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<Writer> writers = new List<Writer>();

            foreach (var dto in writersDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = AutoMapper.Mapper.Map<Writer>(dto);
                writers.Add(writer);

                sb.AppendLine(String.Format(SuccessfullyImportedWriter, writer.Name));
            }
            
            context.Writers.AddRange(writers);
            context.SaveChanges();
            
            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersDto = JsonConvert.DeserializeObject<ImportProducersAlbumDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<Producer> producers = new List<Producer>();

            foreach (var dto in producersDto)
            {
              //  var validAlbum = context.Albums.All(IsValid);
                //var validPhoneNumber = 
             //   if (!IsValid(dto) || !dto.Albums.Any(IsValid))
                if (!IsValid(dto) || !dto.Albums.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

               // var producer = AutoMapper.Mapper.Map<Producer>(dto);
               // producers.Add(producer);
//DateTime = DateTime.ParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
               var producer = new Producer
               {
                   Name = dto.Name,
                   Pseudonym = dto.Pseudonym,
                   PhoneNumber = dto.PhoneNumber,
               };
               foreach (var dtoAlbum in dto.Albums)
               {
                   producer.Albums.Add(new Album
                   {
                       Name = dtoAlbum.Name,
                       ReleaseDate = DateTime.ParseExact(dtoAlbum.ReleaseDate, "dd/MM/yyyy",
                           CultureInfo.CurrentUICulture)
                   });
               }
               
               producers.Add(producer);
               
               
                string message = producer.PhoneNumber == null
                    ? string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count)
                    : string.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber,
                        producer.Albums.Count);
                
                sb.AppendLine(message);
                
            }
            context.Producers.AddRange(producers);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongDto[]), new XmlRootAttribute("Songs"));

            var songsDto = (ImportSongDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Song> songs = new List<Song>();
            var sb = new StringBuilder();

            foreach (var dto in songsDto)
            {
                var validAlbumId = context.Albums.Find(dto.AlbumId);
                var validWriterId = context.Writers.Find(dto.WriterId);
                
                bool validGenre = Enum.IsDefined(typeof(Genre), dto.Genre);

                if (!IsValid(dto) || validAlbumId == null || validWriterId == null || !validGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                var song = new Song
                {
                    Name = dto.Name,
                    Duration = TimeSpan.ParseExact(dto.Duration, @"hh\:mm\:ss", CultureInfo.InvariantCulture),
                    CreatedOn = DateTime.ParseExact(dto.CreatedOn, @"dd/MM/yyyy",CultureInfo.CurrentUICulture),
                    Genre = Enum.Parse<Genre>(dto.Genre),
                    AlbumId = dto.AlbumId,
                    WriterId = dto.WriterId,
                    Price = dto.Price
                };
                
                songs.Add(song);
                sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre,
                    song.Duration.ToString(@"hh\:mm\:ss")));
                //Imported {song name} ({song genre} genre) with duration {song duration}
            }
            context.Songs.AddRange(songs);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }
//DateTime.ParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongPerformerDto[]), new XmlRootAttribute("Performers"));

            var performersDto = (ImportSongPerformerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Performer> performers= new List<Performer>();
            var sb = new StringBuilder();


            foreach (var dto in performersDto)
            {
                var songId = context.Songs.Select(s => s.Id).ToList();

                var validSongId = dto.PerformersSongs.Select(s => s.Id).All(x => songId.Contains(x));
                
                if (!IsValid(dto) || !validSongId)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                var performer = new Performer
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age,
                    NetWorth = dto.NetWorth,
                };
                performer.PerformerSongs = dto.PerformersSongs
                    .Select(s => new SongPerformer
                    {
                        SongId = s.Id
                    })
                    .ToList();
                
                performers.Add(performer);
                sb.AppendLine(string.Format(SuccessfullyImportedPerformer, performer.FirstName, performer.PerformerSongs.Count));
            }
            context.Performers.AddRange(performers);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

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