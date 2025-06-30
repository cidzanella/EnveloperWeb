using EnveloperWeb.Infrastructure.ExternalServices.Printing.Contracts;
using System.IO;
using System.Text;

namespace EnveloperWeb.Infrastructure.ExternalServices.Printing.Services
{
    /// <summary>
    /// Serviço de impressão para impressoras térmicas Bematech não fiscais via porta padrão.
    /// </summary>
    public class BematechPrinterService : IPrinterService
    {
        private readonly string _portaImpressora = "LPT1"; // ou nome da impressora no sistema

        public async Task ImprimirAsync(string conteudo)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(conteudo);

            using var stream = new FileStream(_portaImpressora, FileMode.OpenOrCreate, FileAccess.Write);
            await stream.WriteAsync(buffer, 0, buffer.Length);
        }
    }
}
