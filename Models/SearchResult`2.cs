
namespace Atbash.Helpers.Models
{
    public class SearchResult<TFilter, TRecord> : SearchResult<TRecord>, ISearchResult<TFilter, TRecord>, ISearchResult<TRecord>, ILogicResult
        where TFilter : class, new()
        where TRecord : class, new()
    {
        public SearchResult()
        {
            this.Model = new SearchModel<TFilter, TRecord>();
        }

        public SearchResult(ISearchArgs<TFilter> args)
        {
            this.Model = new SearchModel<TFilter, TRecord>(args);
        }

        public SearchModel<TFilter, TRecord> Model { get; set; }
    }
}
