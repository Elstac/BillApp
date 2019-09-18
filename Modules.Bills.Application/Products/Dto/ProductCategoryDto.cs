using BillAppDDD.Modules.Bills.Application.Bills.Dto;
using System;
using System.Collections.Generic;

namespace BillAppDDD.Modules.Bills.Application.Products.Dto
{
    public class ProductCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ProductDto> Products { get; set; }
        public List<ProductCategoryDto> SubCategories { get; set; }
    }
}
