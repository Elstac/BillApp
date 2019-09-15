using System;
using System.Collections.Generic;

namespace BillAppDDD.Modules.Bills.Application.Bills.Dto
{
    public class BillInputDto
    {
        public DateTime Date { get; set; }
        public string StoreId { get; set; }
        public PurchaseInputDto[] Purchases { get; set; }
    }
}
