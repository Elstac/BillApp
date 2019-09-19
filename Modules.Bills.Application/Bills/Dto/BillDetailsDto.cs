using BillAppDDD.Modules.Bills.Application.Products.Dto;
using BillAppDDD.Modules.Bills.Application.Stores.Dto;
using System;
using System.Collections.Generic;

namespace BillAppDDD.Modules.Bills.Application.Bills.Dto
{
    public class BillDetailsDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public StoreDto Store { get; set; }
        public float Sum { get; set; }
        public ICollection<PurchaseDto> Purchases { get; set; }
    }
}
