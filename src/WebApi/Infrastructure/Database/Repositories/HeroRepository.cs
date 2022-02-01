using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Infrastructure.Database.Extensions;
using WebApi.Infrastructure.Database.Specifications;
using WebApi.Infrastructure.Databse.Contexts;

namespace WebApi.Infrastructure.Database.Repositories
{
    public class HeroRepository
    {
        private readonly HeroDbContext _context;

        public HeroRepository(HeroDbContext context)
        {
            _context = context;
        }

        public IQueryable FilterBySpec(GetAllHeroesSpecification spec)
        {
            return _context.Heroes
                .Include(e => e.Comics)
                .Filter(spec.Criteria());
        }
    }
}
