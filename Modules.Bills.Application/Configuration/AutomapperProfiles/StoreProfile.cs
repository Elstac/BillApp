using AutoMapper;
using BillAppDDD.Modules.Bills.Application.Stores.Dto;
using BillAppDDD.Modules.Bills.Domain.Stores;

namespace BillAppDDD.Modules.Bills.Application.Configuration.AutomapperProfiles
{
    class StoreProfile:Profile
    {
        public StoreProfile()
        {
            CreateMap<Store, StoreDto>()
                .ForMember(
                s => s.Id,
                opt => opt.MapFrom(e => e.Id)
                )
                .ForMember(
                s => s.Name,
                opt => opt.MapFrom(e => e.Name)
                );
        }
    }
}
