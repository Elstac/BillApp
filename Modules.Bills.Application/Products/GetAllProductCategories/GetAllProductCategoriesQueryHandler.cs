using AutoMapper;
using BillAppDDD.Modules.Bills.Application.Products.Dto;
using BillAppDDD.Modules.Bills.Domain.Products;
using BillAppDDD.Modules.Bills.Infrastructure;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Products.GetAllProductCategories
{
    class GetAllProductCategoriesQueryHandler : IRequestHandler<GetAllProductCategories, IEnumerable<ProductCategoryDto>>
    {
        private IExtendedRepository<ProductCategory> categoryRepository;
        private IMapper mapper;

        public GetAllProductCategoriesQueryHandler(IExtendedRepository<ProductCategory> categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductCategoryDto>> Handle(GetAllProductCategories request, CancellationToken cancellationToken)
        {
            var categoriesCollection = categoryRepository
                .Queryable()
                .ToList();

            return mapper.Map<ProductCategoryDto[]>(categoriesCollection);
        }
    }
}
