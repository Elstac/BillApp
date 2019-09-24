using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Application.Stores.AddStore;
using BillAppDDD.Modules.Bills.Application.Stores.Dto;
using BillAppDDD.Modules.Bills.Application.Stores.GetAllStores;
using BillAppDDD.Modules.Bills.Application.Stores.GetAllStoresTotalSpendings;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BillAppDDD.Controllers
{
    [Route("api/[controller]")]
    public class StoresController : Controller
    {
        private IBillsModule billsModule;

        public StoresController(IBillsModule billsModule)
        {
            this.billsModule = billsModule;
        }


        // GET: api/<controller>
        [HttpGet("GetAll")]
        public async Task< IEnumerable<StoreDetailsDto>> Get()
        {
            var storeCollection = await billsModule.ExecuteQueryAsync(new GetAllStores());
            return storeCollection;
        }

        [HttpGet("Spendings/GetAll")]
        public async Task<IEnumerable<StoreSpendingsDto>> GetSpendings()
        {
            var storeCollection = await billsModule.ExecuteQueryAsync(new GetAllStoresTotalSpendings());
            return storeCollection;
        }

        [HttpPost("Add")]
        public async Task AddStore(AddStoreRequest store)
        {
            await billsModule.ExecuteCommandAsync(new AddStore(store.Name));
        }
    }
}
