using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain.Models;

namespace WebApi.Infrastructure.Database.Mappers
{
    public class HeroMapper : IEntityTypeConfiguration<Hero>
    {
        public void Configure(EntityTypeBuilder<Hero> builder)
        {
            builder.ToTable("heroes");

            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.Property(e => e.Id).IsRequired();

            builder.Property(e => e.Name);

            builder.Property(e => e.Power);

            builder.Property(e => e.ComicsId).HasColumnName("comics_id");

            builder.HasOne(d => d.Comics).WithMany().HasForeignKey(d => d.ComicsId);
        }
    }
}
