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
        public DateTime Date { get; set; }
        public Store Store { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public DateTime CreationDate { get; set; }

        public Bill():base(Guid.NewGuid())
        {
            Purchases = new List<Purchase>();
        }

        public Bill(
            DateTime date,
            Store store,
            ICollection<Purchase> purchases
            ) 
            : base(Guid.NewGuid())
        {
            Date = date;
            Store = store;
            Purchases = purchases;
            CreationDate = DateTime.UtcNow;
        }

        public Bill(
            DateTime date,
            Store store
            )
            : base(Guid.NewGuid())
        {
            Date = date;
            Store = store;
            Purchases = new List<Purchase>();
            CreationDate = DateTime.UtcNow;
        }

        public float GetSum()
        {
            return Purchases.Sum(p => p.Cost);
        }

        public void AddPurchaseBasedOnExistingProduct(Product product,float amount, float price)
        {
            product = product.Update("", null, new Price(price / amount) ,null);

            Purchases.Add(new Purchase(product, Date, amount, price));
        }

        public void AddPurchaseBasedOnNewProduct(
            string name,
            string barcode,
            ProductCategory category,
            float amount,
            float price)
        {
            Purchases.Add(
                new Purchase(
                    new Product(
                        name,
                        new ProductBarcode(barcode),
                        new Price(price/amount),
                        category
                        ),
                    Date,
                    amount,
                    price
                    )
                );
        }
    }
}
