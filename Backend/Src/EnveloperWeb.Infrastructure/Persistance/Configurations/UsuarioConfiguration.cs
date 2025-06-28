using EnveloperWeb.Domain.Usuarios.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnveloperWeb.Infrastructure.Persistance.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                   .HasColumnName("id")
                   .ValueGeneratedOnAdd();

            builder.Property(u => u.Nome)
                   .HasColumnName("nome")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(u => u.Login)
                   .HasColumnName("login")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(u => u.Senha)
                   .HasColumnName("senha")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(u => u.Tipo)
                   .HasColumnName("tipo")
                   .HasMaxLength(20)
                   .IsRequired();
        }
    }
}
