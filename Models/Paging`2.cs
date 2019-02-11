using System.ComponentModel;

namespace Atbash.Helpers.Models
{
    [Description("Specify filtering, paging, sorting options for querying records and returning results")]
    public class Paging<TRecords, TFilter> : Paging<TRecords>, IPaging<TRecords, TFilter>, IPaging<TRecords>, IPaging
    {
        [Description("Additional query options")]
        public TFilter Filter { get; set; }
    }
}
