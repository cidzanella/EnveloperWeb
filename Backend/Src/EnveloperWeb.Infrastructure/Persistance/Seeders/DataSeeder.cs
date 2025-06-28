using EnveloperWeb.Domain.Climas.Entities;
using EnveloperWeb.Domain.PDVs.Entities;
using EnveloperWeb.Domain.Turnos.Entities;
using EnveloperWeb.Domain.Usuarios.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnveloperWeb.Infrastructure.Persistance.Seeders
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Turno>().HasData(
                new Turno { Id = 1, Nome = "Tarde" },
                new Turno { Id = 2, Nome = "Noite" },
                new Turno { Id = 3, Nome = "Único" }
            );

            modelBuilder.Entity<Clima>().HasData(
                new Clima { Id = 1, Nome = "Chuvoso" },
                new Clima { Id = 2, Nome = "Limpo" },
                new Clima { Id = 3, Nome = "Nublado" }
            );

            modelBuilder.Entity<PDV>().HasData(
                new PDV { Id = 1, Nome = "Medianeira" }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Nome = "Administrador", Login = "admin", Senha = "123456", Tipo = "Admin" }
            );
        }
    }
}
