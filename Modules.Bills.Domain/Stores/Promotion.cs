using BillAppDDD.BuildingBlocks.Domain;
using System;

namespace BillAppDDD.Modules.Bills.Domain.Stores
{
    public class Promotion : Entity
    {
        public Promotion() : base(Guid.NewGuid())
        {

        }
        public string Name { get; set; }
    }
}
