using System.Collections.Generic;
using System.Threading.Tasks;
using EnveloperWeb.Application.DTOs;

namespace EnveloperWeb.Application.Services.EnvelopeServices.Consulta
{
    public interface IListarEnvelopesService
    {
        Task<List<EnvelopeResumoDto>> ListarAsync(FiltroEnvelopeDto filtro);
    }
}
