using BillAppDDD.BuildingBlocks.Domain;
using System;

namespace BillAppDDD.Modules.Bills.Domain.Products
{
    public class Product :  IAggregateRoot
    {
        private Product()
        {

        }
        public Product(
            string name,
            ProductBarcode barcode,
            MoneyValue price, 
            ProductCategory category
            )
        {
            Id = new ProductId(Guid.NewGuid());
            Name = name;
            Barcode = barcode;
            Price = price;
            this.category = category;
            lastVersion = null;
            LatestVersion = true;
        }

        private Product lastVersion;
        private ProductCategory category;

        public ProductId Id { get; private set; }
        public string Name { get; private set; }
        public ProductBarcode Barcode { get; private set; }
        public MoneyValue Price { get; private set; }
        public bool LatestVersion { get; private set; }

        public Product Update(
            string name,
            ProductBarcode barcode,
            MoneyValue price,
            ProductCategory category
            )
        {
            if (string.IsNullOrEmpty(name))
                name = Name;

            if (barcode is null)
                barcode = new ProductBarcode(Barcode.Value);

            if (price is null)
                price = new MoneyValue(Price.Value);

            var newProduct = new Product(
                    name,
                    barcode,
                    price,
                    category
                );

            LatestVersion = false;
            newProduct.lastVersion = this;
            newProduct.LatestVersion = true;

            return newProduct;
        }

        public bool IsLastVersion(Product product)
        {
            return lastVersion == product;
        }
    }
}
