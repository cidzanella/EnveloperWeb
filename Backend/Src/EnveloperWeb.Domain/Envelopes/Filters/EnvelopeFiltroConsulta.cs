namespace EnveloperWeb.Domain.Envelopes.Filters
{
    /// Representa os critérios de filtragem para consultas de envelopes no repositório.
    /// Utilizado pela camada de Application para listar envelopes conforme os parâmetros fornecidos.
    public class EnvelopeFiltroConsulta
    {
        public int? Ano { get; set; }
        public int? Mes { get; set; }
        public int PdvId { get; set; }
        public string PdvNome { get; set; }
        public int? TurnoId { get; set; }
        public bool SomenteConcluidos { get; set; }
    }
}
