namespace EnveloperWeb.Domain.Envelopes.Filters
{
    /// Representa os critérios de filtragem para consultas de envelopes no repositório.
    /// Utilizado pela camada de Application para listar envelopes conforme os parâmetros fornecidos.
    public class EnvelopeFiltroConsulta
    {
        public string PdvNome { get; set; }
        public int? TurnoId { get; set; }
        public bool SomenteConcluidos { get; set; }
    }
}
