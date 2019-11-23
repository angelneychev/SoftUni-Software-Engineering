using CarDealer.Dtos.Export;
using Microsoft.CSharp.RuntimeBinder;

namespace CarDealer
{
    using AutoMapper;
    using Dtos.Import;
    using Models;
    using System.Linq;
    public class CarDealerProfile : Profile
    {

        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();
            this.CreateMap<ImportPartDto, Part>();
            this.CreateMap<ImportCarDto, Car>();
            this.CreateMap<ImportCustomerDto, Customer>();
            this.CreateMap<ImportSaleDto, Sale>();

            this.CreateMap<Supplier, ExportLocalSuppliersDto>();
            this.CreateMap<Car, ExportLocalCarsBmwDto>();

            this.CreateMap<Part, ExportLocalCardPartDto>();
            this.CreateMap<Car, ExportLocalCarDto>()
                .ForMember(x=>x.Parts, y=>y.MapFrom(x=>x.PartCars.Select(pc=>pc.Part)));

            CreateMap<Customer, ExportLocalCustomerDto>()
                .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                .ForMember(x => x.CarSaleCount, y => y.MapFrom(x => x.Sales.Count))
                .ForMember(x => x.CarSaleSum,
                    y => y.MapFrom(x => x.Sales
                        .Sum(s => s.Car.PartCars
                            .Sum(pc => pc.Part.Price))));

            CreateMap<Sale, ExportLocalSalesDiscountDto>()
                .ForMember(x => x.CustomerName, y => y.MapFrom(x => x.Customer.Name))
                .ForMember(x => x.Price, y => y.MapFrom(x => x.Car.PartCars
                    .Sum(pc => pc.Part.Price)))
                .ForMember(x => x.PriceWithDiscount, y => y.MapFrom(x => x.Car.PartCars.Sum(pc => pc.Part.Price) - (x.Car.PartCars.Sum(pc => pc.Part.Price) * x.Discount / 100)));
        }
    }
}
