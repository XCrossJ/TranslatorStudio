using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TranslatorStudio.Utilities;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudio.Forms
{
    public partial class FrmDesk : Form
    {
        #region Global Variables
        private ITranslationData _data;
        private frmNew _new;
        public FrmHub Hub { get; set; }
        public FrmPreview Preview { get; set; }
        private string _previousSavePath;
        private int _numberOfLines;
        private bool _unsavedData = true;

        private readonly ISubTranslationDataRepository subTranslationDataRepository = new SubTranslationDataRepository();
        #endregion

        #region Constructor
        public FrmDesk()
        {
            InitializeComponent();
        }
        public FrmDesk(ITranslationData data, string prevSavePath, FrmHub hub)
        {
            InitializeComponent();

            _data = data;
            _previousSavePath = prevSavePath;
            Hub = hub;
            DeskSetup();
        }
        public FrmDesk(ITranslationData data, FrmHub hub)
        {
            InitializeComponent();

            Hub = hub;
            ResetTranslationProject(data);
        }
        #endregion

        #region Setup & Update Methods
        private void DeskSetup()
        {
            _numberOfLines = _data.NumberOfLines;
            nudLineNumber.Maximum = _data.NumberOfLines;

            cmbEditMode.SelectedIndex = 0;
            UpdateDesk();
        }

        public void UpdateDesk()
        {
            if (_data != null)
            {
                rtbRawContent.Text = _data.CurrentRaw;
                rtbTranslationContent.Text = _data.CurrentTranslation;
                chkComplete.Checked = _data.CurrentCompletion;
                chkMark.Checked = _data.CurrentMarked;

                UpdateStatus();
            }
        }

        private void UpdateStatus()
        {
            txtProjectName.Text = _data.ProjectName;
            lblMaxLine.Text = $@"/ {_numberOfLines}";
            lblProgress.Text = $@"{_data.NumberOfCompletedLines} / {_data.NumberOfLines}";
            prgProgress.UpdateProgressBar(_data.NumberOfCompletedLines, _data.NumberOfLines);
        }
        
        #endregion


        #region Control Events
        private void FrmDesk_Load(object sender, EventArgs e)
        {

        }

        private void rtbRawContent_TextChanged(object sender, EventArgs e)
        {
            _data.CurrentRaw = rtbRawContent.Text;
        }

        private void rtbTranslationContent_TextChanged(object sender, EventArgs e)
        {
            _data.CurrentTranslation = rtbTranslationContent.Text;
        }

        private void chkComplete_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCurrentCompletion(chkComplete.Checked);
        }

        private void chkMark_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCurrentMarked(chkMark.Checked);
        }

        private void txtProjectName_TextChanged(object sender, EventArgs e)
        {
            _data.ProjectName = txtProjectName.Text;
        }

        private void nudLineNumber_ValueChanged(object sender, EventArgs e)
        {
            _data.CurrentIndex = (int)nudLineNumber.Value - 1;
            UpdateDesk();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            _data.InsertLine(_data.CurrentIndex, null);
            NumberOfLinesChanged();
            UpdateDesk();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (_data.NumberOfLines > 1)
            {
                _data.RemoveLine(_data.CurrentIndex);
                NumberOfLinesChanged();
                UpdateDesk();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            PreviewProject();
        }

        private void cmbEditMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbEditMode.SelectedItem)
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
            UpdateDesk();
        }

        #region Toolbar Events
        private void tsmiNew_Click(object sender, EventArgs e)
        {
            NewProject();
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            OpenProject();
        }

        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            SaveProjectAs();
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void tsmiExport_Click(object sender, EventArgs e)
        {
            ExportProject();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmiCopyRaw_Click(object sender, EventArgs e)
        {
            CopyRaw();
        }

        private void tsmiDefault_Click(object sender, EventArgs e)
        {
            cmbEditMode.SelectedItem = "Default";
        }

        private void tsmiIncompleteOnly_Click(object sender, EventArgs e)
        {
            cmbEditMode.SelectedItem = "Incomplete Lines";
        }

        private void tsmiMarkedOnly_Click(object sender, EventArgs e)
        {
            cmbEditMode.SelectedItem = "Marked Lines";
        }

        private void tsmiCompleteOnly_Click(object sender, EventArgs e)
        {
            cmbEditMode.SelectedItem = "Complete Lines";
        }

        private void tsmiPreview_Click(object sender, EventArgs e)
        {
            PreviewProject();
        }

        private void tsmiMarkComplete_Click(object sender, EventArgs e)
        {
            FlipCompleteState();
        }

        private void tsmiMarkAttention_Click(object sender, EventArgs e)
        {
            FlipMarkedState();
        }

        private void tsmiGoogleTranslate_Click(object sender, EventArgs e)
        {
            OpenGoogleTranslate();
        }

        private void tsmiWeblio_Click(object sender, EventArgs e)
        {
            OpenWeblio();
        }

        private void tsmiShortcuts_Click(object sender, EventArgs e)
        {
            ShowShortcuts();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            ShowAbout();
        }
        #endregion

        #region Context Strip Events
        private void cmsDesk_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tsmiContextComplete.Checked = _data.CurrentCompletion;
            tsmiContextMarked.Checked = _data.CurrentMarked;
        }

        private void tsmiNextLine_Click(object sender, EventArgs e)
        {
            GoToNextLine();
        }

        private void tsmiPrevLine_Click(object sender, EventArgs e)
        {
            GoToPrevLine();
        }

        private void tsmiContextComplete_Click(object sender, EventArgs e)
        {
            FlipCompleteState();
        }

        private void tsmiContextMarked_Click(object sender, EventArgs e)
        {
            FlipMarkedState();
        }

        private void tsmiContextCopyRaw_Click(object sender, EventArgs e)
        {
            CopyRaw();
        }

        private void tsmiContextShortcuts_Click(object sender, EventArgs e)
        {
            ShowShortcuts();
        }
        #endregion

        #endregion

        #region Action Methods
        private void NewProject()
        {
            _new = new frmNew(this);
            _new.ShowDialog();
        }

        private void OpenProject()
        {
            var openRawFileDialog = ApplicationData.OpenProjectDialog();

            if (openRawFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileExt = Path.GetExtension(openRawFileDialog.FileName);
                var filePath = openRawFileDialog.FileName;
                var fileName = Path.GetFileNameWithoutExtension(openRawFileDialog.SafeFileName);
                OpenFile(fileExt, filePath, fileName);
            }
        }

        private void SaveProjectAs()
        {
            var saveProjectFileDialog = ApplicationData.SaveProjectDialog(_data.ProjectName);
            if (saveProjectFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveProjectFileDialog.FileName != "")
                {
                    _unsavedData = !FileHelper.SaveProject(_data, saveProjectFileDialog.FileName);
                    _previousSavePath = saveProjectFileDialog.FileName;
                }
                else
                    ApplicationData.MsgBox_SaveProject_NoFileName();
            }
        }

        private void SaveProject()
        {
            if (!string.IsNullOrEmpty(_previousSavePath))
                _unsavedData = !FileHelper.SaveProject(_data, _previousSavePath);
            else
                SaveProjectAs();
        }

        private void ExportProject()
        {
            var exportProjectFileDialog = ApplicationData.ExportProjectDialog(_data.ProjectName);
            exportProjectFileDialog.ShowDialog();

            if (exportProjectFileDialog.FileName != "")
                FileHelper.ExportTranslation(_data, exportProjectFileDialog.FileName);
            else
                ApplicationData.MsgBox_ExportProject_NoFileName();
        }
        
        private void PreviewProject()
        {
            Preview = new FrmPreview(this, _data);
            Preview.ShowDialog();
        }

        private void CopyRaw()
        {
            try
            {
                rtbRawContent.Text.CopyTextToClipboard();
            }
            catch (ArgumentNullException)
            {
                ApplicationData.MsgBox_CopyRaw_RawEmpty();
            }

        }

        private void ChangeCurrentCompletion(bool currentCompletion)
        {
            _data.CurrentCompletion = currentCompletion;
            UpdateDesk();
        }

        private void ChangeCurrentMarked(bool currentMarked)
        {
            _data.CurrentMarked = currentMarked;
            UpdateDesk();
        }

        private void OpenGoogleTranslate()
        {
            ApplicationData.GoogleTranslate.StartProcess();
        }

        private void OpenWeblio()
        {
            ApplicationData.Weblio.StartProcess();
        }

        private void ShowAbout()
        {
            MessageBox.Show(ApplicationData.About, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowShortcuts()
        {
            new FrmShortcuts().ShowDialog();
        }

        private void FlipCompleteState()
        {
            chkComplete.FlipCheckboxState();
        }

        private void FlipMarkedState()
        {
            chkMark.FlipCheckboxState();
        }
        #endregion
        
        #region Other Events
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Confirm user wants to close
            if (_unsavedData)
            {
                switch (MessageBox.Show(this, "Are you sure you want to close? (Any unsaved data will be lost)", "Closing", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        Hub.Show();
                        break;
                    case DialogResult.No:
                    case DialogResult.Cancel:
                    default:
                        e.Cancel = true;
                        break;
                }
            }
            else
                Hub.Show();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Control | Keys.N):
                    NewProject();
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
                    CopyRaw();
                    return true;
                case (Keys.Control | Keys.G):
                    OpenGoogleTranslate();
                    return true;
                case (Keys.Control | Keys.W):
                    OpenWeblio();
                    return true;
                case (Keys.Control | Keys.T):
                    rtbTranslationContent.Focus();
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
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        #endregion

        #region Methods
        private void GoToNextLine()
        {
            nudLineNumber.IncrementNumericUpDown();
            UpdateDesk();
        }

        private void GoToPrevLine()
        {
            nudLineNumber.DecrementNumericUpDown();
            UpdateDesk();
        }

        private void IncreaseTextSize()
        {
            var newFont = FormHelper.IncreaseFontSize(rtbRawContent.Font);
            rtbRawContent.Font = newFont;
            rtbTranslationContent.Font = newFont;
        }

        private void DecreaseTextSize()
        {
            var newFont = FormHelper.DecreaseFontSize(rtbRawContent.Font);
            rtbRawContent.Font = newFont;
            rtbTranslationContent.Font = newFont;
        }

        private void NumberOfLinesChanged()
        {
            _numberOfLines = nudLineNumber.ChangeNumericUpDownMaximum(_data.NumberOfLines);
        }

        private void BeginDefaultMode()
        {
            _data.StartDefaultMode();
            _numberOfLines = nudLineNumber.ChangeNumericUpDownMaximum(_data.NumberOfLines);
            nudLineNumber.Value = 1;
        }
        private void BeginMarkedOnlyMode()
        {
            try
            {
                _numberOfLines = nudLineNumber.ChangeNumericUpDownMaximum(_data.StartMarkedOnlyMode(subTranslationDataRepository));
                nudLineNumber.Value = 1;
            }
            catch (Exception)
            {
                ApplicationData.MsgBox_BeginMarkedOnlyMode_NoneMarked();
                cmbEditMode.SelectedIndex = 0;
            }
        }
        private void BeginIncompleteOnlyMode()
        {
            try
            {
                _numberOfLines = nudLineNumber.ChangeNumericUpDownMaximum(_data.StartIncompleteOnlyMode(subTranslationDataRepository));
                nudLineNumber.Value = 1;
            }
            catch (Exception)
            {
                ApplicationData.MsgBox_BeginIncompleteOnlyMode_NoneIncomplete();
                cmbEditMode.SelectedIndex = 0;
            }
        }
        private void BeginCompleteOnlyMode()
        {
            try
            {
                _numberOfLines = nudLineNumber.ChangeNumericUpDownMaximum(_data.StartCompleteOnlyMode(subTranslationDataRepository));
                nudLineNumber.Value = 1;
            }
            catch (Exception)
            {
                ApplicationData.MsgBox_BeginCompleteOnlyMode_NoneComplete();
                cmbEditMode.SelectedIndex = 0;
            }
        }

        private void OpenFile(string fileExt, string path, string fileName)
        {
            var openData = FileHelper.OpenHandler(fileExt, path, fileName);
            ITranslationData data = openData.Item1;
            _previousSavePath = openData.Item2;
            ResetTranslationDesk(data);
        }

        public void UpdateTranslationData(ITranslationData data)
        {
            _data = data;
            UpdateDesk();
        }

        public void ResetTranslationDesk(ITranslationData data)
        {
            _data = data;
            cmbEditMode.SelectedIndex = 0;
            UpdateDesk();
        }

        public void ResetTranslationProject(ITranslationData data)
        {
            _data = data;
            _previousSavePath = "";
            DeskSetup();
        }

        #endregion

    }
}
