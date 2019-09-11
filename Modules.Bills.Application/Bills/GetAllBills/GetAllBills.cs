using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Application.Dto;
using System.Collections.Generic;

namespace BillAppDDD.Modules.Bills.Application.Bills.GetAllBills
{
    public class GetAllBills : IQuery<List<BillDto>>
    {
        public GetAllBills()
        {
        }
    }
}
