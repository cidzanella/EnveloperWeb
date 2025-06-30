using EnveloperWeb.Domain.Envelopes.Contracts;
using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Envelopes.Filters;
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

        public async Task<IEnumerable<Envelope>> ListarEnvelopesResumoAsync(EnvelopeFiltroConsulta filtro)
        {
            var query = _context.Envelopes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro.PdvNome))
                query = query.Where(e => e.PDV == filtro.PdvNome);

            if (filtro.TurnoId.HasValue)
                query = query.Where(e => e.TurnoId == filtro.TurnoId.Value);

            if (filtro.SomenteConcluidos)
                query = query.Where(e => e.DataHoraConclusao.HasValue);

            return await query
                .OrderByDescending(e => e.DataHoraInicio)
                .ToListAsync();
        }

        public async Task<Envelope> ObterPorIdAsync(int id)
        {
            // Somente entity "crua", sem includes
            return await _context.Envelopes.FindAsync(id);
        }

        public async Task<Envelope> ObterPorIdComDadosCompletosAsync(int id)
        {
            return await _context.Envelopes
                .Include(e => e.Turno)
                .Include(e => e.Clima)
                .Include(e => e.Responsaveis)
                    .ThenInclude(r => r.Usuario)
                .FirstOrDefaultAsync(e => e.Id == id);
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

        public async Task<IEnumerable<Envelope>> ListarEnvelopesNaoConferidosAsync()
        {
            return await _context.Envelopes
                .Where(e => !e.EnvelopeConferido)
                .OrderByDescending(e => e.DataHoraConclusao)
                .ToListAsync();
        }

    }
}
