using EnveloperWeb.Application.DTOs;
using System.Text;

namespace EnveloperWeb.Application.Services.EnvelopeServices.Conclusao
{
    public class EmitirReciboFechamentoService : IEmitirReciboFechamentoService
    {
        public string GerarRecibo(ReciboEnvelopeDto dto)
        {
            var sb = new StringBuilder();
            sb.AppendLine("RECIBO DE FECHAMENTO");
            sb.AppendLine($"Data: {dto.Data:dd/MM/yyyy} Hora: {dto.Hora}");
            sb.AppendLine($"PDV: {dto.PDV}");
            sb.AppendLine($"Dinheiro Inicial: {dto.DinheiroInicial:C2}");
            sb.AppendLine($"Faturamento: {dto.Faturamento:C2}");
            sb.AppendLine($"Vendas Cartão: {dto.VendasCartao:C2}");
            sb.AppendLine($"Sangria: {dto.Sangria:C2}");
            sb.AppendLine($"Reforço: {dto.Reforco:C2}");
            sb.AppendLine($"Dinheiro Final: {dto.DinheiroFinal:C2}");
            sb.AppendLine($"Envelope: {dto.EnvelopeDinheiro:C2}");
            sb.AppendLine($"Repasse Caixa: {dto.RepasseCaixa:C2}");
            sb.AppendLine("------------");
            sb.AppendLine("Obrigado!");

            return sb.ToString();
        }
    }
}
