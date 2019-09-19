using BillAppDDD.BuildingBlocks.Domain;
using System;

namespace BillAppDDD.Modules.Bills.Domain.Products
{
    public class Product : Entity, IAggregateRoot
    {
        public Product() : base(Guid.NewGuid())
        {

        }
        public Product(
            string name,
            ProductBarcode barcode,
            Price price, 
            ProductCategory category
            ) 
            : base(Guid.NewGuid())
        {
            Name = name;
            Barcode = barcode;
            Price = price;
            Category = category;
            LastVersion = null;
        }

        public string Name { get; set; }
        public ProductBarcode Barcode { get; set; }
        public Price Price { get; set; }
        public ProductCategory Category { get; set; }
        public Product LastVersion { get; set; }

        public Product Update(
            string name,
            ProductBarcode barcode,
            Price price,
            ProductCategory category
            )
        {
            if (string.IsNullOrEmpty(name))
                name = Name;

            if (barcode is null)
                barcode = new ProductBarcode(Barcode.Value);

            if (price is null)
                price = new Price(Price.Value);

            var newProduct = new Product(
                    name,
                    barcode,
                    price,
                    category
                );

            newProduct.LastVersion = this;

            return newProduct;
        }
    }
}
