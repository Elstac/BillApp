namespace BillAppDDD.Modules.Bills.Domain.Products
{
    public class ProductBarcode
    {
        public ProductBarcode(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}
