using System;
using System.Text;

namespace Atbash.Helpers.Extensions
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string value)
        {
            if (value == null || value.Length < 2)
                return value;
            string[] strArray = value.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            StringBuilder stringBuilder = new StringBuilder(strArray[0].ToLower());
            for (int index = 1; index < strArray.Length; ++index)
                stringBuilder.Append(strArray[index].Substring(0, 1).ToUpper()).Append(strArray[index].Substring(1));
            return stringBuilder.ToString();
        }

        public static string ToPascalCase(this string value)
        {
            if (value == null)
                return value;
            if (value.Length < 2)
                return value.ToUpper();
            string[] strArray = value.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            string str1 = "";
            foreach (string str2 in strArray)
                str1 = str1 + str2.Substring(0, 1).ToUpper() + str2.Substring(1);
            return str1;
        }

        public static string ToFriendlySlug(this string title)
        {
            if (title == null)
                return "";
            int length1 = title.Length;
            bool flag = false;
            StringBuilder stringBuilder = new StringBuilder(length1);
            for (int index = 0; index < length1; ++index)
            {
                char c = title[index];
                if (c >= 'a' && c <= 'z' || c >= '0' && c <= '9')
                {
                    stringBuilder.Append(c);
                    flag = false;
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    stringBuilder.Append((char)((uint)c | 32U));
                    flag = false;
                }
                else if (c == ' ' || c == ',' || (c == '.' || c == '/') || (c == '\\' || c == '-' || (c == '_' || c == '=')))
                {
                    if (!flag && stringBuilder.Length > 0)
                    {
                        stringBuilder.Append('-');
                        flag = true;
                    }
                }
                else if (c >= '\x0080')
                {
                    int length2 = stringBuilder.Length;
                    stringBuilder.Append(StringExtensions.RemapInternationalCharToAscii(c));
                    int length3 = stringBuilder.Length;
                    if (length2 != length3)
                        flag = false;
                }
                if (index == 80)
                    break;
            }
            if (!flag)
                return stringBuilder.ToString();
            return stringBuilder.ToString().Substring(0, stringBuilder.Length - 1);
        }

        private static string RemapInternationalCharToAscii(char c)
        {
            string lowerInvariant = c.ToString().ToLowerInvariant();
            if ("àåáâäãåą".Contains(lowerInvariant))
                return "a";
            if ("èéêëę".Contains(lowerInvariant))
                return "e";
            if ("ìíîïı".Contains(lowerInvariant))
                return "i";
            if ("òóôõöøőð".Contains(lowerInvariant))
                return "o";
            if ("ùúûüŭů".Contains(lowerInvariant))
                return "u";
            if ("çćčĉ".Contains(lowerInvariant))
                return nameof(c);
            if ("żźž".Contains(lowerInvariant))
                return "z";
            if ("śşšŝ".Contains(lowerInvariant))
                return "s";
            if ("ñń".Contains(lowerInvariant))
                return "n";
            if ("ýÿ".Contains(lowerInvariant))
                return "y";
            if ("ğĝ".Contains(lowerInvariant))
                return "g";
            switch (c)
            {
                case 'Þ':
                    return "th";
                case 'ß':
                    return "ss";
                case 'đ':
                    return "d";
                case 'ĥ':
                    return "h";
                case 'ĵ':
                    return "j";
                case 'ł':
                    return "l";
                case 'ř':
                    return "r";
                default:
                    return "";
            }
        }
    }
}
