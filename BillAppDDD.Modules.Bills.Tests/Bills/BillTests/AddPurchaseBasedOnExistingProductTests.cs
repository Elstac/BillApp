using BillAppDDD.Modules.Bills.Domain.Products;
using BillAppDDD.Modules.Bills.Tests.Bills.ProductTests;
using System;
using System.Linq;
using Xunit;

namespace BillAppDDD.Modules.Bills.Tests.Bills.BillTests
{
    public class AddPurchaseBasedOnExistingProductTests
    {

        [Fact]
        public void New_purchase_contains_date_from_bill()
        {
            //Arrange
            var billDate = new DateTime(2137, 9, 11);

            var bill = new BillBuilder()
                .WithDate(billDate)
                .Build();

            Assert.Empty(bill.Purchases);

            var product = new Product("", new ProductBarcode(""), new MoneyValue(0), null);

            //Act
            bill.AddPurchaseBasedOnExistingProduct(product,0,0);

            //Assert
            Assert.Single(bill.Purchases);
            Assert.Equal(billDate, bill.Purchases.FirstOrDefault().Date);
        }

        [Fact]
        public void Change_product_cost_based_on_new_cost_and_amount()
        {
            //Arrange
            var bill = new BillBuilder()
                .Build();

            Assert.Empty(bill.Purchases);

            var product = new Product("", new ProductBarcode(""), new MoneyValue(0), null);

            //Act
            bill.AddPurchaseBasedOnExistingProduct(product, 5.0f, 15.0f);

            //Assert
            Assert.Equal(3, bill.Purchases.FirstOrDefault().Product.Price.Value);
        }

        [Fact]
        public void Purchase_contains_same_product_if_cost_doesnt_change()
        {
            //Arrange
            var bill = new BillBuilder()
                .Build();

            Assert.Empty(bill.Purchases);

            var product = new Product("", new ProductBarcode(""), new MoneyValue(12.5f), null);

            //Act
            bill.AddPurchaseBasedOnExistingProduct(product, 2.0f, 25.0f);

            //Assert
            Assert.Equal(product, bill.Purchases.FirstOrDefault().Product);
        }

        [Fact]
        public void Increase_bill_sum_by_new_purchase_value()
        {
            //Arrange
            var bill = new BillBuilder()
                .Build();

            Assert.Empty(bill.Purchases);

            var product = new ProductBuilder().Build();

            //Act
            Assert.Equal(0.0f, bill.GetSum());
            bill.AddPurchaseBasedOnExistingProduct(product, 1.0f, 25.0f);

            //Assert
            Assert.Equal(25.0f, bill.GetSum());
        }
    }
}
