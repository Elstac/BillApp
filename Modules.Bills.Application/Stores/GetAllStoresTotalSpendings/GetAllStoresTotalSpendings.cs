using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Application.Stores.Dto;
using System.Collections.Generic;

namespace BillAppDDD.Modules.Bills.Application.Stores.GetAllStoresTotalSpendings
{
    public class GetAllStoresTotalSpendings:IQuery<List<StoreSpendingsDto>>
    {
    }
}
