using BillAppDDD.Modules.Bills.Application.Bills.Dto;
using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Application.Products.Dto;

namespace BillAppDDD.Modules.Bills.Application.Products.GetAllProducts
{
    public class GetAllProducts: IQuery<ProductDto[]>
    {
    }
}
