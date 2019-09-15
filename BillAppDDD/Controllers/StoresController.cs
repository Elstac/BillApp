using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Application.Stores.Dto;
using BillAppDDD.Modules.Bills.Application.Stores.GetAllStores;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public async Task< IEnumerable<StoreDto>> Get()
        {
            return await billsModule.ExecuteQueryAsync(new GetAllStores());
        }
    }
}
