namespace EnveloperWeb.Application.Envelopes.Inicio.DTOs
{
    public class IniciarEnvelopeResponseDto
    {
        public int EnvelopeId { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public decimal DinheiroInicial { get; set; }
        public string NomeOperador { get; set; }
        public string NomePDV { get; set; }
        public string Observacao { get; set; }
    }
}
