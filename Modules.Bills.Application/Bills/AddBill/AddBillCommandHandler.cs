using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Domain.Bills;
using BillAppDDD.Modules.Bills.Domain.Products;
using BillAppDDD.Modules.Bills.Domain.Stores;
using BillAppDDD.Modules.Bills.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
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
        private IExtendedRepository<ProductCategory> categoryRepository;

        public AddBillCommandHandler(
            IExtendedRepository<Bill> repository,
            IExtendedRepository<Product> productRepository,
            IExtendedRepository<Store> storeRepository, 
            IExtendedRepository<ProductCategory> categoryRepository)
        {
            this.repository = repository;
            this.productRepository = productRepository;
            this.storeRepository = storeRepository;
            this.categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(AddBill request, CancellationToken cancellationToken)
        {
            if (request.Purchases.Count() == 0)
                throw new InvalidOperationException();

            var existingProductsIdCollection = request.Purchases
                .Where(p =>!string.IsNullOrEmpty(p.Product.Id))
                .Select(p => p.Product.Id)
                .ToList();

            var newProductsIdCollection = request.Purchases
                .Where(p => string.IsNullOrEmpty(p.Product.Id))
                .Select(p => p.Product.Id)
                .ToList();

            var products = productRepository
                .Queryable()
                .Where(p=>existingProductsIdCollection.Contains(p.Id.ToString()))
                .ToList();

            var categories = categoryRepository.Queryable().ToList();

            var newProductsPurchases = request.Purchases
                .Where(p => newProductsIdCollection.Contains(p.Product.Id))
                .Select(p =>new Purchase(
                    new Product(
                        p.Product.Name,
                        new ProductBarcode { Value = p.Product.Barcode },
                        new Price {Value = (p.Price/p.Amount) },
                        categories.FirstOrDefault(c=>c.Id.ToString() == p.Product.CategoryId)
                        ),
                    request.Date,
                    p.Amount,
                    p.Price,
                    null
                    )
                )
                .ToList();

            var purchases = new List<Purchase>();

            foreach (var product in products)
            {
                foreach (var purchaseDto in request.Purchases)
                {
                    if(product.Id.ToString() == purchaseDto.Product.Id)
                    {
                        purchases.Add(
                            new Purchase(
                                product,
                                request.Date,
                                purchaseDto.Amount,
                                purchaseDto.Price,
                                null
                            ));
                    }
                }
            }

            purchases.AddRange(newProductsPurchases);

            var store = storeRepository
                .Queryable()
                .FirstOrDefault(s=>s.Id == Guid.Parse(request.StoreId));

            var bill = new Bill(request.Date, store, purchases);

            repository.InsertAggregate(bill);

            return Unit.Value;
        }
    }
}
