namespace EnveloperWeb.Application.Faturamento.Contracts
{
    public interface IProjecaoFaturamentoMensalService
    {
        Task<double> CalcularAsync(int ano, int mes);
    }
}
