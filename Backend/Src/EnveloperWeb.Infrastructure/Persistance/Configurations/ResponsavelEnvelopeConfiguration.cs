using EnveloperWeb.Domain.Responsaveis.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnveloperWeb.Infrastructure.Persistance.Configurations
{
    public class ResponsavelEnvelopeConfiguration : IEntityTypeConfiguration<ResponsavelEnvelope>
    {
        public void Configure(EntityTypeBuilder<ResponsavelEnvelope> builder)
        {
            builder.ToTable("responsavel_envelope");

            builder.HasKey(r => new { r.EnvelopeId, r.UsuarioId });

            builder.Property(r => r.EnvelopeId).HasColumnName("envelope_id");
            builder.Property(r => r.UsuarioId).HasColumnName("usuario_id");

            // relações opcionais se necessário
            builder.HasOne(r => r.Envelope)
                   .WithMany(e => e.Responsaveis)
                   .HasForeignKey(r => r.EnvelopeId);

            builder.HasOne(r => r.Usuario)
                   .WithMany()
                   .HasForeignKey(r => r.UsuarioId);
        }
    }
}
