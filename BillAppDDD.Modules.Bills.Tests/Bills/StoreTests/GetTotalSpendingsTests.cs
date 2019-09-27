using BillAppDDD.Modules.Bills.Domain.Bills;
using BillAppDDD.Modules.Bills.Domain.Stores;
using BillAppDDD.Modules.Bills.Tests.Bills.BillTests;
using System.Collections.Generic;
using Xunit;

namespace BillAppDDD.Modules.Bills.Tests.Bills.StoreTests
{
    public class GetTotalSpendingsTests
    {
        [Fact]
        public void Return_sum_of_spendings_from_all_bills()
        {
            var billCollection = new List<Bill>
            {
                new BillBuilder().WithPurchases(
                    new List<Purchase>
                    {
                        new Purchase(null,new System.DateTime(),0,10),
                        new Purchase(null,new System.DateTime(),0,12)
                    })
                .Build(),
                new BillBuilder().WithPurchases(
                    new List<Purchase>
                    {
                        new Purchase(null,new System.DateTime(),0,1),
                        new Purchase(null,new System.DateTime(),0,3)
                    })
                .Build()
            };

            var store = new Store("", "", billCollection);

            var totalSpendings = store.GetTotalSpendings();

            Assert.Equal(26, totalSpendings);
        }
    }
}
