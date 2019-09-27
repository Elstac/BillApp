using BillAppDDD.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;

namespace BillAppDDD.Modules.Bills.Domain.Products
{
    public class ProductCategory: Entity, IAggregateRoot
    {
        private ProductCategory() : base(Guid.NewGuid())
        {
        }

        public ProductCategory(string name) : base(Guid.NewGuid())
        {
            Name = name;
        }

        public string Name { get; set; }
        public ICollection<ProductCategory> Subcategories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
