using EnveloperWeb.Domain.Envelopes.DTOs;
using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Envelopes.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnveloperWeb.Domain.Envelopes.Contracts
{
 
    public interface IEnvelopeRepository
    {
        Task<Envelope> ObterPorIdAsync(int id);
        Task<Envelope> ObterPorIdComDadosCompletosAsync(int id);
        Task<IEnumerable<Envelope>> ListarEnvelopesResumoAsync(EnvelopeFiltroConsulta filtro);
        Task AdicionarAsync(Envelope envelope);
        Task AtualizarAsync(Envelope envelope);
        Task<bool> ExisteEnvelopeIniciadoNoPDVAsync(int pdvId);
        Task<Envelope> ObterUltimoEnvelopeFechadoNoPDVAsync(int pdvId);
        Task<IEnumerable<Envelope>> ListarEnvelopesNaoConferidosAsync();
        Task<List<FaturamentoDiarioDto>> ObterFaturamentoDiarioDoMesAsync(int ano, int mes);

    }
}
