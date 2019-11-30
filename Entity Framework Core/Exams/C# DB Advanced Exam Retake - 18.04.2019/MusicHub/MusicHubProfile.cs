using System;
using System.Globalization;
using MusicHub.Data.Models;
using MusicHub.DataProcessor.ImportDtos;

namespace MusicHub
{
    using AutoMapper;

    public class MusicHubProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public MusicHubProfile()
        {
            CreateMap<ImportWriterDto, Writer>();

            CreateMap<ImportAlbumDto, Album>();
            CreateMap<ImportProducerDto, Producer>();

            CreateMap<ImportSongDto, Song>()
                .ForMember(t => t.Duration, y => y.MapFrom(k => TimeSpan.ParseExact(k.Duration, @"hh\:mm\:ss", CultureInfo.InvariantCulture)))
                .ForMember(t => t.CreatedOn, y => y.MapFrom(k => DateTime.ParseExact(k.CreatedOn, @"dd/MM/yyyy", CultureInfo.InvariantCulture)));

          //  CreateMap<ImportProducerDto, Performer>();
           // CreateMap<ImportPerformerSongDto, SongPerformer>()
            //    .ForMember(t => t.SongId, y => y.MapFrom(k => k.Id));
        }
    }
}
