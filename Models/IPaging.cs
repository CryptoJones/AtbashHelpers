using System;
using System.Collections.Generic;
using Atbash.Helpers.Constants;

namespace Atbash.Helpers.Models
{

    public interface IPaging
    {
        int Skip { get; set; }

        int Take { get; set; }

        int Total { get; set; }

        int PageCount { get; }

        int CurrentPage { get; }

        int BatchCount { get; }

        int PrevSkip { get; }

        int NextSkip { get; }

        bool HasPrev { get; }

        bool HasNext { get; }

        bool Success { get; }

        List<Exception> Exceptions { get; set; }

        Severity Severity { get; set; }

        string MessageText { get; set; }
    }
}
