using EnveloperWeb.Application.DTOs.Faturamento;

namespace EnveloperWeb.Application.Contracts.Queries
{
    public interface IConsultaFaturamentoRepository
    {
        Task<List<FaturamentoDiarioDTO>> ListarFaturamentoDiarioDoMesAsync(int ano, int mes);
    }
}
