using BillAppDDD.Modules.Bills.Domain.Products;

namespace BillAppDDD.Modules.Bills.Tests.Bills.ProductTests
{
    internal class ProductBuilder
    {
        private string name;
        private ProductBarcode barcode;
        private MoneyValue price;

        public ProductBuilder()
        {
            name = "";
            barcode = new ProductBarcode("");
            price = new MoneyValue ( 0 );
        }

        public ProductBuilder WithName(string name)
        {
            this.name = name;

            return this;
        }

        public ProductBuilder WithBarcode(string value)
        {
            barcode = new ProductBarcode(value);

            return this;
        }
        public ProductBuilder WithPrice(float value)
        {
            price = new MoneyValue(value);

            return this;
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
