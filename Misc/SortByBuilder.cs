using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Atbash.Helpers.Attributes;
using Atbash.Helpers.Models;

namespace Atbash.Helpers.Misc
{
    public class SortByBuilder
    {
        public static List<Sort> Build<T>(List<Sort> list)
        {
            if (list == null || !list.Any<Sort>())
                list = ((IEnumerable<PropertyInfo>)typeof(T).GetProperties()).SelectMany((Func<PropertyInfo, IEnumerable<SortByAttribute>>)(x => x.GetCustomAttributes(true).OfType<SortByAttribute>()), (x, p) => new
                {
                    x = x,
                    p = p
                }).OrderBy(_param1 => _param1.p.Priority).Select(_param1 => new Sort()
                {
                    Name = _param1.p.Name,
                    Direction = _param1.p.Direction,
                    Priority = _param1.p.Priority
                }).ToList<Sort>();
            return list;
        }
    }
}
