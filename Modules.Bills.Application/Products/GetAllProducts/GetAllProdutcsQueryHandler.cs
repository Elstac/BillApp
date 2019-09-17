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

        public GetAllProdutcsQueryHandler(IExtendedRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<ProductDto[]> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            var productCollection = productRepository
                .Queryable()
                .Select(p => new ProductDto
                {
                    Id = p.Id.ToString(),
                    Barcode = p.Barcode.Value,
                    Name = p.Name,
                    Price = p.Price.Value
                })
                .ToArray();

            return productCollection;
        }
    }
}
