using BillAppDDD.BuildingBlocks.Domain;
using System;

namespace BillAppDDD.Modules.Bills.Domain.Bills
{
    public class BillId : IdValueType
    {
        public BillId(Guid value) : base(value)
        {
        }
    }
}
