using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using TranslatorStudio.Controls;

namespace TranslatorStudio.Utilities
{
    public static class FormHelper
    {
        #region Control Extension Methods
        public static void UpdateProgressBar(this ProgressBar progressBar, int value, int max)
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = max;
            progressBar.Value = value;
            progressBar.Refresh();
        }

        public static void IncrementNumericUpDown(this CustomNumericUpDown numericUpDown)
        {
            if (numericUpDown.Value < numericUpDown.Maximum)
                numericUpDown.UpButton();
        }

        public static void DecrementNumericUpDown(this CustomNumericUpDown numericUpDown)
        {
            if (numericUpDown.Value > numericUpDown.Minimum)
                numericUpDown.DownButton();
        }

        public static int ChangeNumericUpDownMaximum(this NumericUpDown numericUpDown, int NumberOfLines)
        {
            numericUpDown.Maximum = NumberOfLines;
            return NumberOfLines;
        }

        public static void CopyTextToClipboard(this string copyText)
        {
            Clipboard.SetText(copyText);
        }

        public static void FlipCheckboxState(this CheckBox checkBox)
        {
            checkBox.Checked = !checkBox.Checked;
        }

        public static Font IncreaseFontSize(this Font currentFont)
        {
            var currentSize = currentFont.Size;
            currentSize += 1;
            if (currentSize < 30)
                currentFont = new Font(currentFont.Name, currentSize, currentFont.Style, currentFont.Unit);
            return currentFont;
        }

        public static Font DecreaseFontSize(this Font currentFont)
        {
            var currentSize = currentFont.Size;
            currentSize -= 1;
            if (currentSize > 0)
                currentFont = new Font(currentFont.Name, currentSize, currentFont.Style, currentFont.Unit);
            return currentFont;
        }
        #endregion


        #region Other Extension Methods
        public static void StartProcess(this string processName)
        {
            Process.Start(processName);
        }
        #endregion
    }
}
