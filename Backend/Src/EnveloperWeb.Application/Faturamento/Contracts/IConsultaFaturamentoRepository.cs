using EnveloperWeb.Application.Faturamento.DTOs;

namespace EnveloperWeb.Application.Faturamento.Contracts
{
    public interface IConsultaFaturamentoRepository
    {
        Task<List<FaturamentoDiarioDTO>> ObterFaturamentoDiarioDoMesAsync(int ano, int mes);
    }
}
