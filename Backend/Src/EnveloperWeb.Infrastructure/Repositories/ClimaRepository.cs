using EnveloperWeb.Domain.Climas.Contracts;
using EnveloperWeb.Domain.Climas.Entities;
using EnveloperWeb.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace EnveloperWeb.Infrastructure.Repositories
{
    public class ClimaRepository : IClimaRepository
    {
        private readonly AppDbContext _context;

        public ClimaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Clima>> ObterTodosAsync()
        {
            return await _context.Climas.ToListAsync();
        }

        public async Task<Clima> ObterPorIdAsync(int id)
        {
            return await _context.Climas.FindAsync(id);
        }

        public async Task AdicionarAsync(Clima clima)
        {
            await _context.Climas.AddAsync(clima);
        }
    }
}
