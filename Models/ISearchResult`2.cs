using System;
using System.Collections.Generic;
using System.Text;

namespace Atbash.Helpers.Models
{
    public interface ISearchResult<TFilter, TRecord> : ISearchResult<TRecord>, ILogicResult
        where TFilter : class, new()
    {
        SearchModel<TFilter, TRecord> Model { get; set; }
    }
}
