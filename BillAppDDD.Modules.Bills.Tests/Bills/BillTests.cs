using Xunit;
using Moq;
using BillAppDDD.Modules.Bills.Domain.Bills;
using System;
using System.Collections.Generic;
using BillAppDDD.Modules.Bills.Domain.Stores;

namespace BillAppDDD.Modules.Bills.Tests.Bills
{
    class BillBuilder
    {
        private DateTime date;
        private List<Purchase> purchases;
        private Store store;

        public BillBuilder()
        {
            date = new DateTime();
            purchases = null;
            store = null;
        }

        public BillBuilder WithPurchases(List<Purchase> purchases)
        {
            this.purchases = purchases;

            return this;
        }

        public Bill Build()
        {
            return new Bill(
                date,
                store,
                purchases
                );
        }
    }
    public class BillTests
    {
        [Fact]
        public void Return_sum_of_cost_of_all_purchases()
        {
            var purchases = new List<Purchase>
            {
                new Purchase(null,new DateTime(),0,10,null),
                new Purchase(null,new DateTime(),0,15,null)
            };

            var bill = new BillBuilder()
                .WithPurchases(purchases)
                .Build();

            var summaryCost = bill.GetSum();

            Assert.Equal(25, summaryCost);
        }
    }
}
