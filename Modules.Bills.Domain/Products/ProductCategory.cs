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
            Id = new ProductCategoryId(Guid.NewGuid());
            this.name = name;
            subcategories = new List<ProductCategory>();
            products = new List<Product>();
        }

        private string name;
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
