namespace EnveloperWeb.Application.Envelopes.Inicio.DTOs
{
    public class IniciarEnvelopeRequestDto
    {
        public int PDVId { get; set; }
        public int OperadorId { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public decimal DinheiroInicial { get; set; }
        public string Observacao { get; set; }
        public bool ForcarIniciarComDivergencia { get; set; } = false; // permite forçar a abertura mesmo com divergência
    }
}
