using BillAppDDD.Modules.Bills.Application.Bills.Dto;
using BillAppDDD.Modules.Bills.Application.Contracts;
using System;

namespace BillAppDDD.Modules.Bills.Application.Bills.GetBillDetails
{
    public class GetBillDetails:IQuery<BillDetailsDto>
    {
        public GetBillDetails(Guid billId)
        {
            BillId = billId;
        }

        public Guid BillId { get; set; }

    }
}
