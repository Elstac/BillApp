using System;

namespace BillAppDDD.Modules.Bills.Application.Contracts
{
    public abstract class CommandBase : ICommand
    {
        public Guid Id { get; }

        public CommandBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
