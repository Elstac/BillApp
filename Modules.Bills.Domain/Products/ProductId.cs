using BillAppDDD.BuildingBlocks.Domain;
using System;

namespace BillAppDDD.Modules.Bills.Domain.Products
{
    public class ProductId : IdValueType
    {
        public ProductId(Guid value) : base(value)
        {
        }
    }
}
