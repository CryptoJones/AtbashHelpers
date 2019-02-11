namespace Atbash.Helpers.Models
{
    public interface ISearchResult<TRecord> : ILogicResult
    {
        SearchModel<TRecord> Model { get; set; }
    }
}
