using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace store.Models.Repository
{
    public class QueryOptionsRepository<T>: List<T>
    {
        public int _CurrentPage { get; set; }
        public int _PageSize { get; set; }
        public int _TotalPages { get; set; }

        public QueryOptionsRepository(List<T> items, int count, int currentPage, int pageSize)
        {
            _CurrentPage = currentPage;
            _PageSize = pageSize;

            _TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static async Task<QueryOptionsRepository<T>> CreateAsync(IQueryable<T> query, QueryOptions queryOptions = null)
        {
            if (queryOptions != null)
            {
                if (!string.IsNullOrEmpty(queryOptions.SortOrderName))
                {
                    query = Order(query, queryOptions.SortOrderName, queryOptions.SortOrder);
                }
                if (!string.IsNullOrEmpty(queryOptions.SearchPropertyName) && !string.IsNullOrEmpty(queryOptions.SearchValue))
                {
                    query = Search(query, queryOptions.SearchPropertyName, queryOptions.SearchValue);
                }
            }

            var count = await query.CountAsync();
            var items = await query.Skip((queryOptions.CurrentPage - 1) * queryOptions.PageSize).Take(queryOptions.PageSize).ToListAsync();
            return new QueryOptionsRepository<T>(items, count, queryOptions.CurrentPage, queryOptions.PageSize);
        }

        private static IQueryable<T> Order(IQueryable<T> query, string sortOrderName, string sortOrder)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var source = sortOrderName.Split('.').Aggregate((Expression)parameter,
                Expression.Property);
            var lambda = Expression.Lambda(typeof(Func<,>).MakeGenericType(typeof(T),
                source.Type), source, parameter);

            return typeof(Queryable).GetMethods().Single(
                    method => method.Name == ((sortOrder == "desc" ? true : false) ? "OrderByDescending"
                                : "OrderBy")
                    && method.IsGenericMethodDefinition
                    && method.GetGenericArguments().Length == 2
                    && method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), source.Type)
                .Invoke(null, new object[] { query, lambda }) as IQueryable<T>;
        }

        private static IQueryable<T> Search(IQueryable<T> query, string searchPropertyName, string searchValue)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var source = searchPropertyName.Split('.').Aggregate((Expression)parameter,
                Expression.Property);
            Console.WriteLine(source.ToString());

            var body = Expression.Call(source, "Contains", Type.EmptyTypes,
                Expression.Constant(searchValue, typeof(string)));

            var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
            return query.Where(lambda);
        }
    }
}
