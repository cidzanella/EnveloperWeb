using EnveloperWeb.Domain.PDVs.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnveloperWeb.Infrastructure.Persistance.Configurations
{
    public class PDVConfiguration : IEntityTypeConfiguration<PDV>
    {
        public void Configure(EntityTypeBuilder<PDV> builder)
        {
            builder.ToTable("pdv");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasColumnName("id")
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                   .HasColumnName("nome")
                   .HasMaxLength(50)
                   .IsRequired();
        }
    }
}
