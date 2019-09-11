namespace BillAppDDD.Shared.Contracts
{
    public interface IOwner<TOwner>
    {
        TOwner Owner { get; set; }
    }
}
