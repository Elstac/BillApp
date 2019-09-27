using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Domain.Stores;
using BillAppDDD.Modules.Bills.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Stores.AddStore
{
    class AddStoreCommandHandler : ICommandHandler<AddStore>
    {
        private IExtendedRepository<Store> storeRepository;

        public AddStoreCommandHandler(IExtendedRepository<Store> storeRepository)
        {
            this.storeRepository = storeRepository;
        }

        public async Task<Unit> Handle(AddStore request, CancellationToken cancellationToken)
        {
            var store = new Store(request.Name,request.ImagePath);

            storeRepository.Insert(store);

            return Unit.Value;
        }
    }
}
