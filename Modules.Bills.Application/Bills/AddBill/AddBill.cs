using BillAppDDD.Modules.Bills.Application.Bills.Dto;
using BillAppDDD.Modules.Bills.Application.Contracts;
using System;

namespace BillAppDDD.Modules.Bills.Application.Bills.AddBill
{
    public class AddBill :CommandBase
    {
        public AddBill(
            DateTime date,
            string storeId,
            PurchaseInputDto[] purchases
            )
        {
            Date = date;
            StoreId = storeId;
            Purchases = purchases;
        }

        public DateTime Date { get; set; }
        public string StoreId { get; set; }
        public PurchaseInputDto[] Purchases { get; set; }
    }
}
