using System.Diagnostics;
using System.Windows.Forms;

namespace TranslatorStudio.Utilities
{
    public static class FormHelper
    {
        public static void FlipCheckboxState(this CheckBox checkBox)
        {
            checkBox.Checked = !checkBox.Checked;
        }

        public static void StartProcess(this string processName)
        {
            Process.Start(processName);
        }
    }
}
