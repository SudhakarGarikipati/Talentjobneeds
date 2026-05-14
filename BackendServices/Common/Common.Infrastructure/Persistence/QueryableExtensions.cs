using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure.Persistence
{
    public static class QueryableExtensions
    {
        // This method applies pagination to an IQueryable<T> based on the provided page number and page size.
        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            return query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        // This method applies sorting based on a property name. It uses reflection to get the property value.

        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, string sortBy) where T : class
        {
            if (string.IsNullOrEmpty(sortBy))
                return query;

            var propertyInfo = typeof(T)
                .GetProperty(sortBy);

            if (propertyInfo == null)
                throw new ArgumentException($"No property '{sortBy}' found on type '{typeof(T).Name}'");

            return query.OrderBy(e => propertyInfo.GetValue(e, null));
        }
    }
}
