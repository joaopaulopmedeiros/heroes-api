using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Responses;

namespace Heroes.WebApi.Infrastructure.Database.Extensions
{
    public static class PaginationExtension
    {
        public static async Task<PaginationResponse<TModel>> PaginateAsync<TModel>
        (
            this IQueryable<TModel> query,
            int page,
            int limit
        )
            where TModel : class
        {

            var paged = new PaginationResponse<TModel>();

            page = SanitizePageParam(page);

            paged.CurrentPage = page;

            paged.PageSize = limit;

            var startRow = CalculateStartRow(page, limit);

            paged.Items = await query
                       .Skip(startRow)
                       .Take(limit)
                       .ToListAsync();

            paged.TotalItems = await query.CountAsync();

            paged.TotalPages = CalculateTotalPages(paged.TotalItems, limit);

            return paged;
        }

        private static int SanitizePageParam(int page)
        {
            return (page < 0) ? 1 : page;
        }

        private static int CalculateStartRow(int page, int limit)
        {
            return (page - 1) * limit;
        }

        private static int CalculateTotalPages(int totalItems, int limit)
        {
            return (int)Math.Ceiling(totalItems / (double)limit);
        }
    }
}
