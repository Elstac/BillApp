using BillAppDDD.BuildingBlocks.Domain;
using System;

namespace BillAppDDD.Modules.Bills.Domain.Products
{
    public class ProductCategoryId : IdValueType
    {
        public ProductCategoryId(Guid value) : base(value)
        {
        }
    }
}
