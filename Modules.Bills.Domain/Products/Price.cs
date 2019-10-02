using BillAppDDD.BuildingBlocks.Domain;
using System;

namespace BillAppDDD.Modules.Bills.Domain.Products
{
    public class Price:ValueObject
    {

        private Price()
        {
        }

        public Price(float value)
        {
            this.Value = value;
        }

        public float Value { get; private set; }
    }
}
