using System;
using System.Text;

namespace BillAppDDD.Modules.Bills.Domain.Products
{
    public class ProductBarcode
    {
        private ProductBarcode()
        {

        }

        private const int maxLength = 10;
        public ProductBarcode(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static ProductBarcode GetRandomBarcode()
        {
            var rng = new Random();
            var sb = new StringBuilder();

            for (int i = 0; i < maxLength; i++)
                sb.Append(rng.Next(0, 10).ToString());

            return new ProductBarcode(sb.ToString());
        }
    }
}
