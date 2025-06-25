using EnveloperWeb.Application.DTOs;

namespace EnveloperWeb.Application.Services.EnvelopeServices.Conclusao
{
    public interface IEmitirReciboFechamentoService
    {
        string GerarRecibo(ReciboEnvelopeDto dto);
    }
}
