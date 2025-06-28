using EnveloperWeb.Domain.Climas.Entities;

namespace EnveloperWeb.Domain.Climas.Contracts
{
    public interface IClimaRepository
    {
        Task<Clima> ObterPorIdAsync(int id);
        Task<IEnumerable<Clima>> ObterTodosAsync();
        Task AdicionarAsync(Clima clima);
    }
}
