using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BlogProject.Shared.Utilities.Extensions
{
    public static class LinqExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition ? query.Where(predicate) : query;
        }

        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> list, bool condition, Func<T, bool> predicate)
        {
            return condition ? list.Where(predicate) : list;
        }
    }
}
