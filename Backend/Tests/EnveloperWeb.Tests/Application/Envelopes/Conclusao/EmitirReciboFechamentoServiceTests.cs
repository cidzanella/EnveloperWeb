using EnveloperWeb.Domain.Climas.Entities;
using EnveloperWeb.Domain.Turnos.Entities;
using EnveloperWeb.Application.Envelopes.Conclusao.Services;
using EnveloperWeb.Domain.Envelopes.Entities;
using System;
using Xunit;

namespace EnveloperWeb.Tests.Application.Envelopes.Conclusao
{
    public class EmitirReciboFechamentoServiceTests
    {
        private readonly EmitirReciboFechamentoService _service;

        public EmitirReciboFechamentoServiceTests()
        {
            _service = new EmitirReciboFechamentoService();
        }

        [Fact]
        public void Emitir_DeveGerarReciboCompleto()
        {
            // Arrange
            var envelope = new Envelope
            {
                Id = 123,
                DataHoraInicio = new DateTime(2024, 7, 1, 8, 30, 0),
                DataHoraConclusao = new DateTime(2024, 7, 1, 18, 45, 0),
                Operador = "João",
                PDV = "PDV-01",
                DinheiroInicial = 100.00,
                DinheiroFinal = 950.00,
                Faturamento = 1200.00,
                VendasCartao = 500.00,
                SangriaTotalCaixa = 50.00,
                ReforcoTotalCaixa = 20.00,
                DiferencaFechamento = 10.00,
                PassagemCaixaDinheiro = 90.00,
                EnvelopeDinheiro = 940.00,
                EnvelopeConferido = true,
                EnvelopeDinheiroDiferenca = 5.00,
                TemperaturaTurno = 25,
                Clima = new Clima { Nome = "Ensolarado" },
                Turno = new Turno { Nome = "Manhã" },
                AtencaoFlagVerificar = true,
                AtencaoDescricao = "Diferença no fechamento",
                Observacao = "Fechamento sem sangria."
            };

            // Act
            var recibo = _service.Emitir(envelope);

            // Assert
            Assert.NotNull(recibo);
            Assert.Contains("ENVELOPE ID: #123", recibo);
            Assert.Contains("ABERTURA: 01/07/2024 08:30", recibo);
            Assert.Contains("FECHAMENTO: 01/07/2024 18:45", recibo);
            Assert.Contains("OPERADOR: João", recibo);
            Assert.Contains("PDV: PDV-01", recibo);
            Assert.Contains("DINHEIRO INICIAL", recibo);
            Assert.Contains("CLIMA: Ensolarado", recibo);
            Assert.Contains("TURNO: Manhã", recibo);
            Assert.Contains("FLAG ATENÇÃO: Sim", recibo);
            Assert.Contains("DESC. ATENÇÃO: Diferença no fechamento", recibo);
            Assert.Contains("OBS: Fechamento sem sangria.", recibo);
        }

        [Fact]
        public void Emitir_DeveGerarReciboMinimo_SeDadosForemNulos()
        {
            // Arrange
            var envelope = new Envelope { Id = 1 };

            // Act
            var recibo = _service.Emitir(envelope);

            // Assert
            Assert.NotNull(recibo);
            Assert.Contains("ENVELOPE ID: #1", recibo);
            Assert.Contains("-----------------------------", recibo);
        }
    }
}
