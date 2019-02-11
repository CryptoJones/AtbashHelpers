using System.Collections.Generic;

namespace Atbash.Helpers.Models
{

    public class SearchModel<TFilter, TRecord> : SearchModel<TRecord> where TFilter : class, new()
    {
        public TFilter Filter { get; set; }

        public SearchModel()
        {
            this.Filter = new TFilter();
            this.Pager = new PagerModel();
            this.Records = new List<TRecord>();
            this.SortBy = new List<Sort>();
        }

        public SearchModel(ISearchArgs<TFilter> args)
        {
            TFilter filter = args.Filter;
            if ((object)filter == null)
                filter = new TFilter();
            this.Filter = filter;
            this.Pager = new PagerModel(args.Skip, args.Take);
            this.Records = new List<TRecord>();
            this.SortBy = SearchModel<TRecord>.BuildSortBy(args.SortBy);
        }
    }
}
