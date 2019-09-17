using BillAppDDD.Modules.Bills.Application.Contracts;

namespace BillAppDDD.Modules.Bills.Application.Products.AddProductCategory
{
    public class AddProductCategory: CommandBase
    {
        public string Name { get; set; }
    }
}
