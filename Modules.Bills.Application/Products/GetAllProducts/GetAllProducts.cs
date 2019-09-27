using BillAppDDD.Modules.Bills.Application.Bills.Dto;
using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Application.Products.Dto;
using System.Collections.Generic;

namespace BillAppDDD.Modules.Bills.Application.Products.GetAllProducts
{
    public class GetAllProducts: IQuery<List<ProductDto>>
    {
    }
}
