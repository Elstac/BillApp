using AutoMapper;
using BillAppDDD.Modules.Bills.Application.Bills.Dto;
using BillAppDDD.Modules.Bills.Domain.Products;

namespace BillAppDDD.Modules.Bills.Application.AutomapperProfiles
{
    class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(
                dto => dto.Id,
                opt => opt.MapFrom(b => b.Id.ToString())
                )
                .ForMember(
                dto => dto.Name,
                opt => opt.MapFrom(b => b.Name)
                )
                .ForMember(
                dto => dto.Price,
                opt => opt.MapFrom(b => b.Price.Value)
                )
                .ForMember(
                dto => dto.Barcode,
                opt => opt.MapFrom(b => b.Barcode.Value)
                );
        }
    }
}
