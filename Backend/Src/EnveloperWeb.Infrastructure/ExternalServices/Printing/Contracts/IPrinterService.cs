namespace EnveloperWeb.Infrastructure.ExternalServices.Printing.Contracts
{
    /// Define a interface para serviços de impressão térmica.
    public interface IPrinterService
    {
        /// Envia o texto para a impressora padrão.
        Task ImprimirAsync(string conteudo);
    }
}
