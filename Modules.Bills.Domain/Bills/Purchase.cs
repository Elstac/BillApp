using BillAppDDD.BuildingBlocks.Domain;
using BillAppDDD.Modules.Bills.Domain.Products;
using System;

namespace BillAppDDD.Modules.Bills.Domain.Bills
{
    public class Purchase : Entity
    {
        public Purchase():base(Guid.NewGuid())
        {

        }

        public Purchase(
            Product product,
            DateTime date,
            float amount,
            float cost,
            Bill bill
            ) 
            : base(Guid.NewGuid())
        {
            Product = product;
            Date = date;
            Amount = amount;
            Cost = cost;
            Bill = bill;
        }

        public Guid BillId { get; set; }
        public Bill Bill { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public float Cost { get; set; }
    }
}
