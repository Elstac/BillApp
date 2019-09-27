using BillAppDDD.Modules.Bills.Application.Bills.AddBill;
using BillAppDDD.Modules.Bills.Application.Bills.Dto;
using BillAppDDD.Modules.Bills.Application.Products.Dto;
using BillAppDDD.Modules.Bills.Domain.Bills;
using BillAppDDD.Modules.Bills.Domain.Products;
using BillAppDDD.Modules.Bills.Domain.Stores;
using BillAppDDD.Modules.Bills.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;


namespace BillAppDDD.Modules.Bills.Tests
{
    class HandlerBuilder
    {
        private IExtendedRepository<Bill> billRepo;
        private IExtendedRepository<Store> storeRepo;
        private IExtendedRepository<Product> productRepo;
        private IExtendedRepository<ProductCategory> categoryRepo;

        public HandlerBuilder()
        {
            billRepo = new Mock<IExtendedRepository<Bill>>().Object;
            storeRepo = new Mock<IExtendedRepository<Store>>().Object;
            productRepo = new Mock<IExtendedRepository<Product>>().Object;
            categoryRepo = new Mock<IExtendedRepository<ProductCategory>>().Object;
        }

        public HandlerBuilder WithBillInterceptor(RepositoryInterceptor<Bill> interceptor)
        {
            billRepo = interceptor;
            return this;
        }

        public HandlerBuilder WithCustomProductRepo(List<Product> repoReturn)
        {
            var mock = new Mock<IExtendedRepository<Product>>();
            mock.Setup(p => p.Queryable()).Returns(repoReturn.AsQueryable());

            productRepo = mock.Object;

            return this;
        }

        public HandlerBuilder WithCustomStoreRepo(List<Store> repoReturn)
        {
            var mock = new Mock<IExtendedRepository<Store>>();
            mock.Setup(p => p.Queryable()).Returns(repoReturn.AsQueryable());

            storeRepo = mock.Object;

            return this;
        }
        public HandlerBuilder WithCustomCategoryRepo(List<ProductCategory> repoReturn)
        {
            var mock = new Mock<IExtendedRepository<ProductCategory>>();
            mock.Setup(p => p.Queryable()).Returns(repoReturn.AsQueryable());

            categoryRepo = mock.Object;

            return this;
        }

        public AddBillCommandHandler Build()
        {
            return new AddBillCommandHandler(billRepo, storeRepo,categoryRepo,productRepo);
        }
    }

    public class AddBillTests
    {
        [Fact]
        public void Throw_if_no_purchases()
        {
            var command = new AddBill(new DateTime(), Guid.NewGuid(), new PurchaseInputDto[] { });
            var handler = new HandlerBuilder().Build();

            Assert.ThrowsAsync<InvalidOperationException>(
                () => handler.Handle(command, CancellationToken.None)
                );
        }

        
        [Fact]
        public async void Create_collection_of_products_from_dtos_with_epmty_ids()
        {
            //Arrange
            var billInterceptor = new RepositoryInterceptor<Bill>();

            var handler = new HandlerBuilder()
                .WithBillInterceptor(billInterceptor)
                .Build();

            var command = new AddBill(
                new DateTime(),
                Guid.NewGuid(),
                new PurchaseInputDto[] {
                    new PurchaseInputDto{Product = new ProductDto{Id = Guid.Empty, Barcode="AXD"}},
                    new PurchaseInputDto{Product = new ProductDto{Id = Guid.Empty, Barcode="33"}},
                    new PurchaseInputDto{Product = new ProductDto{Id = Guid.Empty, Barcode="null"}}
                }
                );

            //Act
            await handler.Handle(command, CancellationToken.None);
            var createdBill = billInterceptor.InterceptedEntity;

            //Assert
            Assert.NotNull(createdBill.Purchases);
            Assert.Equal(3, createdBill.Purchases.Count);
            Assert.NotNull(createdBill.Purchases.FirstOrDefault(p => p.Product.Barcode.Value == "AXD"));
            Assert.NotNull(createdBill.Purchases.FirstOrDefault(p => p.Product.Barcode.Value == "33"));
            Assert.NotNull(createdBill.Purchases.FirstOrDefault(p => p.Product.Barcode.Value == "null"));
        }

