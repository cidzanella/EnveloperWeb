using EnveloperWeb.Application.Envelopes.Conclusao.Contracts;
using EnveloperWeb.Application.Envelopes.Conclusao.DTOs;
using EnveloperWeb.Application.Wrappers;
using EnveloperWeb.Domain.Envelopes.Contracts;
using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Shared.Contracts;
using EnveloperWeb.Application.Envelopes.Conclusao.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ConcluirEnvelopeService : IConcluirEnvelopeService
{
    private readonly IEnvelopeRepository _envelopeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConclusaoEnvelopeValidator _validadorConclusao;
    private readonly IEmitirReciboFechamentoService _reciboService;

    public ConcluirEnvelopeService(
        IEnvelopeRepository envelopeRepository,
        IUnitOfWork unitOfWork,
        IConclusaoEnvelopeValidator validadorConclusao,
        IEmitirReciboFechamentoService reciboService)
    {
        _envelopeRepository = envelopeRepository;
        _unitOfWork = unitOfWork;
        _validadorConclusao = validadorConclusao;
        _reciboService = reciboService;
    }

    public async Task<OperationResult<ConcluirEnvelopeResponseDto>> ConcluirAsync(ConcluirEnvelopeRequestDto dto)
    {
        var erros = new List<string>();

        // 1. Buscar o envelope
        var envelope = await _envelopeRepository.ObterPorIdAsync(dto.EnvelopeId);
        if (envelope == null)
            return OperationResult<ConcluirEnvelopeResponseDto>.Failure(new[] { "Envelope não encontrado." });

        // 2. Atualizar os dados informados no fechamento
        envelope.DinheiroFinal = (double)dto.DinheiroFinal;
        envelope.VendasCartao = (double)dto.VendasCartao;
        envelope.SangriaTotalCaixa = (double)dto.SangriaTotalCaixa;
        envelope.ReforcoTotalCaixa = (double)dto.ReforcoTotalCaixa;
        envelope.Faturamento = (double)dto.FaturamentoTotalVendas;
        envelope.EnvelopeDinheiro = (double)dto.DinheiroEnvelope;
        envelope.PassagemCaixaDinheiro = (double)dto.DinheiroPassagemCaixa;
        envelope.TemperaturaTurno = dto.TemperaturaTurno;
        envelope.ClimaId = dto.ClimaId;
        envelope.Observacao = dto.Observacao;
        envelope.DataHoraConclusao = dto.DataHoraFechamento;

        // 3. Validar regras de fechamento
        var resultadoValidacao = _validadorConclusao.Validar(envelope);
        if (!resultadoValidacao.IsValid)
            return OperationResult<ConcluirEnvelopeResponseDto>.Failure(resultadoValidacao.Errors);

        // 4. Persistir alterações
        await _envelopeRepository.AtualizarAsync(envelope);
        await _unitOfWork.CommitAsync();

        // 5. Gerar recibo
        var recibo = _reciboService.Emitir(envelope);

        // 6. Retornar DTO com dados consolidados
        var response = new ConcluirEnvelopeResponseDto
        {
            EnvelopeId = envelope.Id,
            DataHoraFechamento = envelope.DataHoraConclusao ?? dto.DataHoraFechamento,
            DinheiroFinal = (decimal)envelope.DinheiroFinal,
            Operador = envelope.Operador,
            PDV = envelope.PDV,
            Turno = envelope.Turno?.Nome,
            Faturamento = (decimal)envelope.Faturamento,
            VendasCartao = (decimal)envelope.VendasCartao,
            SangriaTotalCaixa = (decimal)envelope.SangriaTotalCaixa,
            ReforcoTotalCaixa = (decimal)envelope.ReforcoTotalCaixa,
            DiferencaFechamento = (decimal)envelope.DiferencaFechamento,
            EnvelopeDinheiro = (decimal)envelope.EnvelopeDinheiro,
            Clima = envelope.Clima?.Nome,
            TemperaturaTurno = envelope.TemperaturaTurno,
            Observacao = envelope.Observacao,
            Recibo = recibo
        };

        return OperationResult<ConcluirEnvelopeResponseDto>.Success(response);
    }
}
