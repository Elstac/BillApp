using BillAppDDD.Modules.Bills.Application.Stores.Dto;
using BillAppDDD.Modules.Bills.Domain.Products;
using System;

namespace BillAppDDD.Modules.Bills.Application.Bills.Dto
{
    public class BillDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public StoreDto Store { get; set; }
        public MoneyValue Sum { get; set; }
    }
}
