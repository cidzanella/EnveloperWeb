using EnveloperWeb.Application.DTOs;

namespace EnveloperWeb.Application.Envelopes.ConclusaoEnvelope.Contracts
{
    public interface IEmitirReciboFechamentoService
    {
        string GerarRecibo(ReciboEnvelopeDto dto);
    }
}
