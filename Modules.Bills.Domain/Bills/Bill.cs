using System;
using System.Collections.Generic;
using System.Linq;
using BillAppDDD.BuildingBlocks.Domain;
using BillAppDDD.Modules.Bills.Domain.Products;
using BillAppDDD.Modules.Bills.Domain.Stores;
using BillAppDDD.Shared.Contracts;

namespace BillAppDDD.Modules.Bills.Domain.Bills
{
    public class Bill : Entity, IAggregateRoot, ICreationDate
    {
        private DateTime date;
        private Store store;
        private List<Purchase> purchases;

        public ICollection<Purchase> Purchases { get => purchases.AsReadOnly();}
        public DateTime CreationDate { get; set; }

        public Bill():base(Guid.NewGuid())
        {
            purchases = new List<Purchase>();
        }

        public Bill(
            DateTime date,
            Store store,
            List<Purchase> purchases
            ) 
            : base(Guid.NewGuid())
        {
            this.date = date;
            this.store = store;
            this.purchases = purchases;
            CreationDate = DateTime.UtcNow;
        }

        public Bill(
            DateTime date,
            Store store
            )
            : base(Guid.NewGuid())
        {
            this.date = date;
            this.store = store;
            purchases = new List<Purchase>();
            CreationDate = DateTime.UtcNow;
        }

        public float GetSum()
        {
            return purchases.Sum(p => p.Cost);
        }

        public void AddPurchaseBasedOnExistingProduct(Product product,float amount, float price)
        {
            var cost = price / amount;

            if(product.Price.Value != cost)
                product = product.Update("", null, new Price(price / amount) ,null);

            purchases.Add(new Purchase(product, this.date, amount, price));
        }

        public void AddPurchaseBasedOnNewProduct(
            string name,
            string barcode,
            ProductCategory category,
            float amount,
            float price)
        {
            purchases.Add(
                new Purchase(
                    new Product(
                        name,
                        new ProductBarcode(barcode),
                        new Price(price/amount),
                        category
                        ),
                    this.date,
                    amount,
                    price
                    )
                );
        }
    }
}
