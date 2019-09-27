using AutoMapper;
using BillAppDDD.Modules.Bills.Application.Products.Dto;
using BillAppDDD.Modules.Bills.Domain.Products;
using System.Linq;

namespace BillAppDDD.Modules.Bills.Application.Configuration.AutomapperProfiles
{
    class ProductCategoryProfile:Profile
    {
        public ProductCategoryProfile()
        {
            //CreateMap<ProductCategory, ProductCategoryDto>()
            //    .ForMember(
            //    dto => dto.Id,
            //    opt => opt.MapFrom(b => b.Id)
            //    )
            //    .ForMember(
            //    dto => dto.Name,
            //    opt => opt.MapFrom(b => b.Name)
            //    )
            //    .ForMember(
            //    dto => dto.Products,
            //    opt => opt.MapFrom(b => b.Products)
            //    )
            //    .ForMember(
            //    dto => dto.SubCategories,
            //    opt => opt.MapFrom(
            //        b => b.Subcategories
            //        .Select(sc => new ProductCategoryDto
            //        {
            //            Name = sc.Name
            //        })
            //        )
            //    );
        }
    }
}
