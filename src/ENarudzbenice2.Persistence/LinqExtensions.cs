using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using DDFramework;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace ENarudzbenice2.Persistence
{
    public static class LinqExtensions
    {
        

        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        public static IQueryable<T> Search<T>(this IQueryable<T> self, string keyword)
        {
            var predicate = False<T>();
            var likeMethod = typeof(DbFunctionsExtensions).GetMethod("Like", new[] { typeof(DbFunctions), typeof(string), typeof(string) });
            var intLikeMethod = typeof(ApplicationDbContext).GetMethod("IntegerLike");
            var properties = typeof(T).GetTypeInfo().DeclaredProperties;
            var excludedTypes = new[] { typeof(Guid), typeof(bool) };

            foreach (var propertyInfo in properties)
            {
                if (excludedTypes.Contains(propertyInfo.PropertyType))
                {
                    continue;
                }

                if (propertyInfo.GetGetMethod().IsVirtual)
                    continue;

                var parameter = Expression.Parameter(typeof(T), "x");
                var property = Expression.Property(parameter, propertyInfo);

                var propertyAsObject = Expression.Convert(property, typeof(object));
                var nullCheck = Expression.NotEqual(propertyAsObject, Expression.Constant(null, typeof(object)));

                var keywordExpression = Expression.Constant(keyword);

                MethodCallExpression contains;

                if (propertyInfo.PropertyType == typeof(int))
                {
                    contains = Expression.Call(intLikeMethod ?? throw new InvalidOperationException(),  property, Expression.Constant(keywordExpression.Value));
                }
                else
                {
                    contains = Expression.Call(null, likeMethod ?? throw new InvalidOperationException(), Expression.Constant(EF.Functions), property, Expression.Constant($"%{keywordExpression.Value}%"));
                }

                var lambda = Expression.Lambda(Expression.AndAlso(nullCheck, contains), parameter);

                predicate = Or<T>(predicate, (Expression<Func<T, bool>>)lambda);
            }
            return self.Where(predicate);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public static IQueryable<T> SortByPropertyString<T>(this IQueryable<T> query, string property, string order)
        {
            if (string.IsNullOrEmpty(property))
            {
                return query;
            }

            var prop = TypeDescriptor.GetProperties(typeof(T)).Find(property, true);
            return QueryHelpers.IsDescending(order) ? Queryable.OrderByDescending<T, object>(query, x => prop.GetValue(x)) : Queryable.OrderBy<T, object>(query, x => prop.GetValue(x));
        }

        public static async Task<TableQueryResponse<T>> GetPagedAsync<T>(this IQueryable<T> query, int pageIndex = 0, int pageSize = 0) where T : class
        {
            var rowCount = query.Count();

            var result = new TableQueryResponse<T>
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
