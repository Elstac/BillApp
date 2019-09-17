using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Application.Products.Dto;
using System.Collections.Generic;

namespace BillAppDDD.Modules.Bills.Application.Products.GetAllProductCategories
{
    public class GetAllProductCategories:IQuery<IEnumerable<ProductCategoryDto>>
    {
    }
}
