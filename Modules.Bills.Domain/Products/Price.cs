using BillAppDDD.BuildingBlocks.Domain;

namespace BillAppDDD.Modules.Bills.Domain.Products
{
    public class MoneyValue:ValueObject
    {

        private MoneyValue()
        {
        }

        public MoneyValue(float value)
        {
            this.Value = value;
        }

        public float Value { get; private set; }
    }
}
