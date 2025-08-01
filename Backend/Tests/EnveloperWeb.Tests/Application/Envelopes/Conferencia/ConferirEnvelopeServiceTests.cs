using Xunit;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EnveloperWeb.Application.Envelopes.Conferencia.Services;
using EnveloperWeb.Application.Envelopes.Conferencia.Contracts;
using EnveloperWeb.Application.Envelopes.Conferencia.DTOs;
using EnveloperWeb.Application.Envelopes.Consultas.DTOs;
using EnveloperWeb.Domain.Envelopes.Contracts;
using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Shared.Contracts;
using AutoMapper;

namespace EnveloperWeb.Tests.Application.Envelopes.Conferencia
{
    public class ConferirEnvelopeServiceTests
    {
        private readonly Mock<IEnvelopeRepository> _repositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ConferirEnvelopeService _service;

        public ConferirEnvelopeServiceTests()
        {
            _repositoryMock = new Mock<IEnvelopeRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _service = new ConferirEnvelopeService(_repositoryMock.Object, _unitOfWorkMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task ConferirAsync_DeveConferirEnvelopeComSucesso()
        {
            // Arrange
            var envelope = new Envelope
            {
                Id = 1,
                EnvelopeDinheiro = 100,
                Observacao = "Já existente"
            };

            var dto = new ConferirEnvelopeRequestDto
            {
                EnvelopeId = 1,
                DinheiroEncontrado = 105,
                Observacao = " Complemento"
            };

            _repositoryMock.Setup(r => r.ObterPorIdAsync(1))
                           .ReturnsAsync(envelope);

            // Act
            var result = await _service.ConferirAsync(dto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.True(result.Data.EnvelopeConferido);
            Assert.Equal(105, result.Data.DinheiroEncontrado);
            Assert.Contains("Complemento", result.Data.ObservacaoFinal);
            _repositoryMock.Verify(r => r.AtualizarAsync(It.IsAny<Envelope>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task ConferirAsync_DeveRetornarErro_QuandoEnvelopeNaoEncontrado()
        {
            // Arrange
            _repositoryMock.Setup(r => r.ObterPorIdAsync(It.IsAny<int>()))
                           .ReturnsAsync((Envelope)null);

            var dto = new ConferirEnvelopeRequestDto { EnvelopeId = 99 };

            // Act
            var result = await _service.ConferirAsync(dto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Contains("Envelope não encontrado", result.Errors[0]);
            _repositoryMock.Verify(r => r.AtualizarAsync(It.IsAny<Envelope>()), Times.Never);
            _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Never);
        }

        [Fact]
        public async Task ListarNaoConferidosAsync_DeveRetornarLista()
        {
            // Arrange
            var envelopes = new List<Envelope> { new Envelope { Id = 1 }, new Envelope { Id = 2 } };
            var dtos = new List<EnvelopeResumoDto> { new EnvelopeResumoDto { Id = 1 }, new EnvelopeResumoDto { Id = 2 } };

            _repositoryMock.Setup(r => r.ListarEnvelopesNaoConferidosAsync()).ReturnsAsync(envelopes);
            _mapperMock.Setup(m => m.Map<List<EnvelopeResumoDto>>(envelopes)).Returns(dtos);

            // Act
            var result = await _service.ListarNaoConferidosAsync();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Data.Count);
        }
    }
}
