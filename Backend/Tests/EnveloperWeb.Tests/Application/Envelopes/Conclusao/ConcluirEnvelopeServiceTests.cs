using Xunit;
using Moq;
using System.Threading.Tasks;
using EnveloperWeb.Application.Envelopes.Conclusao.DTOs;
using EnveloperWeb.Application.Envelopes.Conclusao.Services;
using EnveloperWeb.Domain.Envelopes.Contracts;
using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Envelopes.Services;
using EnveloperWeb.Domain.Shared.Contracts;
using EnveloperWeb.Domain.Envelopes.Services.RegrasConclusaoEnvelope;
using System.Collections.Generic;
using EnveloperWeb.Application.Envelopes.Conclusao.Contracts;

namespace EnveloperWeb.Tests.Application.Envelopes.Conclusao
{
    public class ConcluirEnvelopeServiceTests
    {
        private readonly Mock<IEnvelopeRepository> _repositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IConclusaoEnvelopeValidator _validador;
        private readonly ConcluirEnvelopeService _service;
        private readonly Mock<IEmitirReciboFechamentoService> _reciboServiceMock;

        public ConcluirEnvelopeServiceTests()
        {
            _repositoryMock = new Mock<IEnvelopeRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            // Se necessário, você pode mockar as regras internamente também para isolar
            var regrasMock = new List<IConclusaoEnvelopeValidationRule>();
            _validador = new ConclusaoEnvelopeValidator(regrasMock);
            _reciboServiceMock = new Mock<IEmitirReciboFechamentoService>();

            _service = new ConcluirEnvelopeService(
                _repositoryMock.Object,
                _unitOfWorkMock.Object,
                _validador,
                _reciboServiceMock.Object);
        }

        [Fact]
        public async Task ConcluirAsync_DeveConcluirEnvelopeComSucesso()
        {
            // Arrange
            var envelope = new Envelope
            {
                Id = 1,
                EnvelopeConferido = false,
                Observacao = "Inicial"
            };

            _repositoryMock.Setup(r => r.ObterPorIdAsync(1))
                           .ReturnsAsync(envelope);

            var dto = new ConcluirEnvelopeRequestDto
            {
                EnvelopeId = 1,
                DinheiroFinal = 100,
                SangriaTotalCaixa = 20,
                ReforcoTotalCaixa = 5,
                VendasCartao = 200,
                FaturamentoTotalVendas = 300,
                DinheiroEnvelope = 100,
                DinheiroPassagemCaixa = 95,
                TemperaturaTurno = 25,
                ClimaId = 1,
                Observacao = " Concluído."
            };

            // Act
            var result = await _service.ConcluirAsync(dto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Data);
            Assert.Equal(300, result.Data.Faturamento);
            Assert.Equal("Inicial Concluído.".Trim(), result.Data.Observacao);
        }

        [Fact]
        public async Task ConcluirAsync_DeveRetornarErro_QuandoEnvelopeNaoEncontrado()
        {
            // Arrange
            _repositoryMock.Setup(r => r.ObterPorIdAsync(It.IsAny<int>()))
                           .ReturnsAsync((Envelope)null);

            var dto = new ConcluirEnvelopeRequestDto { EnvelopeId = 99 };

            // Act
            var result = await _service.ConcluirAsync(dto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Contains("Envelope não encontrado", result.Errors[0]);
        }

        [Fact]
        public async Task ConcluirAsync_DeveFalharValidacao_QuandoValoresInvalidos()
        {
            // Arrange
            var envelope = new Envelope { Id = 1 };
            _repositoryMock.Setup(r => r.ObterPorIdAsync(1)).ReturnsAsync(envelope);

            var dto = new ConcluirEnvelopeRequestDto
            {
                EnvelopeId = 1,
                DinheiroFinal = -10,  // valor inválido para disparar erro de validação
                FaturamentoTotalVendas = -50
            };

            // Act
            var result = await _service.ConcluirAsync(dto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Contains(result.Errors, e => e.ToLower().Contains("dinheirofinal") || e.ToLower().Contains("faturamento"));
        }
    }
}
