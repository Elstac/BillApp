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
                    dto => dto.Date,
                    opt => opt.MapFrom(b => b.Date)
                    );
        }
    }
}
