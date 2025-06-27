using EnveloperWeb.Domain.Climas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnveloperWeb.Infrastructure.Persistance.Configurations
{
    public class ClimaConfiguration : IEntityTypeConfiguration<Clima>
    {
        public void Configure(EntityTypeBuilder<Clima> builder)
        {
            builder.ToTable("clima");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("id")
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                   .HasColumnName("nome")
                   .HasMaxLength(50)
                   .IsRequired();
        }
    }
}
