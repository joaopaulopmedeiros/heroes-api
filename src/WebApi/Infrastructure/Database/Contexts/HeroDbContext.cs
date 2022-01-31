using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Models;
using WebApi.Infrastructure.Database.Mappers;

namespace WebApi.Infrastructure.Databse.Contexts
{
    public partial class HeroDbContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Comics> Comics { get; set; }

        public HeroDbContext()
        {
        }

        public HeroDbContext(DbContextOptions<HeroDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new HeroMapper());
            modelBuilder.ApplyConfiguration(new ComicsMapper());
        }
    }
}
