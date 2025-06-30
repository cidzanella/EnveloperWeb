namespace EnveloperWeb.Application.Envelopes.Consultas.DTOs
{
    public class EnvelopeDetalhadoDto
    {
        public int Id { get; set; }
        public string EnvelopeRotulo { get; set; }

        public double DinheiroInicial { get; set; }
        public double DinheiroInicialDiferenca { get; set; }
        public double DinheiroFinal { get; set; }
        public double VendasCartao { get; set; }
        public double SangriaTotalCaixa { get; set; }
        public double ReforcoTotalCaixa { get; set; }
        public double Faturamento { get; set; }
        public double DiferencaFechamento { get; set; }
        public double PassagemCaixaDinheiro { get; set; }
        public double EnvelopeDinheiro { get; set; }
        public double EnvelopeDinheiroDiferenca { get; set; }

        public bool EnvelopeConferido { get; set; }
        public string Observacao { get; set; }

        public DateTime? DataHoraInicio { get; set; }
        public DateTime? DataHoraConclusao { get; set; }

        public int TemperaturaTurno { get; set; }

        public string PDV { get; set; }
        public string Operador { get; set; }

        public bool AtencaoFlagVerificar { get; set; }
        public string AtencaoDescricao { get; set; }

        public string NomeClima { get; set; }
        public string NomeTurno { get; set; }

        public List<string> Responsaveis { get; set; }

        public string Recibo { get; set; }
    }
}
