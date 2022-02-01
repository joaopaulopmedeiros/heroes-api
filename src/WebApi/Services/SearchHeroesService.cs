using AutoMapper;
using AutoMapper.QueryableExtensions;
using Heroes.WebApi.Infrastructure.Database.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApi.Infrastructure.Databse.Contexts;
using WebApi.Requests;
using WebApi.Responses;

namespace WebApi.Services
{
    public class SearchHeroesService
    {
        private readonly HeroDbContext _context;
        private readonly IConfigurationProvider _mappingConfig;

        public SearchHeroesService(HeroDbContext context, IConfigurationProvider mappingConfig)
        {
            _context = context;
            _mappingConfig = mappingConfig;
        }

        /// <summary>
        /// Get paginated heroes resource and apply filter by name/power if any informed (not null)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PaginationResponse<HeroResponse>> SearchByAsync(GetAllHeroesRequest request)
        {
            return await _context.Heroes
                .Include(e => e.Comics)
                .Filter(new GetAllHeroesSpecification(request.Name, request.Power).Criteria())
                .ProjectTo<HeroResponse>(_mappingConfig)
                .PaginateAsync(request.CurrentPage, request.PerPage);
        }
    }
}