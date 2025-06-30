using EnveloperWeb.Application.Envelopes.Conclusao.Contracts;
using EnveloperWeb.Domain.Envelopes.Entities;
using System;
using System.Text;

namespace EnveloperWeb.Application.Envelopes.Conclusao.Services
{
    public class EmitirReciboFechamentoService : IEmitirReciboFechamentoService
    {
        public string Emitir(Envelope envelope)
        {
            var sb = new StringBuilder();

            sb.AppendLine("-----------------------------");
            sb.AppendLine($"ENVELOPE ID: #{envelope.Id}");
            sb.AppendLine($"ABERTURA: {envelope.DataHoraInicio?.ToString("dd/MM/yyyy HH:mm")}");
            sb.AppendLine($"FECHAMENTO: {envelope.DataHoraConclusao?.ToString("dd/MM/yyyy HH:mm")}");
            sb.AppendLine($"OPERADOR: {envelope.Operador}");
            sb.AppendLine($"PDV: {envelope.PDV}");
            sb.AppendLine($"VALOR DINHEIRO INICIAL: R$ {envelope.DinheiroInicial:N2}");
            sb.AppendLine($"VALOR DINHEIRO FINAL: R$ {envelope.DinheiroFinal:N2}");
            sb.AppendLine($"FATURAMENTO: R$ {envelope.Faturamento:N2}");
            sb.AppendLine($"VENDAS CARTÃO: R$ {envelope.VendasCartao:N2}");
            sb.AppendLine($"VENDAS DINHEIRO: R$ {(envelope.Faturamento - envelope.VendasCartao):N2}");
            sb.AppendLine($"SANGRIA TOTAL: R$ {envelope.SangriaTotalCaixa:N2}");
            sb.AppendLine($"REFORÇO TOTAL: R$ {envelope.ReforcoTotalCaixa:N2}");
            sb.AppendLine($"DIF. FECHAMENTO: R$ {envelope.DiferencaFechamento:N2}");
            sb.AppendLine($"PASSAGEM CAIXA: R$ {envelope.PassagemCaixaDinheiro:N2}");
            sb.AppendLine($"DINHEIRO ENVELOPE: R$ {envelope.EnvelopeDinheiro:N2}");
            sb.AppendLine($"ENVELOPE CONFERIDO: {(envelope.EnvelopeConferido ? "Sim" : "Não")}");
            sb.AppendLine($"DIF. ENVELOPE x FINAL: R$ {envelope.EnvelopeDinheiroDiferenca:N2}");
            sb.AppendLine($"TEMPERATURA: {envelope.TemperaturaTurno} ºC");

            if (envelope.Clima != null)
                sb.AppendLine($"CLIMA: {envelope.Clima.Nome}");

            if (envelope.Turno != null)
                sb.AppendLine($"TURNO: {envelope.Turno.Nome}");

            sb.AppendLine($"FLAG ATENÇÃO: {(envelope.AtencaoFlagVerificar ? "Sim" : "Não")}");
            if (!string.IsNullOrWhiteSpace(envelope.AtencaoDescricao))
                sb.AppendLine($"DESC. ATENÇÃO: {envelope.AtencaoDescricao}");

            if (!string.IsNullOrWhiteSpace(envelope.Observacao))
                sb.AppendLine($"OBS: {envelope.Observacao}");

            sb.AppendLine("-----------------------------");

            return sb.ToString();
        }
    }
}
