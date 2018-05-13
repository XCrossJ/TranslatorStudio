using System.Collections.Generic;
using System.Windows.Forms;

namespace TranslatorStudio.Utilities
{
    public static class ApplicationData
    {
        #region Applications

        public static string GoogleTranslate => "https://translate.google.com/";
        public static string Weblio => "http://ejje.weblio.jp";

        #endregion

        #region Shortcuts

        public static List<string[]> Shortcuts => new List<string[]>
        {
            new string[] { "Translate", "(Ctrl + T)" },
            new string[] { "Next Line", "(Ctrl + Alt + Right-Arrow)" },
            new string[] { "Prev Line", "(Ctrl + Alt + Left-Arrow)" },
            new string[] { "Increase Font Size", "(Ctrl + Alt + Up-Arrow)" },
            new string[] { "Decrease Font Size", "(Ctrl + Alt + Down-Arrow)" },
            new string[] { "Mark Complete", "(Ctrl + Enter)" },
            new string[] { "Mark for Attention", "(Ctrl + M)" },
            new string[] { "Copy Raw", "(Ctrl + R)" },
            new string[] { "Preview Translation", "(Ctrl + P)" },
            new string[] { "Go to Google Translate", "(Ctrl + G)" },
            new string[] { "Go to Weblio", "(Ctrl + W)" },
            new string[] { "Save", "(Ctrl + S)" },
            new string[] { "Export", "(Ctrl + E)" }
        };

        #endregion

        #region Cell Styles

        public static DataGridViewCellStyle CompletedCellStyle => new DataGridViewCellStyle { BackColor = System.Drawing.Color.PaleGreen };
        public static DataGridViewCellStyle MarkedCellStyle => new DataGridViewCellStyle { BackColor = System.Drawing.Color.PaleGoldenrod };
        public static DataGridViewCellStyle DefaultCellStyle => new DataGridViewCellStyle();

        #endregion

        #region Information

        public static string About => "An application created by XCrossJ with the intent of making translations easier for fan translators.";

        #endregion

        #region File Dialogs

        public static OpenFileDialog OpenProjectDialog()
        {
            var filter = $@"Source and Project files (*.txt;*.docx;*.tsp;*.tsproj)|*.txt;*.docx;*.tsp;*.tsproj|All files (*.*)|*.*";
            var title = "Open Project or Raw Source File";
            return new OpenFileDialog
            {
                Multiselect = false,
                Filter = filter,
                Title = title,
                CheckFileExists = true,
            };
        }

        public static OpenFileDialog BatchConvertProjectDialog()
        {
            var filter = $@"Project files (*.tsp;*.tsproj)|*.tsp;*.tsproj|All files (*.*)|*.*";
            var title = "Select Project Files to Convert";
            return new OpenFileDialog
            {
                Multiselect = true,
                Filter = filter,
                Title = title,
                CheckFileExists = true,
            };
        }

        public static SaveFileDialog SaveProjectDialog(string fileName)
        {
            var filter = $@"Translator Studio Project files (*.tsproj)|*.tsproj";
            var title = "Save the Translation Project";
            return new SaveFileDialog
            {
                Filter = filter,
                Title = title,
                FileName = fileName
            };
        }

        public static SaveFileDialog ExportProjectDialog(string fileName)
        {
            var filter = $@"Text files (*.txt)|*.txt";
            var title = "Export current translation";
            return new SaveFileDialog
            {
                Filter = filter,
                Title = title,
                FileName = fileName
            };
        }

        #endregion

        #region Message Boxes

        public static DialogResult MsgBox_About(IWin32Window owner)
        {
            var message = About;
            var caption = "About";
            var buttons = MessageBoxButtons.OK;
            var icon = MessageBoxIcon.Information;

            return MessageBox.Show(owner, message, caption, buttons, icon);
        }

