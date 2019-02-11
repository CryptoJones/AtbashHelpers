using System;
using System.Collections.Generic;
using System.Text;

namespace Atbash.Helpers.Models
{
    public interface ILogicResult<T> : ILogicResult
    {
        T Model { get; set; }
    }
}
