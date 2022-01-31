using WebApi.Requests;
using WebApi.Responses;
using System.Threading.Tasks;
using WebApi.Infrastructure.Databse.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebApi.Services
{
    public class SearchHeroesService
    {
        private readonly HeroDbContext _context;

        public SearchHeroesService(HeroDbContext context)
        {
            _context = context;
        }

        public async Task<HeroCatalog> SearchByAsync(GetAllHeroesRequest request)
        {
            var result = await _context.Heroes
                .Skip((request.CurrentPage - 1) * request.PerPage)
                .Take(request.PerPage)
                .Include(e => e.Comics)
                .ToListAsync();

           return new HeroCatalog(result);
        }
    }
}