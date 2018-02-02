using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TranslatorStudio.Forms;
using TranslatorStudio.Interfaces;
using TranslatorStudio.Utilities;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudio.Consumers
{
    public class DeskConsumer : IDeskConsumer
    {
        #region Properties
        public FrmDesk Desk { get; set; }
        public ITranslationData Data { get => Desk.Data; set => Desk.Data = value; }
        private readonly ISubTranslationDataRepository subTranslationDataRepository = new SubTranslationDataRepository();
        #endregion

        #region Constructors
        public DeskConsumer(FrmDesk frmDesk)
        {
            Desk = frmDesk;
        }
        #endregion

        #region Setup & Update Methods
        public bool DeskSetup()
        {
            Desk.NumberOfLines = Data.NumberOfLines;
            Desk.NudLineNumber.Maximum = Data.NumberOfLines;

            Desk.CmbEditMode.SelectedIndex = 0;
            return UpdateDesk();
        }
        public bool UpdateDesk()
        {
            if (Data != null)
            {
                Desk.RtbRawContent.Text = Data.CurrentRaw;
                Desk.RtbTranslationContent.Text = Data.CurrentTranslation;
                Desk.ChkComplete.Checked = Data.CurrentCompletion;
                Desk.ChkMark.Checked = Data.CurrentMarked;

                return UpdateStatus();
            }
            return false;
        }
        public bool UpdateStatus()
        {
            Desk.TxtProjectName.Text = Data.ProjectName;
            Desk.LblMaxLine.Text = $@"/ {Desk.NumberOfLines}";
            Desk.LblProgress.Text = $@"{Data.NumberOfCompletedLines} / {Data.NumberOfLines}";
            Desk.PrgProgress.UpdateProgressBar(Data.NumberOfCompletedLines, Data.NumberOfLines);
            return true;
        }
        #endregion

        #region Public Methods
        public bool NewProject()
        {
            Desk.New = new frmNew(Desk);
            Desk.New.ShowDialog();
            return true;
        }
        public bool OpenProject()
        {
            var openRawFileDialog = ApplicationData.OpenProjectDialog();

            if (openRawFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileExt = Path.GetExtension(openRawFileDialog.FileName);
                var filePath = openRawFileDialog.FileName;
                var fileName = Path.GetFileNameWithoutExtension(openRawFileDialog.SafeFileName);
                OpenFile(fileExt, filePath, fileName);
            }

            return true;
        }
        public bool SaveProjectAs()
        {
            var saveProjectFileDialog = ApplicationData.SaveProjectDialog(Data.ProjectName);
            if (saveProjectFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveProjectFileDialog.FileName != "")
                {
                    Desk.UnsavedData = !FileHelper.SaveProject(Data, saveProjectFileDialog.FileName);
                    Desk.PreviousSavePath = saveProjectFileDialog.FileName;
                    return true;
                }
                else
                    ApplicationData.MsgBox_SaveProject_NoFileName();
            }
            return false;
        }
        public bool SaveProject()
        {
            if (!string.IsNullOrEmpty(Desk.PreviousSavePath))
                Desk.UnsavedData = !FileHelper.SaveProject(Data, Desk.PreviousSavePath);
            else
                SaveProjectAs();
            return true;
        }
        public bool ExportProject()
        {
            var exportProjectFileDialog = ApplicationData.ExportProjectDialog(Data.ProjectName);
            exportProjectFileDialog.ShowDialog();

            if (exportProjectFileDialog.FileName != "")
                FileHelper.ExportTranslation(Data, exportProjectFileDialog.FileName);
            else
                ApplicationData.MsgBox_ExportProject_NoFileName();
            return true;
        }
        public bool PreviewProject()
        {
            Desk.Preview = new FrmPreview(Desk, Data);
            Desk.Preview.ShowDialog();
            return true;
        }

        public bool CopyText(string copyText)
        {
            if (!string.IsNullOrEmpty(copyText))
            {
                Clipboard.SetText(copyText);
                return true;
            }
            else
            {
                ApplicationData.MsgBox_CopyRaw_RawEmpty();
                return false;
            }
        }

        public bool UpdateProjectName(string newProjectName)
        {
            Data.ProjectName = newProjectName;
            return true;
        }
        public bool UpdateCurrentIndex(int newIndex)
        {
            Data.CurrentIndex = newIndex;
            return UpdateDesk();
        }
        public bool UpdateCurrentRaw(string newRaw)
        {
            Data.CurrentRaw = newRaw;
            return true;
        }
        public bool UpdateCurrentTranslation(string newTranslation)
        {
            Data.CurrentTranslation= newTranslation;
            return true;
        }
        public bool UpdateCurrentCompletion(bool currentCompletion)
        {
            Data.CurrentCompletion = currentCompletion;
            UpdateDesk();
            return true;
        }
        public bool UpdateCurrentMarked(bool currentMarked)
        {
            Data.CurrentMarked = currentMarked;
            UpdateDesk();
            return true;
        }

        public bool InsertLine()
        {
            Data.InsertLine(Data.CurrentIndex, null);
            NumberOfLinesChanged();
            return UpdateDesk();
        }
        public bool RemoveLine()
        {
            if (Data.NumberOfLines > 1)
            {
                Data.RemoveLine(Data.CurrentIndex);
                NumberOfLinesChanged();
                return UpdateDesk();
            }
            return false;
        }
        public bool ChangeEditMode()
        {
            switch (Desk.CmbEditMode.SelectedItem)
            {
                case "Default":
                    BeginDefaultMode();
                    break;
                case "Incomplete Lines":
                    BeginIncompleteOnlyMode();
                    break;
                case "Complete Lines":
                    BeginCompleteOnlyMode();
                    break;
                case "Marked Lines":
                    BeginMarkedOnlyMode();
                    break;
                default:
                    break;
            }
            return UpdateDesk();
        }

        public bool GoToNextLine()
        {
            Desk.NudLineNumber.IncrementNumericUpDown();
            return UpdateDesk();
        }
        public bool GoToPrevLine()
        {
            Desk.NudLineNumber.DecrementNumericUpDown();
            return UpdateDesk();
        }
        public bool IncreaseTextSize()
        {
            var newFont = FormHelper.IncreaseFontSize(Desk.RtbRawContent.Font);
            Desk.RtbRawContent.Font = newFont;
            Desk.RtbTranslationContent.Font = newFont;
            return true;
        }
        public bool DecreaseTextSize()
        {
            var newFont = FormHelper.DecreaseFontSize(Desk.RtbRawContent.Font);
            Desk.RtbRawContent.Font = newFont;
            Desk.RtbTranslationContent.Font = newFont;
            return true;
        }
        public bool FlipCompleteState()
        {
            Desk.ChkComplete.FlipCheckboxState();
            return true;
        }
        public bool FlipMarkedState()
        {
            Desk.ChkMark.FlipCheckboxState();
            return true;
        }
        public bool NumberOfLinesChanged()
        {
            Desk.NumberOfLines = Desk.NudLineNumber.ChangeNumericUpDownMaximum(Data.NumberOfLines);
            return true;
        }

        public bool BeginDefaultMode()
        {
            Data.StartDefaultMode();
            Desk.NumberOfLines = Desk.NudLineNumber.ChangeNumericUpDownMaximum(Data.NumberOfLines);
            Desk.NudLineNumber.Value = 1;
            return true;
        }
        public bool BeginMarkedOnlyMode()
        {
            try
            {
                Desk.NumberOfLines = Desk.NudLineNumber.ChangeNumericUpDownMaximum(Data.StartMarkedOnlyMode(subTranslationDataRepository));
                Desk.NudLineNumber.Value = 1;
            }
            catch (Exception)
            {
                ApplicationData.MsgBox_BeginMarkedOnlyMode_NoneMarked();
                Desk.CmbEditMode.SelectedIndex = 0;
            }
            return true;
        }
        public bool BeginIncompleteOnlyMode()
        {
            try
            {
                Desk.NumberOfLines = Desk.NudLineNumber.ChangeNumericUpDownMaximum(Data.StartIncompleteOnlyMode(subTranslationDataRepository));
                Desk.NudLineNumber.Value = 1;
            }
            catch (Exception)
            {
                ApplicationData.MsgBox_BeginIncompleteOnlyMode_NoneIncomplete();
                Desk.CmbEditMode.SelectedIndex = 0;
            }
            return true;
        }
        public bool BeginCompleteOnlyMode()
        {
            try
            {
                Desk.NumberOfLines = Desk.NudLineNumber.ChangeNumericUpDownMaximum(Data.StartCompleteOnlyMode(subTranslationDataRepository));
                Desk.NudLineNumber.Value = 1;
            }
            catch (Exception)
            {
                ApplicationData.MsgBox_BeginCompleteOnlyMode_NoneComplete();
                Desk.CmbEditMode.SelectedIndex = 0;
            }
            return true;
        }

        public bool OpenGoogleTranslate()
        {
            ApplicationData.GoogleTranslate.StartProcess();
            return true;
        }
        public bool OpenWeblio()
        {
            ApplicationData.Weblio.StartProcess();
            return true;
        }
        public bool ShowAbout()
        {
            MessageBox.Show(ApplicationData.About, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
        public bool ShowShortcuts()
        {
            new FrmShortcuts().ShowDialog();
            return true;
        }

        public bool UpdateTranslationData(ITranslationData data)
        {
            Data = data;
            return UpdateDesk();
        }
        public bool ResetTranslationDesk(ITranslationData data)
        {
            Data = data;
            Desk.CmbEditMode.SelectedIndex = 0;
            return UpdateDesk();
        }
        public bool ResetTranslationProject(ITranslationData data)
        {
            Data = data;
            Desk.PreviousSavePath = "";
            return DeskSetup();
        }

        public bool ProcessShortcuts(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Control | Keys.N):
                    NewProject();
                    return true;
                case (Keys.Control | Keys.O):
                    OpenProject();
                    return true;
                case (Keys.Control | Keys.S):
                    SaveProject();
                    return true;
                case (Keys.Control | Keys.E):
                    ExportProject();
                    return true;
                case (Keys.Control | Keys.P):
                    PreviewProject();
                    return true;
                case (Keys.Control | Keys.R):
                    CopyText(Desk.RtbRawContent.Text);
                    return true;
                case (Keys.Control | Keys.G):
                    OpenGoogleTranslate();
                    return true;
                case (Keys.Control | Keys.W):
                    OpenWeblio();
                    return true;
                case (Keys.Control | Keys.T):
                    Desk.RtbTranslationContent.Focus();
                    return true;
                case (Keys.Control | Keys.Alt | Keys.Right):
                    GoToNextLine();
                    return true;
                case (Keys.Control | Keys.Alt | Keys.Left):
                    GoToPrevLine();
                    return true;
                case (Keys.Control | Keys.Alt | Keys.Up):
                    IncreaseTextSize();
                    return true;
                case (Keys.Control | Keys.Alt | Keys.Down):
                    DecreaseTextSize();
                    return true;
                case (Keys.Control | Keys.Enter):
                    FlipCompleteState();
                    return true;
                case (Keys.Control | Keys.M):
                    FlipMarkedState();
                    return true;
                default:
                    return false;
            }
        }

        public bool CloseDesk()
        {
            Desk.Close();
            return true;
        }
        #endregion

        #region Private Methods
        private bool OpenFile(string fileExt, string path, string fileName)
        {
            var openData = FileHelper.OpenHandler(fileExt, path, fileName);
            ITranslationData data = openData.Item1;
            Desk.PreviousSavePath = openData.Item2;
            ResetTranslationDesk(data);
            return true;
        }
        #endregion

    }
}
