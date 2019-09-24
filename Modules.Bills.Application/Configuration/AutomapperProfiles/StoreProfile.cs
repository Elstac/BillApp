using AutoMapper;
using BillAppDDD.Modules.Bills.Application.Bills.Dto;
using BillAppDDD.Modules.Bills.Application.Stores.Dto;
using BillAppDDD.Modules.Bills.Domain.Stores;
using System.Linq;

namespace BillAppDDD.Modules.Bills.Application.Configuration.AutomapperProfiles
{
    class StoreProfile:Profile
    {
        public StoreProfile()
        {
            CreateMap<Store, StoreDetailsDto>()
                .ForMember(
                s => s.Id,
                opt => opt.MapFrom(e => e.Id)
                )
                .ForMember(
                s => s.Name,
                opt => opt.MapFrom(e => e.Name)
                )
                .ForMember(
                s => s.Bills,
                opt => opt.MapFrom(
                    e => e.Bills.Select(
                            b=>new BillDto
                            {
                                Id = b.Id,
                                Date = b.Date,
                                Sum = b.GetSum()
                            }
                        )
                    )
                );

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
