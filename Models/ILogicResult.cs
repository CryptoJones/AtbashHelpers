using System;
using System.Collections.Generic;
using Atbash.Helpers.Constants;
namespace Atbash.Helpers.Models
{
    public interface ILogicResult
    {
        bool Success { get; }

        List<LogicError> Errors { get; }

        string MessageText { get; set; }

        string FriendlyMessageText { get; set; }

        Severity Severity { get; set; }

        List<Exception> Exceptions { get; set; }
    }
}
