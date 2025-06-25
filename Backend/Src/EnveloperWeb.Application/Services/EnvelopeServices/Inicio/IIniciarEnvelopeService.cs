using System.Collections.Generic;
using System.Threading.Tasks;
using EnveloperWeb.Application.DTOs;

namespace EnveloperWeb.Application.Services.EnvelopeServices.Inicio
{
    public interface IIniciarEnvelopeService
    {
        Task<int> IniciarAsync(IniciarEnvelopeDto dto);
    }
}
