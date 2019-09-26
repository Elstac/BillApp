using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Application.Products.Dto;
using System;

namespace BillAppDDD.Modules.Bills.Application.Products.GetProductDetails
{
    public class GetProductDetails: IQuery<ProductDto>
    {
        public GetProductDetails(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; set; }
    }
}
