using EnveloperWeb.Domain.PDVs.Entities;

namespace EnveloperWeb.Domain.PDVs.Contracts
{
    public interface IPDVRepository
    {
        Task<PDV> ObterPorIdAsync(int id);
        Task<IEnumerable<PDV>> ObterTodosAsync();
        Task AdicionarAsync(PDV pdv);
    }
}
