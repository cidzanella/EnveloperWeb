namespace EnveloperWeb.Application.Envelopes.Consultas.DTOs
{
    /// DTO utilizado para receber os critérios de filtragem de envelopes via API.
    /// Essa classe é mapeada internamente para EnvelopeFiltroConsulta da Domain.
    public class EnvelopeFiltroConsultaDto
    {
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        public int? PDVId { get; set; }

        public int? TurnoId { get; set; }

        public int? ResponsavelId { get; set; }

        public bool SomenteConcluidos { get; set; }
    }
}
