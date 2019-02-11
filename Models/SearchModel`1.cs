using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Atbash.Helpers.Attributes;
using Atbash.Helpers.Constants;

namespace Atbash.Helpers.Models
{
    public class SearchModel<TRecord>
    {
        public PagerModel Pager { get; set; }

        public List<TRecord> Records { get; set; }

        public List<Sort> SortBy { get; set; }

        public SearchModel()
        {
            this.Pager = new PagerModel();
            this.Records = new List<TRecord>();
            this.SortBy = new List<Sort>();
        }

        public SearchModel(ISearchArgs args)
        {
            this.Pager = new PagerModel(args.Skip, args.Take);
            this.Records = new List<TRecord>();
            this.SortBy = SearchModel<TRecord>.BuildSortBy(args.SortBy);
        }

        protected static List<Sort> BuildSortBy(List<Sort> list)
        {
            if (list == null || !list.Any<Sort>())
                list = ((IEnumerable<PropertyInfo>)typeof(TRecord).GetProperties()).SelectMany((Func<PropertyInfo, IEnumerable<SortByAttribute>>)(x => x.GetCustomAttributes(true).OfType<SortByAttribute>()), (x, p) => new
                {
                    x = x,
                    p = p
                }).OrderBy(_param1 => _param1.p.Priority).Select(_param1 => new Sort()
                {
                    Name = _param1.p.Name,
                    Direction = SortDirection.Asc
                }).ToList<Sort>();
            return list;
        }
    }
}
