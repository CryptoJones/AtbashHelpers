using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Atbash.Helpers.Misc
{

    public class EnumHelpers
    {
        public static IEnumerable<T> GetValues<T>() where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return (IEnumerable<T>)null;
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static IEnumerable<EnumHelpers.EnumHelper<T>> AsEnumHelpers<T>(
            Func<T, bool> predicate)
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return (IEnumerable<EnumHelpers.EnumHelper<T>>)null;
            return EnumHelpers.GetValues<T>().Select<T, EnumHelpers.EnumHelper<T>>((Func<T, EnumHelpers.EnumHelper<T>>)(x => new EnumHelpers.EnumHelper<T>(x)));
        }

        public class EnumHelper<T> where T : struct, IConvertible
        {
            public T Item { get; private set; }

            public string Description { get; private set; }

            public EnumHelper(T item)
            {
                this.Item = item;
                DescriptionAttribute customAttribute = item.GetType().GetField(item.ToString()).GetCustomAttribute<DescriptionAttribute>();
                this.Description = customAttribute != null ? customAttribute.Description : item.ToString();
            }
        }
    }
}
