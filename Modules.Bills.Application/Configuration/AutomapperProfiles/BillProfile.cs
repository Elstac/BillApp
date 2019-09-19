using AutoMapper;
using BillAppDDD.Modules.Bills.Application.Bills.Dto;
using BillAppDDD.Modules.Bills.Domain.Bills;

namespace BillAppDDD.Modules.Bills.Application.Configuration.AutomapperProfiles
{
    class BillProfile: Profile
    {
        public BillProfile()
        {
            CreateMap<Bill, BillDto>()
                .ForMember(
                    dto => dto.Id,
                    opt => opt.MapFrom(b => b.Id)
                    )
                .ForMember(
                    dto => dto.Date,
                    opt => opt.MapFrom(b => b.Date.Date)
                    )
                .ForMember(
                    dto => dto.Store,
                    opt => opt.MapFrom(b => b.Store)
                    )
                .ForMember(
                    dto => dto.Sum,
                    opt => opt.MapFrom(b => b.GetSum())
                    );

            CreateMap<Bill, BillDetailsDto>()
                .ForMember(
                    dto => dto.Id,
                    opt => opt.MapFrom(b => b.Id)
                    )
                .ForMember(
                    dto => dto.Date,
                    opt => opt.MapFrom(b => b.Date.Date)
                    )
                .ForMember(
                    dto => dto.Store,
                    opt => opt.MapFrom(b => b.Store)
                    )
                .ForMember(
                    dto => dto.Purchases,
                    opt => opt.MapFrom(b => b.Purchases)
                    )
                .ForMember(
                    dto => dto.Sum,
                    opt => opt.MapFrom(b => b.GetSum())
                    );
        }
    }
}
