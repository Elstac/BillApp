using BillAppDDD.Modules.Bills.Domain.Bills;
using BillAppDDD.Modules.Bills.Domain.Stores;
using System;
using System.Collections.Generic;

namespace BillAppDDD.Modules.Bills.Tests.Bills.Bill
{
    internal class BillBuilder
    {
        private DateTime date;
        private List<Purchase> purchases;
        private Store store;

        public BillBuilder()
        {
            date = new DateTime();
            purchases = new List<Purchase>();
            store = null;
        }

        public BillBuilder WithPurchases(List<Purchase> purchases)
        {
            this.purchases = purchases;

            return this;
        }

        public BillBuilder WithDate(DateTime date)
        {
            this.date = date;

            return this;
        }

        public Domain.Bills.Bill Build()
        {
            return new Domain.Bills.Bill(
                date,
                store,
                purchases
                );
        }
    }
}
