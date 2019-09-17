using System;
using System.Collections.Generic;
using System.Text;

namespace BillAppDDD.Modules.Bills.Application.Products.AddProductToCategory
{
    public class AddProductToCategoryDto
    {
        public string ProductId { get; set; }
        public string CategoryId { get; set; }
    }
}
