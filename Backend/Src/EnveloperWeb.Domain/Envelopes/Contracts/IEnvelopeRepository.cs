using EnveloperWeb.Domain.Envelopes.Entities;

namespace EnveloperWeb.Domain.Envelopes.Contracts
{
    public interface IEnvelopeRepository
    {
        Task<IEnumerable<Envelope>> ObterTodosAsync();
        Task<Envelope> ObterPorIdAsync(int id);
        Task AdicionarAsync(Envelope envelope);
        Task AtualizarAsync(Envelope envelope);
        Task<bool> ExisteEnvelopeIniciadoNoPDVAsync(int pdvId);
        Task<Envelope> ObterUltimoEnvelopeFechadoNoPDVAsync(int pdvId);
    }
}
