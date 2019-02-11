using System;
using System.Configuration;
using System.Globalization;
using System.Resources;


namespace Atbash.Helpers.Services
{

    public class LocalizeService : ILocalizeService
    {
        private static readonly Lazy<bool> ForceLocalization;
        public static Type DefaultType;
        private readonly ResourceManager _resourceManager;

        public LocalizeService(Type type)
        {
            if (type == (Type)null)
                type = LocalizeService.DefaultType;
            if (type == (Type)null)
                throw new ArgumentNullException("Resource File Type not Set");
            this._resourceManager = new ResourceManager(type.FullName, type.Assembly);
        }

        public string GetString(string key, CultureInfo cultureInfo)
        {
            string str = this._resourceManager.GetString(key, cultureInfo);
            if (str != null || !LocalizeService.ForceLocalization.Value)
                return str;
            throw new ApplicationException("Localized string not found for : " + key);
        }

        static LocalizeService()
        {
            bool result;
            LocalizeService.ForceLocalization = new Lazy<bool>((Func<bool>)(() => bool.TryParse(ConfigurationManager.AppSettings["RequireLocalization"], out result) & result));
        }
    }
}
