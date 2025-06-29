﻿using System.Collections.Generic;
using System.Threading.Tasks;
using EnveloperWeb.Application.DTOs;
using EnveloperWeb.Application.Envelopes.Consultas.Contracts;
using EnveloperWeb.Domain.Contracts;
using EnveloperWeb.Domain.Envelopes.Contracts;

namespace EnveloperWeb.Application.Envelopes.Consultas.Services
{
    public class ListarEnvelopesService : IListarEnvelopesService
    {
        private readonly IEnvelopeRepository _repository;

        public ListarEnvelopesService(IEnvelopeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EnvelopeResumoDto>> ListarAsync(FiltroEnvelopeDto filtro)
        {
            return await _repository.ListarEnvelopesResumoAsync(filtro);
        }
    }
}
