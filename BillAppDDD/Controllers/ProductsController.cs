using BillAppDDD.Modules.Bills.Application.Bills.Dto;
using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Application.Products.AddProduct;
using BillAppDDD.Modules.Bills.Application.Products.AddProductCategory;
using BillAppDDD.Modules.Bills.Application.Products.AddProductToCategory;
using BillAppDDD.Modules.Bills.Application.Products.Dto;
using BillAppDDD.Modules.Bills.Application.Products.GetAllProductCategories;
using BillAppDDD.Modules.Bills.Application.Products.GetAllProducts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BillAppDDD.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private IBillsModule billsModule;

        public ProductsController(IBillsModule billsModule)
        {
            this.billsModule = billsModule;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            return await billsModule.ExecuteQueryAsync(new GetAllProducts());
        }

        [HttpPost("AddProduct")]
        public async Task AddProduct([FromBody]AddProductDto product)
        {
            await billsModule.ExecuteCommandAsync(new AddProduct
            {
                Name = product.Name,
                Barcode = product.Barcode,
                Price = product.Price,
                ProductCategoryId = product.ProductCategoryId
            }
            );
        }

        [HttpGet("Categories/GetAll")]
        public async Task<IEnumerable<ProductCategoryDto>> GetCategories()
        {
            return await billsModule.ExecuteQueryAsync(new GetAllProductCategories());
        }

        [HttpPost("Categories/AddCategory")]
        public async Task AddProduct([FromBody]AddCategoryDto category)
        {
            await billsModule.ExecuteCommandAsync(new AddProductCategory
            {
                Name = category.Name
            }
            );
        }

        [HttpPut("Categories/AddProduct")]
        public async Task AddProductToCategory([FromBody]AddProductToCategoryDto input)
        {
            await billsModule.ExecuteCommandAsync(new AddProductToCategory
            {
                CategoryId = Guid.Parse(input.CategoryId),
                ProductId = Guid.Parse(input.ProductId)
            }
            );
        }
    }
}
