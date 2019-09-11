using System;
using BillAppDDD.BuildingBlocks.Domain;

namespace BillAppDDD.Modules.Bills.Domain.Bills
{
    public class Bill : Entity, IAggregateRoot
    {
        public DateTime Date { get; set; }

        public Bill(DateTime date) : base(Guid.NewGuid())
        {
            Date = date;
        }
    }
}
