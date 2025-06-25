using EnveloperWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnveloperWeb.Domain.Contracts.Repositories
{
    public interface IEnvelopeRepository
    {
        Task<Envelope> GetByIdAsync(int id);
        Task<IEnumerable<Envelope>> GetByFilterAsync(DateTime? dataInicio, DateTime? dataFim, string pdv);
        Task AddAsync(Envelope envelope);
        Task UpdateAsync(Envelope envelope);
    }
}
