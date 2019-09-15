using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Application.Stores.Dto;
using System.Collections.Generic;

namespace BillAppDDD.Modules.Bills.Application.Stores.GetAllStores
{
    public class GetAllStores : IQuery<List<StoreDto>>
    {
    }
}
