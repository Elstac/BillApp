using BillAppDDD.Modules.Bills.Application.Bills.Dto;
using BillAppDDD.Modules.Bills.Application.Contracts;

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
