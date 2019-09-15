using System;
using System.Collections.Generic;
using BillAppDDD.BuildingBlocks.Domain;
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
        }

    }
}
