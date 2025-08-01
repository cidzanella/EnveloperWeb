using Xunit;
using Moq;
using System.Threading.Tasks;
using EnveloperWeb.Application.Envelopes.Consultas.Services;
using EnveloperWeb.Application.Envelopes.Consultas.DTOs;
using EnveloperWeb.Domain.Envelopes.Contracts;
using AutoMapper;
using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Application.Wrappers;

namespace EnveloperWeb.Tests.Application.Envelopes.Consultas
{
    public class BuscarEnvelopePorIdServiceTests
    {
        private readonly Mock<IEnvelopeRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly BuscarEnvelopePorIdService _service;

        public BuscarEnvelopePorIdServiceTests()
        {
            _repositoryMock = new Mock<IEnvelopeRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new BuscarEnvelopePorIdService(_repositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task BuscarAsync_DeveRetornarEnvelope_QuandoEncontrado()
        {
            // Arrange
            var envelope = new Envelope { Id = 1, EnvelopeRotulo = "Rotulo Teste" };
            var dto = new EnvelopeDetalhadoDto { Id = 1, EnvelopeRotulo = "Rotulo Teste" };

            _repositoryMock.Setup(r => r.ObterPorIdComDadosCompletosAsync(1))
                .ReturnsAsync(envelope);

            _mapperMock.Setup(m => m.Map<EnvelopeDetalhadoDto>(envelope))
                .Returns(dto);

            // Act
            var result = await _service.BuscarAsync(1);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Data);
            Assert.Equal(1, result.Data.Id);
            Assert.Equal("Rotulo Teste", result.Data.EnvelopeRotulo);
        }

        [Fact]
        public async Task BuscarAsync_DeveRetornarFalha_QuandoEnvelopeNaoEncontrado()
        {
            // Arrange
            _repositoryMock.Setup(r => r.ObterPorIdComDadosCompletosAsync(99))
                .ReturnsAsync((Envelope)null);

            // Act
            var result = await _service.BuscarAsync(99);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Contains("Envelope não encontrado", result.Errors[0]);
        }
    }
}
