using System.Threading.Tasks;
using EnveloperWeb.Application.DTOs;

namespace EnveloperWeb.Application.Services.EnvelopeServices.Consulta
{
    public interface IBuscarEnvelopePorIdService
    {
        Task<EnvelopeDetalhadoDto> BuscarAsync(int id);
    }
}
