using System;

namespace BillAppDDD.Modules.Bills.Domain.Products
{
    public class Price
    {
        private float value;
        public Price(float value)
        {
            this.value = value;
        }

        public float Value { get => (float)Math.Round(value, 2);}
    }
}
