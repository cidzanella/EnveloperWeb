using EnveloperWeb.Domain.Contracts.Services;
using EnveloperWeb.Domain.Entities;

namespace EnveloperWeb.Application.Services.EnvelopeServices.Conclusao
{
    public class ValidarConclusaoEnvelopeService : IConclusaoEnvelopeValidator
    {
        public List<string> Validar(Envelope atual, Envelope anterior)
        {
            var erros = new List<string>();

            if (anterior != null && !ValidarPassagemAnterior(atual, anterior))
                erros.Add("Dinheiro inicial não confere com o valor de repasse do dia anterior.");

            if (!ValidarSomatorioFechamento(atual))
                erros.Add("Valor final não bate com o cálculo: inicial + entradas - saídas.");

            if (!ValidarEnvelopeMaisRepasse(atual))
                erros.Add("Dinheiro final diferente da soma: Envelope + Repasse.");

            return erros;
        }

        private bool ValidarPassagemAnterior(Envelope atual, Envelope anterior)
        {
            return Math.Abs(atual.DinheiroInicial - anterior.PassagemCaixaDinheiro) < 0.01;
        }

        private bool ValidarSomatorioFechamento(Envelope e)
        {
            double esperado = e.DinheiroInicial + e.Faturamento + e.ReforcoTotalCaixa - e.SangriaTotalCaixa;
            return Math.Abs(esperado - e.DinheiroFinal) < 0.01;
        }

        private bool ValidarEnvelopeMaisRepasse(Envelope e)
        {
            double esperado = e.EnvelopeDinheiro + e.PassagemCaixaDinheiro;
            return Math.Abs(esperado - e.DinheiroFinal) < 0.01;
        }
    }
}
