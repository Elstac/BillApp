using BillAppDDD.Modules.Bills.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillAppDDD.Modules.Bills.Application.Products.AddProductToCategory
{
    public class AddProductToCategory : CommandBase
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
