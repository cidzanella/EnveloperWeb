using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EnveloperWeb.Application.Envelopes.Consultas.Contracts;
using EnveloperWeb.Application.Envelopes.Consultas.DTOs;
using EnveloperWeb.Application.Wrappers;
using EnveloperWeb.Domain.Envelopes.Contracts;
using EnveloperWeb.Domain.Envelopes.Filters;

namespace EnveloperWeb.Application.Envelopes.Consultas.Services
{
    public class ListarEnvelopesService : IListarEnvelopesService
    {
        private readonly IEnvelopeRepository _repository;
        private readonly IMapper _mapper;

        public ListarEnvelopesService(IEnvelopeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<List<EnvelopeResumoDto>>> ListarAsync(EnvelopeFiltroConsultaDto filtroConsultaDto)
        {
            var filtroConsulta = _mapper.Map<EnvelopeFiltroConsulta>(filtroConsultaDto);
            var envelopes = await _repository.ListarEnvelopesResumoAsync(filtroConsulta);

            var dtos = _mapper.Map<List<EnvelopeResumoDto>>(envelopes);
            return OperationResult<List<EnvelopeResumoDto>>.Success(dtos);
        }
    }
}
