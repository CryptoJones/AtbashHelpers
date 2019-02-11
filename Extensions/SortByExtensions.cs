using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Atbash.Helpers.Constants;
using Atbash.Helpers.Models;
using System.Reflection;

namespace Atbash.Helpers.Extensions
{

    public static class SortByExtensions
    {
        private static IOrderedQueryable<T> SortOrderedQueryableBy<T>(
          this IQueryable<T> source,
          string propertyName,
          string keyword)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), string.Empty);
            MemberExpression memberExpression = Expression.PropertyOrField((Expression)parameterExpression, propertyName);
            Type[] typeArguments = new Type[2] { typeof(T), memberExpression.Type };
            UnaryExpression unaryExpression = Expression.Quote((Expression)Expression.Lambda((Expression)memberExpression, parameterExpression));
            MethodCallExpression methodCallExpression = Expression.Call(typeof(Queryable), keyword, typeArguments, source.Expression, (Expression)unaryExpression);
            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>((Expression)methodCallExpression);
        }

        public static IOrderedQueryable<T> SortBy<T, TKey>(
          this IQueryable<T> source,
          IEnumerable<Sort> sort,
          Expression<Func<T, TKey>> defaultSort,
          SortDirection defaultSortDirection = SortDirection.Asc)
        {
            IOrderedQueryable<T> source1 = (IOrderedQueryable<T>)source;
            List<Sort> scrubbedSortList = SortByExtensions.GetScrubbedSortList<T>(sort);
            if (!scrubbedSortList.Any<Sort>())
            {
                if (defaultSortDirection != SortDirection.Desc)
                    return source1.OrderBy<T, TKey>(defaultSort);
                return source1.OrderByDescending<T, TKey>(defaultSort);
            }
            for (int index = 0; index < scrubbedSortList.Count; ++index)
            {
                Sort sort1 = scrubbedSortList[index];
                string keyword = (index == 0 ? "OrderBy" : "ThenBy") + (sort1.Direction == SortDirection.Desc ? "Descending" : string.Empty);
                source1 = source1.SortOrderedQueryableBy<T>(sort1.Name, keyword);
            }
            return source1;
        }

        public static IOrderedEnumerable<T> SortBy<T, TKey>(
          this IEnumerable<T> source,
          IEnumerable<Sort> sort,
          Func<T, TKey> defaultSort,
          SortDirection defaultSortDirection = SortDirection.Asc)
        {
            IEnumerable<T> source1 = source;
            List<Sort> scrubbedSortList = SortByExtensions.GetScrubbedSortList<T>(sort);
            if (!scrubbedSortList.Any<Sort>())
            {
                if (defaultSortDirection != SortDirection.Desc)
                    return source1.OrderBy<T, TKey>(defaultSort);
                return source1.OrderByDescending<T, TKey>(defaultSort);
            }
            for (int index = 0; index < scrubbedSortList.Count; ++index)
            {
                Sort sort1 = scrubbedSortList[index];
                ParameterExpression parameterExpression = null;
                Func<T, object> keySelector = Expression.Lambda<Func<T, object>>((Expression)Expression.Convert((Expression)Expression.Property((Expression)parameterExpression, sort1.Name), typeof(object)), parameterExpression).Compile();
                source1 = index != 0 ? (sort1.Direction == SortDirection.Desc ? (IEnumerable<T>)((IOrderedEnumerable<T>)source1).ThenByDescending<T, object>(keySelector) : (IEnumerable<T>)((IOrderedEnumerable<T>)source1).ThenBy<T, object>(keySelector)) : (sort1.Direction == SortDirection.Desc ? (IEnumerable<T>)source1.OrderByDescending<T, object>(keySelector) : (IEnumerable<T>)source1.OrderBy<T, object>(keySelector));
            }
            return (IOrderedEnumerable<T>)source1;
        }

        private static List<Sort> GetScrubbedSortList<T>(IEnumerable<Sort> sort)
        {
            IEnumerable<string> inner = ((IEnumerable<PropertyInfo>)typeof(T).GetProperties()).Select<PropertyInfo, string>((Func<PropertyInfo, string>)(x => x.Name));
            return sort.Join(inner, (Func<Sort, string>)(x => x.Name.ToUpperInvariant()), (Func<string, string>)(p => p.ToUpperInvariant()), (x, p) => new { x = x, p = p }).Where(_param1 => (uint)_param1.x.Direction > 0U).OrderBy(_param1 => _param1.x.Priority).Select(_param1 => new Sort() { Name = _param1.p, Direction = _param1.x.Direction, Priority = _param1.x.Priority }).ToList<Sort>();
        }
    }
}
