using System;
using System.Collections.Generic;

namespace EnveloperWeb.Domain.Entities
{
    public class Envelope
    {
        public int Id { get; set; }
        public DateTime? DataAberturaCaixa { get; set; }
        public string HoraAberturaCaixa { get; set; }
        public double DinheiroInicial { get; set; }
        public double DinheiroInicialDiferenca { get; set; }

        public DateTime? DataFechamentoCaixa { get; set; }
        public string HoraFechamentoCaixa { get; set; }
        public double DinheiroFinal { get; set; }
        public double Faturamento { get; set; }
        public double VendasCartao { get; set; }
        public double SangriaTotalCaixa { get; set; }
        public double ReforcoTotalCaixa { get; set; }
        public double DiferencaFechamento { get; set; }
        public double EnvelopeDinheiro { get; set; }
        public double PassagemCaixaDinheiro { get; set; }
        public bool EnvelopeConferido { get; set; }
        public double EnvelopeDinheiroDiferenca { get; set; }
        public string Observacao { get; set; }

        public int ClimaId { get; set; }
        public Clima Clima { get; set; }

        public int TurnoId { get; set; }
        public Turno Turno { get; set; }

        public bool AtencaoFlagVerificar { get; set; }
        public string AtencaoDescricao { get; set; }
        public string Operador { get; set; }
        public string PDV { get; set; }

        public ICollection<ResponsavelEnvelope> Responsaveis { get; set; }
    }
}
