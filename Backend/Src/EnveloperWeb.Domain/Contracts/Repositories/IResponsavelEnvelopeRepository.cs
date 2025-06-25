using EnveloperWeb.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnveloperWeb.Domain.Contracts.Repositories
{
    public interface IResponsavelEnvelopeRepository
    {
        Task<IEnumerable<ResponsavelEnvelope>> GetByEnvelopeIdAsync(int envelopeId);
        Task AddAsync(ResponsavelEnvelope responsavelEnvelope);
    }
}
