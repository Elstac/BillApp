using BillAppDDD.Modules.Bills.Domain.Products;

namespace BillAppDDD.Modules.Bills.Tests.Bills.ProductTests
{
    internal class ProductBuilder
    {
        private string name;
        private ProductBarcode barcode;
        private Price price;

        public ProductBuilder()
        {
            name = "";
            barcode = new ProductBarcode { Value = "" };
            price = new Price { Value = 0 };
        }

        public Product  Build()
        {
            return new Product(
                name,
                barcode,
                price,
                null);
        }
    }
}
