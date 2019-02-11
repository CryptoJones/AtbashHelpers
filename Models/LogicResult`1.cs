namespace Atbash.Helpers.Models
{
    public class LogicResult<T> : LogicResult, ILogicResult<T>, ILogicResult
    {
        public LogicResult()
        {
        }

        public LogicResult(ILogicResult result)
        {
            this.Model = default(T);
            this.Exceptions = result.Exceptions;
            this.MessageText = result.MessageText;
            this.FriendlyMessageText = result.FriendlyMessageText;
            this.Severity = result.Severity;
        }

        public T Model { get; set; }
    }
}
