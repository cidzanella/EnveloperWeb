using EnveloperWeb.Domain.Entities;

namespace EnveloperWeb.Domain.Contracts.Repositories
{
    public interface IEnvelopeRepository
    {
        Task<List<Envelope>> ListarAsync();
        Task<Envelope> BuscarPorIdAsync(Guid id);
        Task AdicionarAsync(Envelope envelope);
        Task AtualizarAsync(Envelope envelope);
        
    }
}
