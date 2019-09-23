using AutoMapper;
using BillAppDDD.Modules.Bills.Application.Bills.Dto;
using BillAppDDD.Modules.Bills.Domain.Bills;

namespace BillAppDDD.Modules.Bills.Application.Configuration.AutomapperProfiles
{
    class PurchaseProfile:Profile
    {
        public PurchaseProfile()
        {
            CreateMap<Purchase, PurchaseDto>()
                .ForMember(
                p => p.Amount,
                opt => opt.MapFrom(e => e.Amount)
                )
                .ForMember(
                p => p.Cost,
                opt => opt.MapFrom(e => e.Cost)
                )
                .ForMember(
                p => p.ProductName,
                opt => opt.MapFrom(e => e.Product.Name)
                );
        }
    }
}
