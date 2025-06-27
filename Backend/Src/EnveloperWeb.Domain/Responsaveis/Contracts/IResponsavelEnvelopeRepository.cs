using EnveloperWeb.Domain.Responsaveis.Entities;

namespace EnveloperWeb.Domain.Responsaveis.Contracts
{
    public interface IResponsavelEnvelopeRepository
    {
        Task<IEnumerable<ResponsavelEnvelope>> ObterPorEnvelopeIdAsync(int envelopeId);
        Task AdicionarAsync(ResponsavelEnvelope responsavelEnvelope);
        Task RemoverTodosPorEnvelopeIdAsync(int envelopeId);
    }
}
