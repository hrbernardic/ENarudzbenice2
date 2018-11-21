using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
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

        public static IQueryable<T> SearchAllProperties<T>(this IQueryable<T> queryable, string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return queryable;
            }

            var result = queryable;
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (property.Name == "Id")
                {
                    continue;
                }

                var prop = TypeDescriptor.GetProperties(typeof(T)).Find(property.Name, true);

                result = result.Where(x => prop.GetValue(x).ToString().Contains(filter));
            }

            return queryable;
        }

        public static IQueryable<T> CreateSearchQuery<T>(this IQueryable<T> queryable, string filter) where T : class
        {
            if (string.IsNullOrEmpty(filter))
            {
                return queryable;
            }

            var result = queryable;

            var predicate = PredicateBuilder.New<T>();

            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.Name == "Id")
                {
                    continue;
                }

                var property = TypeDescriptor.GetProperties(typeof(T)).Find(prop.Name, true);

                predicate = predicate.Or(t => property.GetValue(t).ToString().Contains(filter));
            }

            return result.Where(predicate);


            var expressions = new List<Expression>();

            var parameter = Expression.Parameter(typeof(T), "p");

            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var toStringMethod = typeof(object).GetMethod("ToString");

            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.Name == "Id")
                {
                    continue;
                }

                var memberExpression = Expression.PropertyOrField(parameter, prop.Name);

                var valueExpression = Expression.Constant(filter, typeof(string));

                var containsExpression = Expression.Call(Expression.Call(memberExpression, toStringMethod), containsMethod, valueExpression);

                expressions.Add(containsExpression);
            }

            if (expressions.Count == 0)
                return result;

            var orExpression = expressions[0];

            for (var i = 1; i < expressions.Count; i++)
            {
                orExpression = Expression.Or(orExpression, expressions[i]);
            }

            var expression = Expression.Lambda<Func<T, bool>>(
                orExpression, parameter);

            return result.Where(expression);
        }

        

        public static async Task<QueryResponse<T>> GetPagedAsync<T>(this IQueryable<T> query, int pageIndex = 0, int pageSize = 0) where T : class
        {
            var rowCount = query.Count();

            var result = new QueryResponse<T>
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
