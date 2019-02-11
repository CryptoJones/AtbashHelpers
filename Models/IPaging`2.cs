
namespace Atbash.Helpers.Models
{
    public interface IPaging<TRecords, TFilter> : IPaging<TRecords>, IPaging
    {
        TFilter Filter { get; set; }
    }
}
