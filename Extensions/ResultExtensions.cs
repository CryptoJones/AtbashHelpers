using System;
using System.Collections.Generic;
using Atbash.Helpers.Models;

namespace Atbash.Helpers.Extensions
{
    public static class ResultExtensions
    {
        public static T AddError<T>(this T result, LogicError logicError) where T : ILogicResult
        {
            result.Errors.Add(logicError);
            return result;
        }

        public static T AddErrors<T>(this T result, IEnumerable<LogicError> errors) where T : ILogicResult
        {
            result.Errors.AddRange(errors);
            return result;
        }
    }
}
