using System;
using System.Linq;
using System.Linq.Expressions;

namespace Heroes.WebApi.Infrastructure.Database.Extensions
{
    public static class FilterExtension
    {
        public static IQueryable<TModel> Filter<TModel>
        (
            this IQueryable<TModel> query,
            Expression<Func<TModel, bool>> filter
        )
            where TModel : class
        {
            return filter != null ? query.Where(filter) : query;
        }
    }
}
