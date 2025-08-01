using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EnveloperWeb.Application.Envelopes.Consultas.Contracts;
using EnveloperWeb.Application.Envelopes.Consultas.DTOs;
using EnveloperWeb.Application.Envelopes.Consultas.Services;
using EnveloperWeb.Domain.Envelopes.Contracts;
using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Envelopes.Filters;

namespace EnveloperWeb.Tests.Application.Envelopes.Consultas
{
    public class ListarEnvelopesServiceTests
    {
        private readonly Mock<IEnvelopeRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ListarEnvelopesService _service;

        public ListarEnvelopesServiceTests()
        {
            _repositoryMock = new Mock<IEnvelopeRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new ListarEnvelopesService(_repositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task ListarAsync_DeveRetornarListaDeEnvelopes()
        {
            // Arrange
            var filtroDto = new EnvelopeFiltroConsultaDto
            {
                PDVId = 1,
                TurnoId = 2,
                ResponsavelId = 3,
                SomenteConcluidos = true
            };

            var filtroDomain = new EnvelopeFiltroConsulta
            {
                PdvId = filtroDto.PDVId,
                TurnoId = filtroDto.TurnoId,
                ResponsavelId = filtroDto.ResponsavelId,
                SomenteConcluidos = filtroDto.SomenteConcluidos
            };

            var envelopes = new List<Envelope>
            {
                new Envelope { Id = 1, PDV = "PDV 1" },
                new Envelope { Id = 2, PDV = "PDV 2" }
            };

            var dtos = new List<EnvelopeResumoDto>
            {
                new EnvelopeResumoDto { Id = 1, PDV = "PDV 1" },
                new EnvelopeResumoDto { Id = 2, PDV = "PDV 2" }
            };

            _repositoryMock.Setup(r => r.ListarEnvelopesResumoAsync(It.IsAny<EnvelopeFiltroConsulta>()))
                           .ReturnsAsync(envelopes);

            _mapperMock.Setup(m => m.Map<List<EnvelopeResumoDto>>(envelopes))
                       .Returns(dtos);

            // Act
            var resultado = await _service.ListarAsync(filtroDto);

            // Assert
            Assert.True(resultado.IsSuccess);
            Assert.NotNull(resultado.Data);
            Assert.Equal(2, resultado.Data.Count);
        }
    }
}
