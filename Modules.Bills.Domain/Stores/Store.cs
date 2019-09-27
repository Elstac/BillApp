using System;
using System.Collections.Generic;
using System.Linq;
using BillAppDDD.BuildingBlocks.Domain;
using BillAppDDD.Modules.Bills.Domain.Bills;

namespace BillAppDDD.Modules.Bills.Domain.Stores
{
    public class Store : Entity, IAggregateRoot
    {
        private Store() : base(Guid.NewGuid())
        {
        }

        public Store(string name, string logoImagePath) : base(Guid.NewGuid())
        {
            this.name = name;
            this.logoImagePath = logoImagePath;
            bills = new List<Bill>();
        }

        public Store(string name, string logoImagePath, List<Bill> bills) : base(Guid.NewGuid())
        {
            this.name = name;
            this.logoImagePath = logoImagePath;
            this.bills = new List<Bill>();
        }

        private string name;
        private string logoImagePath;
        private List<Bill> bills;

        public string Name { get => name; }
        public IReadOnlyCollection<Bill> Bills { get => bills.AsReadOnly(); }

        public float GetTotalSpendings()
        {
            return Bills.Sum(b => b.GetSum());
        }
    }
}
