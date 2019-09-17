using BillAppDDD.Modules.Bills.Application.Products.Dto;
using BillAppDDD.Modules.Bills.Domain.Products;
using BillAppDDD.Modules.Bills.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Products.GetAllProductCategories
{
    class GetAllProductCategoriesQueryHandler : IRequestHandler<GetAllProductCategories, IEnumerable<ProductCategoryDto>>
    {
        private IExtendedRepository<ProductCategory> categoryRepository;

        public GetAllProductCategoriesQueryHandler(IExtendedRepository<ProductCategory> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<ProductCategoryDto>> Handle(GetAllProductCategories request, CancellationToken cancellationToken)
        {
            var categoriesCollection = categoryRepository.
                Queryable()
                .Select(c => new ProductCategoryDto
                {
                    Name = c.Name,
                    Products = c.Products.Select(
                        p => new Bills.Dto.ProductDto
                        {
                            Name = p.Name,
                            Barcode = p.Barcode.Value,
                            Id = p.Id.ToString(),
                            Price = p.Price.Value
                        })
                    .ToList(),
                    SubCategories = c.Subcategories.Select(
                        sc => new ProductCategoryDto
                        {
                            Name = sc.Name
                        }
                        )
                    .ToList()
                })
                .ToList();

            return categoriesCollection;
        }
    }
}
