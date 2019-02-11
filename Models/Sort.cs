using System;
using System.Collections.Generic;

using System.ComponentModel;
using Atbash.Helpers.Constants;

namespace Atbash.Helpers.Models
{
    [Description("Sort options. Multiple sort options can be provided in the query string.")]
    public class Sort
    {
       
       [Description("Sort field name")]
        public string Name { get; set; }
        
        [Description("Sort direction")]
        public SortDirection Direction { get; set; }

        [Description("Priority index. Sorts with lower values are executed earlier")]
        public int Priority { get; set; }
    }
}
