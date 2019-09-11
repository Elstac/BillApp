using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Application.Dto;

namespace BillAppDDD.Modules.Bills.Application.Bills.AddBill
{
    public class AddBill :CommandBase
    {
        public AddBill(BillInputDto billInput)
        {
            BillInput = billInput;
        }

        public BillInputDto BillInput{ get; set; }
    }
}
