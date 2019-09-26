using AutoMapper;
using BillAppDDD.Modules.Bills.Application.Products.Dto;
using BillAppDDD.Modules.Bills.Domain.Products;
using BillAppDDD.Modules.Bills.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Products.GetProductDetails
{
    class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetails, ProductDto>
    {
        private IExtendedRepository<Product> productRepo;
        private IMapper mapper;

        public GetProductDetailsQueryHandler(IExtendedRepository<Product> productRepo, IMapper mapper)
        {
            this.productRepo = productRepo;
            this.mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductDetails request, CancellationToken cancellationToken)
        {
            var product = productRepo
                .Queryable()
                .Include(p=>p.Barcode)
                .Include(p=>p.Price)
                .Include(p=>p.Category)
                .FirstOrDefault(p => p.Id == request.ProductId);

            return mapper.Map<ProductDto>(product);
        }
    }
}
