using BillAppDDD.Modules.Bills.Domain.Products;
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

        [Fact]
        public void New_product_has_changed_values()
        {
            //Arrange
            var product = new ProductBuilder().Build();

            //Act
            var newProduct = product.Update("name", new ProductBarcode("xx"), new Price(10), null);

            //Assert
            Assert.Equal("name", newProduct.Name);
            Assert.Equal("xx", newProduct.Barcode.Value);
            Assert.Equal(10, newProduct.Price.Value);
        }

        [Fact]
        public void New_product_has_unchanged_values_if_no_value_provided()
        {
            //Arrange
            var product = new ProductBuilder()
                .WithName("oldName")
                .WithBarcode("barcode")
                .WithPrice(2137)
                .Build();

            //Act
            var newProduct = product.Update("", null, null, null);

            //Assert
            Assert.Equal("oldName", newProduct.Name);
            Assert.Equal("barcode", newProduct.Barcode.Value);
            Assert.Equal(2137, newProduct.Price.Value);
        }
    }
}
