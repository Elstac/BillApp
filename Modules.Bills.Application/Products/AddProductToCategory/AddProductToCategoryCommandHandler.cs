using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Domain.Products;
using BillAppDDD.Modules.Bills.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Products.AddProductToCategory
{
    class AddProductToCategoryCommandHandler : ICommandHandler<AddProductToCategory>
    {
        private IExtendedRepository<ProductCategory> categoryRepository;
        private IExtendedRepository<Product> productRepository;

        public AddProductToCategoryCommandHandler(
            IExtendedRepository<ProductCategory> categoryRepository,
            IExtendedRepository<Product> productRepository
            )
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }

        public async Task<Unit> Handle(AddProductToCategory request, CancellationToken cancellationToken)
        {
            var product = productRepository.Queryable().FirstOrDefault(p => p.Id == new ProductId(request.ProductId));

            var category = categoryRepository
                .Queryable()
                .Include(c => c.Products)
                .Include(c => c.Subcategories)
                .FirstOrDefault(c => c.Id.Value == request.CategoryId);

            category.AddProduct(product);

            categoryRepository.Update(category);

            return Unit.Value;
        }
    }
}
