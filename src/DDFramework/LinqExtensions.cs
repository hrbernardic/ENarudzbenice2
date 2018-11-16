using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DDFramework
{
    public static class LinqExtensions
    {
        public static IQueryable<T> SortByPropertyString<T>(this IQueryable<T> query, string property, string order)
        {
            if (string.IsNullOrEmpty(property))
            {
                return query;
            }

            var prop = TypeDescriptor.GetProperties(typeof(T)).Find(property, true);
            return QueryHelpers.IsDescending(order) ? query.OrderByDescending(x => prop.GetValue(x)) : query.OrderBy(x => prop.GetValue(x));
        }

        public static async Task<QueryResult<T>> GetPagedAsync<T>(this IQueryable<T> query,
            int pageIndex = 0, int pageSize = 0) where T : class
        {
            var rowCount = query.Count();

            var result = new QueryResult<T>
            {
                PageIndex = pageIndex,
                PageSize = pageSize == 0 ? rowCount : pageSize,
                RowCount = rowCount
            };

            var pageCount = (double)result.RowCount / result.PageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = result.PageIndex * result.PageSize;
            result.Results = await query.Skip(skip).Take(result.PageSize).ToListAsync();

            return result;
        }
    }
}
