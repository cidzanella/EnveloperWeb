namespace EnveloperWeb.Infrastructure.ExternalServices.Printing.Utils
{
    /// <summary>
    /// Contém os códigos ESC/POS de formatação de texto para impressoras térmicas Bematech e similares.
    /// </summary>
    public static class PrinterTextFormatCodes
    {
        public const string NegritoLigado = "\x1B\x45\x01";
        public const string NegritoDesligado = "\x1B\x45\x00";

        public const string FontePequena = "\x1B\x4D\x01";
        public const string FonteNormal = "\x1B\x4D\x00";

        public const string PularLinha = "\n";
    }
}
