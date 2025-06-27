using EnveloperWeb.Domain.Responsaveis.Contracts;
using EnveloperWeb.Domain.Responsaveis.Entities;
using EnveloperWeb.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnveloperWeb.Infrastructure.Repositories
{
    public class ResponsavelEnvelopeRepository : IResponsavelEnvelopeRepository
    {
        private readonly AppDbContext _context;

        public ResponsavelEnvelopeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResponsavelEnvelope>> ObterPorEnvelopeIdAsync(int envelopeId)
        {
            return await _context.ResponsaveisEnvelope
                .Where(r => r.EnvelopeId == envelopeId)
                .ToListAsync();
        }

        public async Task AdicionarAsync(ResponsavelEnvelope responsavelEnvelope)
        {
            await _context.ResponsaveisEnvelope.AddAsync(responsavelEnvelope);
        }

        public async Task RemoverTodosPorEnvelopeIdAsync(int envelopeId)
        {
            var responsaveis = await _context.ResponsaveisEnvelope
                .Where(r => r.EnvelopeId == envelopeId)
                .ToListAsync();

            _context.ResponsaveisEnvelope.RemoveRange(responsaveis);
        }
    }
}
