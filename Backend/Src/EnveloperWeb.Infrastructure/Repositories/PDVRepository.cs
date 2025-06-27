using EnveloperWeb.Domain.PDVs.Contracts;
using EnveloperWeb.Domain.PDVs.Entities;
using EnveloperWeb.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace EnveloperWeb.Infrastructure.Repositories
{
    public class PDVRepository : IPDVRepository
    {
        private readonly AppDbContext _context;

        public PDVRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PDV>> ObterTodosAsync()
        {
            return await _context.PDVs.ToListAsync();
        }

        public async Task<PDV> ObterPorIdAsync(int id)
        {
            return await _context.PDVs.FindAsync(id);
        }

        public async Task AdicionarAsync(PDV pdv)
        {
            await _context.PDVs.AddAsync(pdv);
        }
    }
}
