using BillAppDDD.Modules.Bills.Application.Bills.Dto;
using System.Collections.Generic;

namespace BillAppDDD.Modules.Bills.Application.Stores.Dto
{
    public class StoreDetailsDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<BillDto> Bills { get; set; }
    }
}
