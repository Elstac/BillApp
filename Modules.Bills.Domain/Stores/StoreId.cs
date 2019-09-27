using BillAppDDD.BuildingBlocks.Domain;
using System;

namespace BillAppDDD.Modules.Bills.Domain.Stores
{
    public class StoreId : IdValueType
    {
        public StoreId(Guid value) : base(value)
        {
        }
    }
}
