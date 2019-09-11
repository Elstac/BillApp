using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Contracts
{
    public interface IBillsModule
    {
        Task ExecuteCommandAsync(ICommand command);
        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
