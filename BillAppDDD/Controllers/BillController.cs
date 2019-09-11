using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillAppDDD.Modules.Bills.Application.Bills.AddBill;
using BillAppDDD.Modules.Bills.Application.Bills.GetAllBills;
using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Application.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BillAppDDD.Controllers
{
    [Route("api/[controller]")]
    public class BillController : Controller
    {
        private IBillsModule billsModule;

        public BillController(IBillsModule billsModule)
        {
            this.billsModule = billsModule;
        }

        [HttpGet]
        public async Task<ICollection<BillDto>> AllBills()
        {
            var billsCollection = await billsModule.ExecuteQueryAsync(new GetAllBills());

            return billsCollection;
        }

        [HttpPost]
        public async Task<IActionResult> AddBill([FromBody]BillInputDto billInput)
        {
            await billsModule.ExecuteCommandAsync(new AddBill(billInput));

            return Ok();
        }
    }
}
