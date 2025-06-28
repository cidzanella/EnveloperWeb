
using EnveloperWeb.Domain.Envelopes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnveloperWeb.Infrastructure.Persistance.Configurations
{
    public class EnvelopeConfiguration : IEntityTypeConfiguration<Envelope>
    {
        public void Configure(EntityTypeBuilder<Envelope> builder)
        {
            builder.ToTable("envelope");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("id")
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.EnvelopeRotulo)
                   .HasColumnName("envelope_rotulo")
                   .HasMaxLength(100);

            builder.Property(e => e.DinheiroInicial)
                   .HasColumnName("dinheiro_inicial");

            builder.Property(e => e.DinheiroInicialDiferenca)
                   .HasColumnName("dinheiro_inicial_diferenca");

            builder.Property(e => e.DinheiroFinal)
                   .HasColumnName("dinheiro_final");

            builder.Property(e => e.VendasCartao)
                   .HasColumnName("vendas_cartao");

            builder.Property(e => e.SangriaTotalCaixa)
                   .HasColumnName("sangria_total_caixa");

            builder.Property(e => e.ReforcoTotalCaixa)
                   .HasColumnName("reforco_total_caixa");

            builder.Property(e => e.Faturamento)
                   .HasColumnName("faturamento");

            builder.Property(e => e.DiferencaFechamento)
                   .HasColumnName("diferenca_fechamento");

            builder.Property(e => e.PassagemCaixaDinheiro)
                   .HasColumnName("passagem_caixa_dinheiro");

            builder.Property(e => e.EnvelopeDinheiro)
                   .HasColumnName("envelope_dinheiro");

            builder.Property(e => e.EnvelopeConferido)
                   .HasColumnName("envelope_conferido");

            builder.Property(e => e.EnvelopeDinheiroDiferenca)
                   .HasColumnName("envelope_dinheiro_diferenca");

            builder.Property(e => e.Observacao)
                   .HasColumnName("observacao");

            builder.Property(e => e.DataHoraInicio)
                   .HasColumnName("data_abertura_caixa");

            builder.Property(e => e.DataHoraConclusao)
                   .HasColumnName("data_fechamento_caixa");

            builder.Property(e => e.TemperaturaTurno)
                   .HasColumnName("temperatura_turno");

            builder.Property(e => e.PDV)
                   .HasColumnName("pdv");

            builder.Property(e => e.Operador)
                   .HasColumnName("operador");

            builder.Property(e => e.AtencaoFlagVerificar)
                   .HasColumnName("atencao_flag_verificar");

            builder.Property(e => e.AtencaoDescricao)
                   .HasColumnName("atencao_descricao");

            builder.Property(e => e.ClimaId)
                   .HasColumnName("clima_id");

            builder.Property(e => e.TurnoId)
                   .HasColumnName("turno_id");

            builder.HasOne(e => e.Clima)
                   .WithMany()
                   .HasForeignKey(e => e.ClimaId);

            builder.HasOne(e => e.Turno)
                   .WithMany()
                   .HasForeignKey(e => e.TurnoId);
        }
    }
}
