using System.Collections.Generic;

namespace Atbash.Helpers.Models
{
    public interface IPaging<TRecords> : IPaging
    {
        List<TRecords> Records { get; set; }

        List<Sort> SortBy { get; set; }
    }
}
