namespace EnveloperWeb.Application.Envelopes.Conclusao.DTOs
{
    public class ConcluirEnvelopeRequestDto
    {
        public int EnvelopeId { get; set; }

        // Totais do fechamento
        public decimal DinheiroFinal { get; set; }
        public decimal VendasCartao { get; set; }
        public decimal SangriaTotalCaixa { get; set; }
        public decimal ReforcoTotalCaixa { get; set; }
        public decimal FaturamentoTotalVendas { get; set; }
        public decimal DinheiroEnvelope { get; set; }
        public decimal DinheiroPassagemCaixa { get; set; }

        // Dados complementares no fechamento
        public int TemperaturaTurno { get; set; }
        public int ClimaId { get; set; }
        public string Observacao { get; set; }

        // Responsáveis adicionais no fechamento (caso usados)
        public List<int> ResponsaveisIds { get; set; } = new();

        public DateTime DataHoraFechamento { get; set; }
    }
}
