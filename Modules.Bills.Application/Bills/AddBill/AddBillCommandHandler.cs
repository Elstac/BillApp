using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Domain.Bills;
using BillAppDDD.Modules.Bills.Domain.Products;
using BillAppDDD.Modules.Bills.Domain.Stores;
using BillAppDDD.Modules.Bills.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Bills.AddBill
{
    public class AddBillCommandHandler : ICommandHandler<AddBill>
    {
        private IExtendedRepository<Bill> repository;
        private IExtendedRepository<Store> storeRepository;
        private IExtendedRepository<Product> productRepository;
        private IExtendedRepository<ProductCategory> categoryRepository;

        public AddBillCommandHandler(
            IExtendedRepository<Bill> repository,
            IExtendedRepository<Store> storeRepository,
            IExtendedRepository<ProductCategory> categoryRepository,
            IExtendedRepository<Product> productRepository)
        {
            this.repository = repository;
            this.storeRepository = storeRepository;
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }

        public async Task<Unit> Handle(AddBill request, CancellationToken cancellationToken)
        {
            if (request.Purchases.Count() == 0)
                throw new InvalidOperationException();

            var store = storeRepository
                .Queryable()
                .FirstOrDefault(s => s.Id.Equals(new StoreId( request.StoreId)));

            var bill = new Bill(request.Date, store);

            var productsIds = request.Purchases
                .Where(p => p.Product.Id != Guid.Empty)
                .Select(pu =>new ProductId( pu.Product.Id ))
                .ToList();

            var x = productRepository
                .Queryable()
                .Where(p=>productsIds.Contains(p.Id))
                .ToList();

            var existingProducts = request.Purchases
                .Where(p => p.Product.Id != Guid.Empty)
                .Select(
                    p=> new
                        {
                            Product = x.FirstOrDefault(pr => pr.Id == new ProductId(p.Product.Id)),
                            p.Amount,
                            p.Price
                        }
                )
                .ToList();

            foreach (var product in existingProducts)
                bill.AddPurchaseBasedOnExistingProduct(product.Product,product.Amount,product.Price);

            var categories = categoryRepository.Queryable().ToList();

            var newProducts = request.Purchases
                .Where(p => p.Product.Id == Guid.Empty)
                .Select(
                p => new
                {
                    p.Product,
                    Category = categories.FirstOrDefault(c => c.Id.Value == p.Product.CategoryId),
                    p.Amount,
                    p.Price
                })
                .ToList();

            foreach (var product in newProducts)
            {
                var prod = product.Product;
                bill.AddPurchaseBasedOnNewProduct(
                    prod.Name,
                    prod.Barcode,
                    product.Category,
                    product.Amount,
                    product.Price
                    );
            }

            repository.InsertAggregate(bill);

            return Unit.Value;
        }
    }
}
