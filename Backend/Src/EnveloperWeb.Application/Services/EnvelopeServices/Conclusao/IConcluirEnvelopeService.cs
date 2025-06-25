using System.Threading.Tasks;
using EnveloperWeb.Application.DTOs;

namespace EnveloperWeb.Application.Services.EnvelopeServices.Conclusao
{
    public interface IConcluirEnvelopeService
    {
        Task ConcluirAsync(ConcluirEnvelopeDto dto);
    }
}
