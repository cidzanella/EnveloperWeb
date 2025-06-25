using EnveloperWeb.Domain.Contracts.Services;
using EnveloperWeb.Domain.Entities;

namespace EnveloperWeb.Application.Services.EnvelopeServices.Inicio
{
    public class ValidarInicioEnvelopeService : IInicioEnvelopeValidator
    {
        public List<string> Validar(Envelope atual, Envelope anterior)
        {
            var erros = new List<string>();

            if (anterior != null && !ValidarPassagemAnterior(atual, anterior))
                erros.Add("Dinheiro inicial não confere com o valor de repasse do dia anterior.");

            if (!ValidarValorInicial(atual))
                erros.Add("Valor inicial informado não pode ser negativo.");

            return erros;
        }

        private bool ValidarPassagemAnterior(Envelope atual, Envelope anterior)
        {
            return Math.Abs(atual.DinheiroInicial - anterior.PassagemCaixaDinheiro) < 0.01;
        }

        private bool ValidarValorInicial(Envelope atual)
        {
            return atual.DinheiroInicial >= 0;
        }
    }
}
