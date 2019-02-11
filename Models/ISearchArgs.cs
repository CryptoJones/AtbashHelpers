using System.Collections.Generic;

namespace Atbash.Helpers.Models
{
    public interface ISearchArgs
    {
        int Skip { get; set; }

        int Take { get; set; }

        List<Sort> SortBy { get; set; }
    }
}
