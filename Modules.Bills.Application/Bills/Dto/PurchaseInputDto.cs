using BillAppDDD.Modules.Bills.Application.Products.Dto;
using System;

namespace BillAppDDD.Modules.Bills.Application.Bills.Dto
{
    public class PurchaseInputDto
    {
        public ProductDto Product { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public float Price { get; set; }
    }
}
