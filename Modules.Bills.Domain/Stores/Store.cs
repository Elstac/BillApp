using System;
using System.Collections.Generic;
using System.Linq;
using BillAppDDD.BuildingBlocks.Domain;
using BillAppDDD.Modules.Bills.Domain.Bills;

namespace BillAppDDD.Modules.Bills.Domain.Stores
{
    public class Store : Entity, IAggregateRoot
    {
        public Store() : base(Guid.NewGuid())
        {
        }

        public string Name { get; set; }
        public string LogoImagePath { get; set; }
        public ICollection<Bill> Bills { get; set; }

        public float GetTotalSpendings()
        {
            return Bills.Sum(b => b.GetSum());
        }
    }
}
