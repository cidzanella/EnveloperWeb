namespace EnveloperWeb.Infrastructure.ExternalServices.Printing.Utils
{
    /// <summary>
    /// Contém os códigos ESC/POS de formatação de texto para impressoras térmicas Bematech e similares.
    /// </summary>
    public static class PrinterTextFormatCodes
    {
        public const string BoldOn = "\x1B\x45\x01";
        public const string BoldOff = "\x1B\x45\x00";

        public const string FontSizeDouble = "\x1B\x4D\x01";
        public const string FontSizeNormal = "\x1B\x4D\x00";

        public const string Linefeed = "\n"; //Linefeed = "\r\n";
    }
}
