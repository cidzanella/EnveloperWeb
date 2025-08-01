using System.Text;

namespace EnveloperWeb.Infrastructure.ExternalServices.Printing.Utils
{
    public static class ReciboFormatter
    {
        public static string Interpretar(string texto)
        {
            var sb = new StringBuilder();
            var linhas = texto.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);


            foreach (var linha in linhas)
            {
                if (linha.StartsWith("##") && linha.EndsWith("##"))
                {
                    var conteudo = linha.Substring(2, linha.Length - 4);
                    sb.Append(PrinterTextFormatCodes.FontSizeDouble);
                    sb.AppendLine(conteudo);
                    sb.Append(PrinterTextFormatCodes.FontSizeNormal);
                }
                else if (linha.StartsWith("**") && linha.EndsWith("**"))
                {
                    var conteudo = linha.Substring(2, linha.Length - 4);
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
