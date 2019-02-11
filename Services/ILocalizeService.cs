using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Atbash.Helpers.Services
{
    public interface ILocalizeService
    {
        string GetString(string key, CultureInfo cultureInfo);
    }
}
