using System;

namespace BillAppDDD.Modules.Bills.Application.Bills.Dto
{
    public class ProductDto
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public float Price { get; set; }
    }
}
