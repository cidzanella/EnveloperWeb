using EnveloperWeb.Domain.Entities;

namespace EnveloperWeb.Domain.Contracts.Services
{
    public interface IEnvelopeValidator
    {
        List<string> Validar(Envelope envelopeAtual, Envelope envelopeAnterior);
    }
}
