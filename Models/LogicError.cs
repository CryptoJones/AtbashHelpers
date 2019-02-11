using Atbash.Helpers.Constants;

namespace Atbash.Helpers.Models
{
    public class LogicError
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public Severity Severity { get; set; }

        public LogicError()
        {
        }

        public LogicError(string code, Severity severity = Severity.None)
        {
            this.Code = code;
            this.Severity = severity;
        }

        public LogicError(int id, string code, Severity severity = Severity.None)
        {
            this.Id = id;
            this.Code = code;
            this.Severity = severity;
        }
    }
}
