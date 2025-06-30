namespace EnveloperWeb.Application.Envelopes.Consultas.DTOs
{
    public class EnvelopeResumoDto
    {
        public int Id { get; set; }
        public string EnvelopeRotulo { get; set; }

        public string PDV { get; set; }

        public DateTime? DataHoraInicio { get; set; }
        public DateTime? DataHoraConclusao { get; set; }

        public double Faturamento { get; set; }

        public string NomeTurno { get; set; }
        public string NomeClima { get; set; }

        public bool EnvelopeConferido { get; set; }

        public List<string> Responsaveis { get; set; }

        public bool EstaConcluido => DataHoraConclusao.HasValue;
    }
}
