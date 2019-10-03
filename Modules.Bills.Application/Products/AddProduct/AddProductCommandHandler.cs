using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Domain.Products;
using BillAppDDD.Modules.Bills.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Products.AddProduct
{
    class AddProductCommandHandler : ICommandHandler<AddProduct>
    {
        private IExtendedRepository<Product> productRepository;
        private IExtendedRepository<ProductCategory> productCategoryRepository;

        public AddProductCommandHandler(
            IExtendedRepository<Product> productRepository,
            IExtendedRepository<ProductCategory> productCategoryRepository
            )
        {
            this.productRepository = productRepository;
            this.productCategoryRepository = productCategoryRepository;
        }

        public async Task<Unit> Handle(AddProduct request, CancellationToken cancellationToken)
        {
            var category = productCategoryRepository
                .Queryable()
                .FirstOrDefault(c => c.Id.ToString() == request.ProductCategoryId);

            var product = new Product(
                request.Name,
                new ProductBarcode(request.Barcode), 
                new MoneyValue(request.Price), 
                category
                );

            productRepository.InsertAggregate(product);

            return Unit.Value;
        }
    }
}
