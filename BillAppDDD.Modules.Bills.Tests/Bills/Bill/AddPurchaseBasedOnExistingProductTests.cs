using BillAppDDD.Modules.Bills.Domain.Products;
using System.Linq;
using Xunit;

namespace BillAppDDD.Modules.Bills.Tests.Bills.Bill
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
            bill.AddPurchaseBasedOnExistingProduct(product);

            //Assert
            Assert.Single(bill.Purchases);
            Assert.Equal(product,bill.Purchases.FirstOrDefault().Product);
        }
    }
}
