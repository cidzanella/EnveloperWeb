using System.Collections.Generic;
using System.Threading.Tasks;
using EnveloperWeb.Application.Envelopes.Consultas.DTOs;
using EnveloperWeb.Application.Wrappers;

namespace EnveloperWeb.Application.Envelopes.Consultas.Contracts
{
    public interface IListarEnvelopesService
    {
        Task<OperationResult<List<EnvelopeResumoDto>>> ListarAsync(EnvelopeFiltroConsultaDto filtroConsultaDto);
    }
}
