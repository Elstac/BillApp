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
            subcategories = new List<ProductCategory>();
            products = new List<Product>();
        }

        private string Name;
        private List<ProductCategory> subcategories;
        private List<Product> products;

        public IReadOnlyCollection<Product> Products { get => products.AsReadOnly(); }
        public IReadOnlyCollection<ProductCategory> Subcategories { get => subcategories.AsReadOnly();}

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
    }
}
