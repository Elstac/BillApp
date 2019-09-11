using MediatR;
using System;

namespace BillAppDDD.Modules.Bills.Application.Contracts
{
    public interface ICommand :IRequest
    {
        Guid Id { get;}
    }
}
