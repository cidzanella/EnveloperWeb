using Microsoft.EntityFrameworkCore;
using System.Reflection;
using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Usuarios.Entities;
using EnveloperWeb.Domain.Climas.Entities;
using EnveloperWeb.Domain.PDVs.Entities;
using EnveloperWeb.Domain.Responsaveis.Entities;
using EnveloperWeb.Domain.Turnos.Entities;
using EnveloperWeb.Infrastructure.Persistance.Seeders;

namespace EnveloperWeb.Infrastructure.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Envelope> Envelopes { get; set; }
        public DbSet<PDV> PDVs { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Clima> Climas { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<ResponsavelEnvelope> ResponsaveisEnvelope { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplica automaticamente todas as classes que implementam IEntityTypeConfiguration
            // Aplica todas as configurações encontradas no mesmo assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Popula dados iniciais no banco
            DataSeeder.Seed(modelBuilder);
        }
    }
}
