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

            CreateMap<ImportProducersAlbumDto, Producer>();
          //  CreateMap<ImportAlbumDto, Album>();

        }
    }
}
