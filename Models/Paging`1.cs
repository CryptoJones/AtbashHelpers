using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Atbash.Helpers.Attributes;
using Atbash.Helpers.Constants;

namespace Atbash.Helpers.Models
{
    public class Paging<TRecords> : IPaging<TRecords>, IPaging
    {
        private Severity? _severity;

        public Paging()
        {
            this.Skip = 0;
            this.Take = 10;
            this.Total = 0;
            this.Exceptions = new List<Exception>();
        }

        public Paging(int skip, int take)
        {
            this.Take = take <= 0 ? 10 : take;
            this.Skip = skip;
            this.Exceptions = new List<Exception>();
        }

        [Description("Number of records to skip before taking results")]
        public int Skip { get; set; }

        [Description("Maximum number of records to include in results")]
        public int Take { get; set; }

        [DocumentationOutputOnly]
        [Description("Total number of results available")]
        public int Total { get; set; }

        [Description("Number of result pages available with current query options")]
        public int PageCount
        {
            get
            {
                return (this.Total + this.Take - 1) / this.Take;
            }
        }

        [Description("Index of current result page")]
        public int CurrentPage
        {
            get
            {
                return this.Skip / this.Take + 1;
            }
        }

        [Description("Number of result batches available with current query options")]
        public int BatchCount
        {
            get
            {
                if (this.PageCount != 0)
                    return this.PageCount;
                return 1;
            }
        }

        [Description("Correct value of 'skip' for the previous page of results")]
        public int PrevSkip
        {
            get
            {
                if (this.Skip - this.Take <= 0)
                    return 0;
                return this.Skip - this.Take;
            }
        }

        [Description("Correct value of 'skip' for the next page of results")]
        public int NextSkip
        {
            get
            {
                return this.Skip + this.Take;
            }
        }

        [Description("Whether there are any results in previous pages")]
        public bool HasPrev
        {
            get
            {
                if (this.Skip > 0)
                    return this.Total > this.Take;
                return false;
            }
        }

        [Description("Whether there are any results in additional pages")]
        public bool HasNext
        {
            get
            {
                return this.Skip + this.Take < this.Total;
            }
        }

        [DocumentationOutputOnly]
        [Description("Query results")]
        public List<TRecords> Records { get; set; }

        [Description("List of sort properties")]
        public List<Sort> SortBy { get; set; }

        [JsonIgnore]
        public List<Exception> Exceptions { get; set; }

        [Description("Whether the query executed successfully")]
        public bool Success
        {
            get
            {
                return !this.Exceptions.Any<Exception>();
            }
        }

        [DocumentationOutputOnly]
        [Description("Severity of any errors")]
        public Severity Severity
        {
            get
            {
                return this._severity ?? Severity.None;
            }
            set
            {
                this._severity = new Severity?(value);
            }
        }

        [JsonIgnore]
        public string MessageText { get; set; }
    }
}
