using Xunit;

namespace BillAppDDD.Modules.Bills.Tests.Bills.ProductTests
{
    public class UpdateTests
    {
        [Fact]
        public void Return_new_product_object()
        {
            //Arrange
            var product = new ProductBuilder().Build();

            //Act
            var newProduct = product.Update(null, null, null, null);

            //Assert
            Assert.NotEqual(product, newProduct);
        }
        [Fact]
        public void New_product_refers_to_old_one()
        {
            //Arrange
            var product = new ProductBuilder().Build();

            //Act
            var newProduct = product.Update(null, null, null, null);

            //Assert
            Assert.Equal(product, newProduct.LastVersion);
        }

    }
}
