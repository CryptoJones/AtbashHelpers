
namespace Atbash.Helpers.Models
{
    public class SearchArgs<TFilter> : SearchArgs, ISearchArgs<TFilter>, ISearchArgs
    {
        public TFilter Filter { get; set; }
    }
}
