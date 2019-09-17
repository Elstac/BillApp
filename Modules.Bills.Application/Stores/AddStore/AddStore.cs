using BillAppDDD.Modules.Bills.Application.Contracts;

namespace BillAppDDD.Modules.Bills.Application.Stores.AddStore
{
    public class AddStore : CommandBase
    {
        public AddStore(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
