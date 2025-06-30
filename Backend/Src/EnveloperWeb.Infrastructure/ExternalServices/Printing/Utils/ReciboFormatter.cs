using System.Text;

namespace EnveloperWeb.Infrastructure.ExternalServices.Printing.Utils
{
    public static class ReciboFormatter
    {
        public static string Interpretar(string texto)
        {
            var sb = new StringBuilder();
            var linhas = texto.Split('\n');

            foreach (var linha in linhas)
            {
                if (linha.StartsWith("##") && linha.EndsWith("##"))
                {
                    var conteudo = linha.Trim('#');
                    sb.Append(PrinterTextFormatCodes.FontSizeDouble);
                    sb.AppendLine(conteudo);
                    sb.Append(PrinterTextFormatCodes.FontSizeNormal);
                }
                else if (linha.StartsWith("**") && linha.EndsWith("**"))
                {
                    var conteudo = linha.Trim('*');
                    sb.Append(PrinterTextFormatCodes.BoldOn);
                    sb.AppendLine(conteudo);
                    sb.Append(PrinterTextFormatCodes.BoldOff);
                }
                else
                {
                    sb.AppendLine(linha);
                }
            }

            return sb.ToString();
        }
    }
}
