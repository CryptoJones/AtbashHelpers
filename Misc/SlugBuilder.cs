using System;
using System.Collections.Generic;
using System.Text;

namespace Atbash.Helpers.Misc
{
    public class SlugBuilder
    {
        private static readonly Random Random = new Random();

        public static string Generate()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int num1 = 0;
            for (int index = 0; index < 9; ++index)
            {
                int num2 = SlugBuilder.Random.Next(0, 9);
                stringBuilder.Append(num2);
                num1 += num2 * index;
                if (index != 0 && index % 4 == 0)
                    stringBuilder.Append("-");
            }
            stringBuilder.Append(num1 % 10);
            return stringBuilder.ToString();
        }

        public static bool ValidateAccountNumber(string accountNumber)
        {
            string str = accountNumber.Replace(" ", "").Replace("-", "");
            if (str.Length != 10)
                return false;
            int num = 0;
            for (int index = 0; index < 9; ++index)
            {
                int numericValue = (int)char.GetNumericValue(str[index]);
                num += numericValue * index;
            }
            return num % 10 == (int)char.GetNumericValue(str[9]);
        }
    }
}
