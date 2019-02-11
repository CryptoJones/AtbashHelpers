
namespace Atbash.Helpers.Models
{
    public class SearchResult<TRecord> : LogicResult, ISearchResult<TRecord>, ILogicResult
        where TRecord : class, new()
    {
        public SearchResult()
        {
            this.Model = new SearchModel<TRecord>();
        }

        public SearchResult(ISearchArgs args)
        {
            this.Model = new SearchModel<TRecord>(args);
        }

        public SearchModel<TRecord> Model { get; set; }
    }
}
