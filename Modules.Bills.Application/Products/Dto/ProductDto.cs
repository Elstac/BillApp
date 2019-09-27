using System;

namespace BillAppDDD.Modules.Bills.Application.Products.Dto
{
    public class ProductDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public float Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
