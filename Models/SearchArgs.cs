using System.Collections.Generic;

namespace Atbash.Helpers.Models
{
    public class SearchArgs : ISearchArgs
    {
        public SearchArgs()
        {
            this.Skip = 0;
            this.Take = 10;
            this.SortBy = new List<Sort>();
        }

        public int Skip { get; set; }

        public int Take { get; set; }

        public List<Sort> SortBy { get; set; }
    }
}
