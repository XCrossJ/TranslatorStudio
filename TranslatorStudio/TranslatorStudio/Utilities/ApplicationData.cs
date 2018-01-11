using System.Collections.Generic;
using System.Windows.Forms;

namespace TranslatorStudio.Utilities
{
    public static class ApplicationData
    {
        public static string GoogleTranslate => "https://translate.google.com/";
        public static string Weblio => "http://ejje.weblio.jp";

        public static List<string[]> Shortcuts => new List<string[]>
        {
            new string[] { "Translate", "(Ctrl + T)" },
            new string[] { "Next Line", "(Ctrl + Alt + Right-Arrow)" },
            new string[] { "Prev Line", "(Ctrl + Alt + Left-Arrow)" },
            new string[] { "Increase Font Size", "(Ctrl + Alt + Up-Arrow)" },
            new string[] { "Decrease Font Size", "(Ctrl + Alt + Down-Arrow)" },
            new string[] { "Mark Complete", "(Ctrl + M)" },
            new string[] { "Mark for Attention", "(Ctrl + Enter)" },
            new string[] { "Copy Raw", "(Ctrl + R)" },
            new string[] { "Preview Translation", "(Ctrl + P)" },
            new string[] { "Go to Google Translate", "(Ctrl + G)" },
            new string[] { "Go to Weblio", "(Ctrl + W)" },
            new string[] { "Save", "(Ctrl + S)" },
            new string[] { "Export", "(Ctrl + E)" }
        };

        public static string About => "An application created by XCrossJ with the intent of making translations easier for fan translators.";

        public static DataGridViewCellStyle CompletedCellStyle => new DataGridViewCellStyle { BackColor = System.Drawing.Color.PaleGreen };
        public static DataGridViewCellStyle MarkedCellStyle => new DataGridViewCellStyle { BackColor = System.Drawing.Color.PaleGoldenrod };
        public static DataGridViewCellStyle DefaultCellStyle => new DataGridViewCellStyle();
    }
}
