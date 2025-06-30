using EnveloperWeb.Domain.Envelopes.Entities;

namespace EnveloperWeb.Application.Envelopes.Conclusao.Contracts
{
    public interface IEmitirReciboFechamentoService
    {
        string Emitir(Envelope envelope);
    }
}
