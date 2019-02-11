using System;
using System.Collections.Generic;
using System.Text;

namespace Atbash.Helpers.Models
{
    public class PagerModel
    {
        public int Skip { get; set; }

        public int Take { get; set; }

        public int Total { get; set; }

        public int PageCount
        {
            get
            {
                return (this.Total + this.Take - 1) / this.Take;
            }
        }

        public int CurrentPage
        {
            get
            {
                return this.Skip / this.Take + 1;
            }
        }

        public int PrevSkip
        {
            get
            {
                if (this.Skip - this.Take <= 0)
                    return 0;
                return this.Skip - this.Take;
            }
        }

        public int NextSkip
        {
            get
            {
                if (!this.HasNext)
                    return this.Skip;
                return this.Skip + this.Take;
            }
        }

        public bool HasPrev
        {
            get
            {
                if (this.Skip > 0)
                    return this.Total > this.Take;
                return false;
            }
        }

        public bool HasNext
        {
            get
            {
                return this.Skip + this.Take < this.Total;
            }
        }

        public PagerModel()
            : this(0, 10)
        {
        }

        public PagerModel(int skip, int take)
        {
            this.Skip = skip;
            this.Take = take;
        }
    }
}
