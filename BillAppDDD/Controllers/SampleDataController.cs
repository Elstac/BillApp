using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillAppDDD.Modules.Bills.Application.Bills.AddBill;
using BillAppDDD.Modules.Bills.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BillAppDDD.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private IBillsModule billsModule;

        public SampleDataController(IBillsModule billsModule)
        {
            this.billsModule = billsModule;
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
