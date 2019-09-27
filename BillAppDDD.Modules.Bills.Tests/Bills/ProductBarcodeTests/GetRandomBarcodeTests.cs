using BillAppDDD.Modules.Bills.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BillAppDDD.Modules.Bills.Tests.Bills.ProductBarcodeTests
{
    public class GetRandomBarcodeTests
    {
        [Fact]
        public void Return_new_barcode_with_length_equal_10()
        {
            //Act
            var result = ProductBarcode.GetRandomBarcode();

            //Assert
            Assert.Equal(10, result.Value.Length);
        }

        [Fact]
        public void Returned_barcode_contains_only_digits()
        {
            //Act
            var result = ProductBarcode.GetRandomBarcode();

            //Assert
            foreach (var character in result.Value)
                Assert.InRange(character, '0', '9');
        }
    }
}
