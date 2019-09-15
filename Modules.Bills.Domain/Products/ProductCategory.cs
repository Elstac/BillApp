using BillAppDDD.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;

namespace BillAppDDD.Modules.Bills.Domain.Products
{
    public class ProductCategory: Entity, IAggregateRoot
    {
        public ProductCategory() : base(Guid.NewGuid())
        {
        }

        public string Name { get; set; }
        public ICollection<ProductCategory> Subcategories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
