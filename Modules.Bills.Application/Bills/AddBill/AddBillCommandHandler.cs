using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Domain.Bills;
using BillAppDDD.Modules.Bills.Domain.Products;
using BillAppDDD.Modules.Bills.Domain.Stores;
using BillAppDDD.Modules.Bills.Infrastructure;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Bills.AddBill
{
    public class AddBillCommandHandler : ICommandHandler<AddBill>
    {
        private IExtendedRepository<Bill> repository;
        private IExtendedRepository<Product> productRepository;
        private IExtendedRepository<Store> storeRepository;

        public AddBillCommandHandler(
            IExtendedRepository<Bill> repository,
            IExtendedRepository<Product> productRepository,
            IExtendedRepository<Store> storeRepository)
        {
            this.repository = repository;
            this.productRepository = productRepository;
            this.storeRepository = storeRepository;
        }

        public async Task<Unit> Handle(AddBill request, CancellationToken cancellationToken)
        {
            var input = request.BillInput;

            var productsIdCollection = input.Purchases.Select(p => p.Product.Id).ToList();

            var products = productRepository
                .Queryable()
                .Where(p => productsIdCollection.Contains(p.Id.ToString()))
                .ToList();

            var purchases = input.Purchases
                .Select(p => new Purchase(
                        products.FirstOrDefault(pr => pr.Id.ToString() == p.Product.Id),
                        p.Date,
                        p.Amount,
                        p.Price,
                        null
                    ))
                .ToList();

            var store = storeRepository
                .Queryable()
                .FirstOrDefault(s => s.Id.ToString() == input.StoreId);

            var toAdd = new Bill(input.Date,store,purchases);
            repository.InsertAggregate(toAdd);
            
            return Unit.Value;
        }
    }
}
