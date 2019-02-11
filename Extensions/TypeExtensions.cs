using System;
using System.Collections.Generic;
using System.Linq;

namespace Atbash.Helpers.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsAssignableToGenericType(this Type givenType, Type genericType)
        {
            if (((IEnumerable<Type>)givenType.GetInterfaces()).Any<Type>((Func<Type, bool>)(it =>
            {
                if (it.IsGenericType)
                    return it.GetGenericTypeDefinition() == genericType;
                return false;
            })) || givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;
            Type baseType = givenType.BaseType;
            if (baseType == (Type)null)
                return false;
            return baseType.IsAssignableToGenericType(genericType);
        }
    }
}
