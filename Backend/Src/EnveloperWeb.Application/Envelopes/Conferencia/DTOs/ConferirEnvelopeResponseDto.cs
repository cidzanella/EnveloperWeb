namespace EnveloperWeb.Application.Envelopes.Conferencia.DTOs
{
    public class ConferirEnvelopeResponseDto
    {
        public int EnvelopeId { get; set; }
        public decimal DinheiroSistema { get; set; }
        public decimal DinheiroEncontrado { get; set; }
        public decimal Diferenca { get; set; }
        public bool EnvelopeConferido { get; set; }
        public string ObservacaoFinal { get; set; }
    }
}
