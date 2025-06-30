namespace EnveloperWeb.Application.Envelopes.Conclusao.DTOs
{
    public class ConcluirEnvelopeResponseDto
    {
        public int EnvelopeId { get; set; }
        public DateTime DataHoraFechamento { get; set; }
        public decimal DinheiroFinal { get; set; }

        // Se quiser, pode retornar resumo para o ticket ser impresso no frontend
        public string Operador { get; set; }
        public string PDV { get; set; }
        public string Turno { get; set; }
        public decimal Faturamento { get; set; }
        public decimal VendasCartao { get; set; }
        public decimal SangriaTotalCaixa { get; set; }
        public decimal ReforcoTotalCaixa { get; set; }
        public decimal DiferencaFechamento { get; set; }
        public decimal EnvelopeDinheiro { get; set; }
        public string Clima { get; set; }
        public int TemperaturaTurno { get; set; }
        public string Observacao { get; set; }
        public string Recibo { get; set; } // ← Texto que vai ser impresso pro ticket do envelope físico
    }
}
