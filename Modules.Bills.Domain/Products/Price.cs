namespace BillAppDDD.Modules.Bills.Domain.Products
{
    public class Price
    {
        public Price(float value)
        {
            Value = value;
        }

        public float Value { get; set; }
    }
}
