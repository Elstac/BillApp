using AutoMapper;
using BillAppDDD.Modules.Bills.Application.Bills.Dto;
using BillAppDDD.Modules.Bills.Domain.Products;
using BillAppDDD.Modules.Bills.Infrastructure;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Products.GetAllProducts
{
    class GetAllProdutcsQueryHandler : IRequestHandler<GetAllProducts, ProductDto[]>
    {
        private IExtendedRepository<Product> productRepository;
        private IMapper mapper;

        public GetAllProdutcsQueryHandler(IExtendedRepository<Product> productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ProductDto[]> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            var productCollection = productRepository
                .Queryable()
                .ToArray();

            return mapper.Map<ProductDto[]>(productCollection);
        }
    }
}
