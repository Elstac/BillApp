using System;
using System.Collections.Generic;
using System.Linq;
using BillAppDDD.BuildingBlocks.Domain;
using BillAppDDD.Modules.Bills.Domain.Bills;

namespace BillAppDDD.Modules.Bills.Domain.Stores
{
    public class Store : IAggregateRoot
    {
        private Store()
        {
        }

        public Store(string name, string logoImagePath)
        {
            Id = new StoreId(new Guid());
            this.name = name;
            this.logoImagePath = logoImagePath;
            bills = new List<Bill>();
        }

        public Store(string name, string logoImagePath, List<Bill> bills)
        {
            Id = new StoreId(new Guid());
            this.name = name;
            this.logoImagePath = logoImagePath;
            this.bills = bills;
        }

        private string name;
        private string logoImagePath;
        private List<Bill> bills;

        public StoreId Id { get; private set; }
        public string Name { get => name; }
        public IReadOnlyCollection<Bill> Bills { get => bills.AsReadOnly(); }

        public float GetTotalSpendings()
        {
            return bills.Sum(b => b.GetSum());
        }
    }
}