        public static DialogResult MsgBox_EmptyRawException(IWin32Window owner)
        {
            var message = "Raw is Empty or Null. Please provide Raw Text To Translate.";
            var caption = "Raw cannot be empty!";
            var buttons = MessageBoxButtons.OK;
            var icon = MessageBoxIcon.Exclamation;

            return MessageBox.Show(owner, message, caption, buttons, icon);
        }

        public static DialogResult MsgBox_NewProject_Confirmation(IWin32Window owner)
        {
            var message = "Load this raw text into the new project?";
            var caption = "Confirm Submission";
            var buttons = MessageBoxButtons.YesNoCancel;
            var icon = MessageBoxIcon.Question;

            return MessageBox.Show(owner, message, caption, buttons, icon);
        }

        public static DialogResult MsgBox_SaveProject_NoFileName()
        {
            var message = "Unable to save the project because the file name is empty.";
            var caption = "Warning";
            var buttons = MessageBoxButtons.OK;
            var icon = MessageBoxIcon.Warning;

            return MessageBox.Show(message, caption, buttons, icon);
        }

        public static DialogResult MsgBox_ExportProject_NoFileName()
        {
            var message = "Unable to export the project because the file name is empty.";
            var caption = "Warning";
            var buttons = MessageBoxButtons.OK;
            var icon = MessageBoxIcon.Warning;

            return MessageBox.Show(message, caption, buttons, icon);
        }

        public static DialogResult MsgBox_CopyRaw_RawEmpty()
        {
            var message = "Unable to copy to clipboard because Raw is empty.";
            var caption = "Warning";
            var buttons = MessageBoxButtons.OK;
            var icon = MessageBoxIcon.Warning;

            return MessageBox.Show(message, caption, buttons, icon);
        }

        public static DialogResult MsgBox_BeginMarkedOnlyMode_NoneMarked()
        {
            var message = "No lines were marked. Returning to Default Mode.";
            var caption = "No Marked Lines!";
            var buttons = MessageBoxButtons.OK;
            var icon = MessageBoxIcon.Warning;

            return MessageBox.Show(message, caption, buttons, icon);
        }

        public static DialogResult MsgBox_BeginIncompleteOnlyMode_NoneIncomplete()
        {
            var message = "No lines were incomplete. Returning to Default Mode.";
            var caption = "No Incomplete Lines!";
            var buttons = MessageBoxButtons.OK;
            var icon = MessageBoxIcon.Warning;

            return MessageBox.Show(message, caption, buttons, icon);
        }

        public static DialogResult MsgBox_BeginCompleteOnlyMode_NoneComplete()
        {
            var message = "No lines were complete. Returning to Default Mode.";
            var caption = "No Complete Lines!";
            var buttons = MessageBoxButtons.OK;
            var icon = MessageBoxIcon.Warning;

            return MessageBox.Show(message, caption, buttons, icon);
        }

        public static DialogResult MsgBox_CloseComment_Confirmation(IWin32Window owner)
        {
            var message = "Comment has been altered since last save. Do you want to save and close?";
            var caption = "Closing";
            var buttons = MessageBoxButtons.YesNoCancel;
            var icon = MessageBoxIcon.Question;

            return MessageBox.Show(owner, message, caption, buttons, icon);
        }

        public static DialogResult MsgBox_ClosePreview_Confirmation(IWin32Window owner)
        {
            var message = "Do you want to bring the changes made in this preview to the original project?";
            var caption = "Closing";
            var buttons = MessageBoxButtons.YesNoCancel;
            var icon = MessageBoxIcon.Question;

            return MessageBox.Show(owner, message, caption, buttons, icon);
        }

        public static DialogResult MsgBox_CloseDesk_Confirmation(IWin32Window owner)
        {
            var message = "Project has been altered since last save. Do you want to save and close project? (Any unsaved data will be lost)";
            var caption = "Closing";
            var buttons = MessageBoxButtons.YesNoCancel;
            var icon = MessageBoxIcon.Question;

            return MessageBox.Show(owner, message, caption, buttons, icon);
        }

        #endregion

    }
}
