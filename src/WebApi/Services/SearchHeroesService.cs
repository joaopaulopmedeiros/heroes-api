using WebApi.Requests;
using WebApi.Responses;
using System.Threading.Tasks;
using WebApi.Infrastructure.Databse.Contexts;
using Microsoft.EntityFrameworkCore;
using Heroes.WebApi.Infrastructure.Database.Extensions;
using WebApi.Domain.Models;

namespace WebApi.Services
{
    public class SearchHeroesService
    {
        private readonly HeroDbContext _context;

        public SearchHeroesService(HeroDbContext context)
        {
            _context = context;
        }

        public async Task<PaginationResponse<Hero>> SearchByAsync(GetAllHeroesRequest request)
        {
            return await _context.Heroes
                .Include(e => e.Comics)
                .Filter(new GetAllHeroesSpecification(request.Name, request.Power).Criteria())
                .PaginateAsync(request.CurrentPage, request.PerPage);
        }
    }
}