        [Fact]
        public async void New_purchases_contains_amount_and_cost_data()
        {
            //Arrange
            var billInterceptor = new RepositoryInterceptor<Bill>();

            var products = new List<Product>
            {
                new Product("",ProductBarcode.GetRandomBarcode(),new Price(1),null)
            };

            var handler = new HandlerBuilder()
                .WithBillInterceptor(billInterceptor)
                .WithCustomProductRepo(products)
                .Build();

            var command = new AddBill(
                new DateTime(),
                Guid.NewGuid(),
                new PurchaseInputDto[] {
                    new PurchaseInputDto{Product = new ProductDto{},Amount = 10, Price = 15},
                    new PurchaseInputDto{Product = new ProductDto{Id = products[0].Id }, Amount = 5, Price = 4}
                }
                );

            //Act
            await handler.Handle(command, CancellationToken.None);
            var createdBill = billInterceptor.InterceptedEntity;

            //Assert
            Assert.Equal(2, createdBill.Purchases.Count);
            Assert.NotNull(createdBill.Purchases.FirstOrDefault(p => p.Amount == 10 && p.Cost == 15));
            Assert.NotNull(createdBill.Purchases.FirstOrDefault(p => p.Amount == 5 && p.Cost == 4));
        }

        [Fact]
        public async void Purchases_date_is_same_as_bill_from_command()
        {
            //Arrange
            var billInterceptor = new RepositoryInterceptor<Bill>();

            var products = new List<Product>
            {
                new Product("",ProductBarcode.GetRandomBarcode(),new Price(1),null)
            };

            var billDate = new DateTime(2019, 5, 11);

            var handler = new HandlerBuilder()
                .WithBillInterceptor(billInterceptor)
                .WithCustomProductRepo(products)
                .Build();

            var command = new AddBill(
                billDate,
                Guid.NewGuid(),
                new PurchaseInputDto[] {
                    new PurchaseInputDto{Product = new ProductDto{}},
                    new PurchaseInputDto{Product = new ProductDto{Id = products[0].Id}}
                }
                );

            //Act
            await handler.Handle(command, CancellationToken.None);
            var createdBill = billInterceptor.InterceptedEntity;

            //Assert
            Assert.Equal(2, createdBill.Purchases.Where(p => p.Date == billDate).ToList().Count);
        }

        [Fact]
        public async void Add_store_from_repo_to_bill()
        {
            ////Arrange
            //var billInterceptor = new RepositoryInterceptor<Bill>();

            //var expectedStore = new Store();
            //var stores = new List<Store>
            //{
            //    expectedStore,
            //    new Store()
            //};

            //var handler = new HandlerBuilder()
            //    .WithBillInterceptor(billInterceptor)
            //    .WithCustomStoreRepo(stores)
            //    .Build();

            //var command = new AddBill(
            //    new DateTime(),
            //    expectedStore.Id.ToString(),
            //    new PurchaseInputDto[] {
            //        new PurchaseInputDto{Product = new ProductDto{}}
            //    }
            //    );

            ////Act
            //await handler.Handle(command, CancellationToken.None);
            //var createdBill = billInterceptor.InterceptedEntity;

            ////Assert
            //Assert.Equal(expectedStore, createdBill.Store);
        }

        [Fact]
        public async void Newly_created_product_contains_price_equal_to_cost_divided_by_amount()
        {
            //Arrange
            var billInterceptor = new RepositoryInterceptor<Bill>();

            var handler = new HandlerBuilder()
                .WithBillInterceptor(billInterceptor)
                .Build();

            var command = new AddBill(
                new DateTime(),
                Guid.NewGuid(),
                new PurchaseInputDto[] {
                    new PurchaseInputDto{Product = new ProductDto{Id = Guid.Empty, Barcode="AXD"},Price=10,Amount=2},
                }
                );

            //Act
            await handler.Handle(command, CancellationToken.None);
            var createdBill = billInterceptor.InterceptedEntity;

            //Assert
            Assert.NotNull(createdBill.Purchases);
            Assert.Equal(1, createdBill.Purchases.Count);
            Assert.NotNull(createdBill.Purchases.FirstOrDefault(p => p.Product.Price.Value == 5));
        }
    }
}
