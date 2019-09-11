using MediatR;

namespace BillAppDDD.Modules.Bills.Application.Contracts
{
    public interface IQuery<TResult>:IRequest<TResult>
    {
    }
}
