using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain.Models;

namespace WebApi.Infrastructure.Database.Mappers
{
    public class ComicsMapper : IEntityTypeConfiguration<Comics>
    {
        public void Configure(EntityTypeBuilder<Comics> builder)
        {
            builder.ToTable("comics");

            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.Property(e => e.Id).IsRequired();

            builder.Property(e => e.Name);
        }
    }
}
