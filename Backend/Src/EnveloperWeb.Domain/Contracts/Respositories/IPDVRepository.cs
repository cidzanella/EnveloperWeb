using EnveloperWeb.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnveloperWeb.Domain.Contracts
{
    public interface IPDVRepository
    {
        Task<IEnumerable<PDV>> GetAllAsync();
        Task<PDV> GetByIdAsync(int id);
        Task AddAsync(PDV pdv);
        Task DeleteAsync(int id);
    }
}
