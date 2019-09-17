using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Domain.Products;
using BillAppDDD.Modules.Bills.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Products.AddProductCategory
{
    class AddProductCategoryCommandHandler : ICommandHandler<AddProductCategory>
    {
        IExtendedRepository<ProductCategory> categoryRepository;

        public AddProductCategoryCommandHandler(IExtendedRepository<ProductCategory> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(AddProductCategory request, CancellationToken cancellationToken)
        {
            var category = new ProductCategory(request.Name);

            categoryRepository.Insert(category);

            return Unit.Value;
        }
    }
}
