namespace EnveloperWeb.Application.FaturamentoServices
{
    public interface IProjecaoFaturamentoMensalService
    {
        Task<double> CalcularAsync(int ano, int mes);
    }
}
