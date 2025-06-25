using EnveloperWeb.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnveloperWeb.Domain.Contracts
{
    public interface ITurnoRepository
    {
        Task<IEnumerable<Turno>> GetAllAsync();
        Task<Turno> GetByIdAsync(int id);
    }
}
