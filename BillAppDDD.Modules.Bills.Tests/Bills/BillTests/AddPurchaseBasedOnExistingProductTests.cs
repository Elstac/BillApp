using BillAppDDD.Modules.Bills.Domain.Products;
using System;
using System.Linq;
using Xunit;

namespace BillAppDDD.Modules.Bills.Tests.Bills.BillTests
{
    public class AddPurchaseBasedOnExistingProductTests
    {
        [Fact]
        public void New_purchase_contains_given_product()
        {
            //Arrange
            var bill = new BillBuilder().Build();

            Assert.Empty(bill.Purchases);

            var product = new Product("", new ProductBarcode(), new Price(), null);

            //Act
            bill.AddPurchaseBasedOnExistingProduct(product,0,0);

            //Assert
            Assert.Single(bill.Purchases);
            Assert.Equal(product,bill.Purchases.FirstOrDefault().Product);
        }

        [Fact]
        public void New_purchase_contains_date_from_bill()
        {
            //Arrange
            var billDate = new DateTime(2137, 9, 11);

            var bill = new BillBuilder()
                .WithDate(billDate)
                .Build();

            Assert.Empty(bill.Purchases);

            var product = new Product("", new ProductBarcode(), new Price(), null);

            //Act
            bill.AddPurchaseBasedOnExistingProduct(product,0,0);

            //Assert
            Assert.Single(bill.Purchases);
            Assert.Equal(billDate, bill.Purchases.FirstOrDefault().Date);
        }

        [Fact]
        public void New_purchase_contains_amount_and_cost()
        {
            //Arrange
            var bill = new BillBuilder()
                .Build();

            Assert.Empty(bill.Purchases);

            var product = new Product("", new ProductBarcode(), new Price(), null);

            //Act
            bill.AddPurchaseBasedOnExistingProduct(product, 10, 11);

            //Assert
            Assert.Single(bill.Purchases);
            Assert.Equal(10, bill.Purchases.FirstOrDefault().Amount);
            Assert.Equal(11, bill.Purchases.FirstOrDefault().Cost);
        }
    }
}
