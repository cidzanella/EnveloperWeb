using EnveloperWeb.Application.Envelopes.Inicio.Contracts;
using EnveloperWeb.Application.Envelopes.Inicio.DTOs;
using EnveloperWeb.Application.Wrappers;
using EnveloperWeb.Domain.Envelopes.Contracts;
using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.PDVs.Contracts;
using EnveloperWeb.Domain.Shared.Contracts;
using EnveloperWeb.Domain.Usuarios.Contracts;

public class IniciarEnvelopeService : IIniciarEnvelopeService
{
    private readonly IEnvelopeRepository _envelopeRepository;
    private readonly IPDVRepository _pdvRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInicioEnvelopeValidator _validadorInicio;

    public IniciarEnvelopeService(
        IEnvelopeRepository envelopeRepository,
        IPDVRepository pdvRepository,
        IUsuarioRepository usuarioRepository,
        IUnitOfWork unitOfWork,
        IInicioEnvelopeValidator validadorInicio)
    {
        _envelopeRepository = envelopeRepository;
        _pdvRepository = pdvRepository;
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
        _validadorInicio = validadorInicio;
    }

    public async Task<OperationResult<IniciarEnvelopeResponseDto>> IniciarAsync(IniciarEnvelopeRequestDto dto)
    {
        var erros = new List<string>();

        // 1. Verificar se já existe envelope aberto para o mesmo PDV
        if (await _envelopeRepository.ExisteEnvelopeIniciadoNoPDVAsync(dto.PDVId))
            erros.Add("Já existe um envelope aberto para este PDV.");

        // 2. Buscar dados do PDV
        var pdv = await _pdvRepository.ObterPorIdAsync(dto.PDVId);
        if (pdv == null)
            erros.Add("PDV não encontrado.");

        // 3. Buscar dados do Operador
        var operador = await _usuarioRepository.ObterPorIdAsync(dto.OperadorId);
        if (operador == null)
            erros.Add("Operador não encontrado.");

        if (erros.Any())
            return OperationResult<IniciarEnvelopeResponseDto>.Failure(erros);

        // 4. Criar entidade Envelope
        var envelope = new Envelope
        {
            DataHoraInicio = dto.DataHoraInicio,
            DinheiroInicial = Convert.ToDouble(dto.DinheiroInicial),
            Observacao = dto.Observacao,
            PDV = pdv.Nome,
            Operador = operador.Nome,
            EnvelopeConferido = false,
            AtencaoFlagVerificar = false
        };

        // 5. Validar dados de abertura
        var envelopeAnterior = await _envelopeRepository.ObterUltimoEnvelopeFechadoNoPDVAsync(dto.PDVId);
        var resultadoValidacao = _validadorInicio.Validar(envelope, envelopeAnterior);

        // se não é válido e não está forçando, bloqueia
        if (!resultadoValidacao.IsValid && !dto.ForcarIniciarComDivergencia)
            return OperationResult<IniciarEnvelopeResponseDto>.Failure(resultadoValidacao.Errors);

        // se está forçando, marca com atenção: usuário prosseguiu com o valor divergente
        if (!resultadoValidacao.IsValid && dto.ForcarIniciarComDivergencia)
        {
            envelope.AtencaoFlagVerificar = true;
            envelope.AtencaoDescricao = string.Join(" | ", resultadoValidacao.Errors);
        }

        // 6. Persistir no banco
        await _envelopeRepository.AdicionarAsync(envelope);
        await _unitOfWork.CommitAsync();

        var response = new IniciarEnvelopeResponseDto
        {
            EnvelopeId = envelope.Id,
            DataHoraInicio = envelope.DataHoraInicio ?? dto.DataHoraInicio,
            DinheiroInicial = dto.DinheiroInicial,
            NomePDV = pdv.Nome,
            NomeOperador = operador.Nome,
            Observacao = dto.Observacao
        };

        return OperationResult<IniciarEnvelopeResponseDto>.Success(response);
    }
}
