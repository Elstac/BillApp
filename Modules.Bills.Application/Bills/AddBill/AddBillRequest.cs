using System;

namespace BillAppDDD.Modules.Bills.Application.Bills.Dto
{
    public class AddBillRequest
    {
        public DateTime Date { get; set; }
        public Guid StoreId { get; set; }
        public PurchaseInputDto[] Purchases { get; set; }
    }
}
