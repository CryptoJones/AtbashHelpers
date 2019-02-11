using System;
using System.Collections.Generic;
using System.Linq;
using Atbash.Helpers.Constants;

namespace Atbash.Helpers.Models
{
    public class LogicResult : ILogicResult
    {
        private Severity? _severity;

        public LogicResult()
        {
            this.Exceptions = new List<Exception>();
            this.Errors = new List<LogicError>();
        }

        public List<Exception> Exceptions { get; set; }

        public string MessageText { get; set; }

        public string FriendlyMessageText { get; set; }

        public bool Success
        {
            get
            {
                if (this.Exceptions.Any<Exception>())
                    return this.Errors.Any<LogicError>();
                return true;
            }
        }

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

        public List<LogicError> Errors { get; private set; }
    }
}
