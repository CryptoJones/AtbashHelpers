using System.ComponentModel;

namespace Atbash.Helpers.Constants
{
    [Description("Error severity level")]
    public enum Severity
    {
        None,
        Retry,
        Warn,
        Critical,
        Fatal,
    }
}
