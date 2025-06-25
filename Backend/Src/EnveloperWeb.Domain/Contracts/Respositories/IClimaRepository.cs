using EnveloperWeb.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnveloperWeb.Domain.Contracts
{
    public interface IClimaRepository
    {
        Task<IEnumerable<Clima>> GetAllAsync();
        Task<Clima> GetByIdAsync(int id);
    }
}
