using System;
using System.Globalization;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;
using SoftJail.DataProcessor.ImportDto;

namespace SoftJail
{
    using AutoMapper;


    public class SoftJailProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public SoftJailProfile()
        {
            CreateMap<ImportCellDto, Cell>();
            CreateMap<ImportDepartmentDto, Department>();

           //

           CreateMap<ImportPrisonerDto, Prisoner>()
           .ForMember(x => x.IncarcerationDate, y => y.MapFrom(
               x => DateTime.ParseExact(x.IncarcerationDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture)))
           .ForMember(x => x.ReleaseDate, y => y.MapFrom(
               x => DateTime.ParseExact(x.ReleaseDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture)));
           
           
           this.CreateMap<ImportOfficerDto, Officer>()
               .ForMember(x => x.Position, y => y.MapFrom(
                   x => Enum.Parse(typeof(Position), x.Position)))
               .ForMember(x => x.Weapon, y => y.MapFrom(
                   x => Enum.Parse(typeof(Weapon), x.Weapon)));

        }
    }
}
