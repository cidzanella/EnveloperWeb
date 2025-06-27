using EnveloperWeb.Domain.Envelopes.Contracts;
using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnveloperWeb.Infrastructure.Repositories
{
    public class EnvelopeRepository : IEnvelopeRepository
    {
        private readonly AppDbContext _context;

        public EnvelopeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Envelope>> ObterTodosAsync()
        {
            return await _context.Envelopes.ToListAsync();
        }

        public async Task<Envelope> ObterPorIdAsync(int id)
        {
            return await _context.Envelopes.FindAsync(id);
        }

        public async Task AdicionarAsync(Envelope envelope)
        {
            await _context.Envelopes.AddAsync(envelope);
        }

        public async Task AtualizarAsync(Envelope envelope)
        {
            _context.Envelopes.Update(envelope);
            await Task.CompletedTask;
        }

        public async Task<bool> ExisteEnvelopeIniciadoNoPDVAsync(int pdvId)
        {
            var pdvNome = await _context.PDVs
                .Where(p => p.Id == pdvId)
                .Select(p => p.Nome)
                .FirstOrDefaultAsync();

            return await _context.Envelopes
                .AnyAsync(e => e.PDV == pdvNome && e.DataHoraConclusao == null);
        }

        public async Task<Envelope> ObterUltimoEnvelopeFechadoNoPDVAsync(int pdvId)
        {
            var pdvNome = await _context.PDVs
                .Where(p => p.Id == pdvId)
                .Select(p => p.Nome)
                .FirstOrDefaultAsync();

            return await _context.Envelopes
                .Where(e => e.PDV == pdvNome && e.DataHoraConclusao != null)
                .OrderByDescending(e => e.DataHoraConclusao)
                .FirstOrDefaultAsync();
        }
    }
}
