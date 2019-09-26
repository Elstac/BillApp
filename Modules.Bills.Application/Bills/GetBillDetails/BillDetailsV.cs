using System;

namespace BillAppDDD.Modules.Bills.Application.Bills.GetBillDetails
{
    internal class BillDetailsV
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid StoreId { get; set; }
        public string StoreName { get; set; }
        public string PurchasesJSON { get; set; }
    }
}
