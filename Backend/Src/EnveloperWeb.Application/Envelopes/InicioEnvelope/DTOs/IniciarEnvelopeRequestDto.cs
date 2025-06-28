namespace EnveloperWeb.Application.Envelopes.InicioEnvelope.Dtos
{
    public class IniciarEnvelopeRequestDto
    {
        public int PDVId { get; set; }
        public int OperadorId { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public decimal DinheiroInicial { get; set; }
        public string Observacao { get; set; }
    }
}
