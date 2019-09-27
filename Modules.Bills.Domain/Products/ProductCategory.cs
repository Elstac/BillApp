using BillAppDDD.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;

namespace BillAppDDD.Modules.Bills.Domain.Products
{
    public class ProductCategory: IAggregateRoot
    {
        private ProductCategory()
        {
        }

        public ProductCategory(string name)
        {
            Id = new ProductCategoryId(new Guid());
            Name = name;
            subcategories = new List<ProductCategory>();
            products = new List<Product>();
        }

        private string Name;
        private List<ProductCategory> subcategories;
        private List<Product> products;

        public ProductCategoryId Id { get; private set; }
        public IReadOnlyCollection<Product> Products { get => products.AsReadOnly(); }
        public IReadOnlyCollection<ProductCategory> Subcategories { get => subcategories.AsReadOnly();}

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
    }
}
