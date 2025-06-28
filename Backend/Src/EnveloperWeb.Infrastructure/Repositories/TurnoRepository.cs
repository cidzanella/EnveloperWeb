using EnveloperWeb.Domain.Turnos.Contracts;
using EnveloperWeb.Domain.Turnos.Entities;
using EnveloperWeb.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace EnveloperWeb.Infrastructure.Repositories
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly AppDbContext _context;

        public TurnoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Turno>> ObterTodosAsync()
        {
            return await _context.Turnos.ToListAsync();
        }

        public async Task<Turno> ObterPorIdAsync(int id)
        {
            return await _context.Turnos.FindAsync(id);
        }

        public async Task AdicionarAsync(Turno turno)
        {
            await _context.Turnos.AddAsync(turno);
        }
    }
}
