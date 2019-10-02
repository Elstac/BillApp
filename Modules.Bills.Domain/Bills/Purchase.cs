using BillAppDDD.BuildingBlocks.Domain;
using BillAppDDD.Modules.Bills.Domain.Products;
using System;

namespace BillAppDDD.Modules.Bills.Domain.Bills
{
    public class Purchase : Entity
    {
        private float cost;

        public Purchase():base(Guid.NewGuid())
        {

        }

        public Purchase(
            Product product,
            DateTime date,
            float amount,
            float cost
            ) 
            : base(Guid.NewGuid())
        {
            Product = product;
            Date = date;
            Amount = amount;
            this.cost = cost;
        }

        public BillId BillId { get; set; }
        public Bill Bill { get; set; }

        public ProductId ProductId { get; set; }
        public Product Product { get; set; }

        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public float Cost { get => (float)Math.Round(cost, 2); set => cost = value; }
    }
}
