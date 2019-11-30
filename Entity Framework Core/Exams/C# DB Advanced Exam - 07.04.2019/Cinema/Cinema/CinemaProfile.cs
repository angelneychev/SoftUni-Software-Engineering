using AutoMapper;
using Cinema.Data;
using Cinema.Data.Models;
using Cinema.DataProcessor.ImportDto;

namespace Cinema
{
    public class CinemaProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public CinemaProfile()
        {
            CreateMap<ImportMovieDto, Movie>();

            //CreateMap<ImportHallSeatDto, Hall>();

            CreateMap<ImportProjectionDto, Projection>();

        }
    }
}
