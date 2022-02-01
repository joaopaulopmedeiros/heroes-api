using WebApi.Requests;
using WebApi.Responses;
using System.Threading.Tasks;
using WebApi.Infrastructure.Databse.Contexts;
using Microsoft.EntityFrameworkCore;
using Heroes.WebApi.Infrastructure.Database.Extensions;
using WebApi.Domain.Models;
using AutoMapper.QueryableExtensions;
using AutoMapper;

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