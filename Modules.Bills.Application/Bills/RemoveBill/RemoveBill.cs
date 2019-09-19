using BillAppDDD.Modules.Bills.Application.Contracts;
using System;

namespace BillAppDDD.Modules.Bills.Application.Bills.RemoveBill
{
    public class RemoveBill: ICommand
    {
        public RemoveBill(Guid billId)
        {
            BillId = billId;
        }

        public Guid BillId { get; set; }

        public Guid Id { get; }
    }
}
