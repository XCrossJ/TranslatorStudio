using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TranslatorStudio.Forms;
using TranslatorStudio.Utilities;
using TranslatorStudioClassLibrary.Class;

namespace TranslatorStudio
{
    public partial class FrmDesk : Form
    {
        #region Global Variables
        private TranslationData _data;
        private frmNew _new;
        public FrmHub Hub { get; set; }
        public FrmPreview Preview { get; set; }
        private string _previousSavePath;
        private int _numberOfLines;
        private bool _unsavedData = true;
        #endregion

        #region Constructor
        public FrmDesk()
        {
            InitializeComponent();
        }
        public FrmDesk(TranslationData data, string prevSavePath, FrmHub hub)
        {
            InitializeComponent();

            _data = data;
            _previousSavePath = prevSavePath;
            Hub = hub;
            DeskSetup();
        }
        public FrmDesk(TranslationData data, FrmHub hub)
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
            lblCurrentLine.Text = $@"/ {_numberOfLines}";
            lblProgress.Text = $@"{_data.NumberOfCompletedLines} / {_data.NumberOfLines}";
            UpdateProgressBar(_data.NumberOfCompletedLines, _data.NumberOfLines);
        }

        private void UpdateProgressBar(int value, int max)
        {
            prgProgress.Minimum = 0;
            prgProgress.Maximum = max;
            prgProgress.Value = value;
            prgProgress.Refresh();
        }
        #endregion


        #region Control Events
        private void FrmDesk_Load(object sender, EventArgs e)
        {

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

        private void btnCopyRaw_Click(object sender, EventArgs e)
        {
            CopyRaw();
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

        private void btnGoogleTranslate_Click(object sender, EventArgs e)
        {
            OpenGoogleTranslate();
        }

        private void btnWeblio_Click(object sender, EventArgs e)
        {
            OpenWeblio();
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
            btnGoogleTranslate_Click(sender, e);
        }

        private void tsmiWeblio_Click(object sender, EventArgs e)
        {
            btnWeblio_Click(sender, e);
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
            var openRawFileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = $@"Source and Project files (*.txt;*.docx;*.tsp)|*.txt;*.docx;*.tsp|All files (*.*)|*.*",
                Title = "Open Project or Raw Source File"
            };

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
            var saveProjectFileDialog = new SaveFileDialog
            {
                Filter = $@"Translator Studio Project files (*.tsp)|*.tsp",
                Title = "Save the Translation Project",
                FileName = _data.ProjectName
            };
            if (saveProjectFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveProjectFileDialog.FileName != "")
                {
                    _unsavedData = !FileHelper.SaveProject(_data, saveProjectFileDialog.FileName);
                    _previousSavePath = saveProjectFileDialog.FileName;
                }
            }
        }

        private void SaveProject()
        {
            if (!string.IsNullOrEmpty(_previousSavePath))
            {
                _unsavedData = !FileHelper.SaveProject(_data, _previousSavePath);
            }
            else
            {
                SaveProjectAs();
            }
        }

        private void ExportProject()
        {
            var exportProjectFileDialog = new SaveFileDialog
            {
                Filter = $@"Text files (*.txt)|*.txt",
                Title = "Export current translation",
                FileName = _data.ProjectName
            };
            exportProjectFileDialog.ShowDialog();

            if (exportProjectFileDialog.FileName != "")
            {
                FileHelper.ExportTranslation(_data, exportProjectFileDialog.FileName);
            }
        }
        
        private void PreviewProject()
        {
            Preview = new FrmPreview(this, _data);
            Preview.ShowDialog();
        }

        private void CopyRaw()
        {
            var copyText = rtbRawContent.Text;
            if (!string.IsNullOrEmpty(copyText))
                Clipboard.SetText(copyText);
            else
                MessageBox.Show("Unable to copy to clipboard because Raw is empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            Process.Start(ApplicationData.GoogleTranslate);
        }

        private void OpenWeblio()
        {
            Process.Start(ApplicationData.Weblio);
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
            chkComplete.Checked = !chkComplete.Checked;
        }

        private void FlipMarkedState()
        {
            chkMark.Checked = !chkMark.Checked;
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
                case (Keys.Control | Keys.S):
                    tsmiSave_Click(this, new EventArgs());
                    return true;
                case (Keys.Control | Keys.E):
                    tsmiExport_Click(this, new EventArgs());
                    return true;
                case (Keys.Control | Keys.P):
                    btnPreview_Click(this, new EventArgs());
                    return true;
                case (Keys.Control | Keys.R):
                    btnCopyRaw_Click(this, new EventArgs());
                    return true;
                case (Keys.Control | Keys.G):
                    btnGoogleTranslate_Click(this, new EventArgs());
                    return true;
                case (Keys.Control | Keys.W):
                    btnWeblio_Click(this, new EventArgs());
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
                    chkComplete.Checked = !chkComplete.Checked;
                    return true;
                case (Keys.Control | Keys.M):
                    chkMark.Checked = !chkMark.Checked;
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        #endregion

        #region Methods
        private void GoToNextLine()
        {
            if (nudLineNumber.Value < nudLineNumber.Maximum)
                nudLineNumber.Value++;
            UpdateDesk();
        }

        private void GoToPrevLine()
        {
            if (nudLineNumber.Value > nudLineNumber.Minimum)
                nudLineNumber.Value--;
            UpdateDesk();
        }

        private void IncreaseTextSize()
        {
            var currentSize = rtbRawContent.Font.Size;
            currentSize += 1;
            if (currentSize < 30)
            {
                rtbRawContent.Font = new Font(rtbRawContent.Font.Name, currentSize, rtbRawContent.Font.Style, rtbRawContent.Font.Unit);
                rtbTranslationContent.Font = rtbRawContent.Font;
            }
        }

        private void DecreaseTextSize()
        {
            var currentSize = rtbRawContent.Font.Size;
            currentSize -= 1;
            if (currentSize > 0)
            {
                rtbRawContent.Font = new Font(rtbRawContent.Font.Name, currentSize, rtbRawContent.Font.Style, rtbRawContent.Font.Unit);
                rtbTranslationContent.Font = rtbRawContent.Font;
            }
        }

        private void BeginDefaultMode()
        {
            _data.DefaultTranslationMode = true;
            _numberOfLines = _data.NumberOfLines;
            nudLineNumber.Maximum = _numberOfLines;
            nudLineNumber.Value = 1;
            _data.CurrentIndex = 0;
        }
        private void BeginMarkedOnlyMode()
        {
            var noneMarked = Array.TrueForAll(_data.MarkedLines, value => { return value == false; });
            if (!noneMarked)
            {
                _data.DefaultTranslationMode = false;
                _numberOfLines = _data.StartMarkedOnlyMode();
                nudLineNumber.Maximum = _numberOfLines;
                nudLineNumber.Value = 1;
            }
            else
            {
                MessageBox.Show("No lines were marked. Returning to Default Mode.", "No Marked Lines!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEditMode.SelectedIndex = 0;
            }
        }
        private void BeginIncompleteOnlyMode()
        {
            var noneIncomplete = Array.TrueForAll(_data.CompletedLines, value => { return value == true; });
            if (!noneIncomplete)
            {
                _data.DefaultTranslationMode = false;
                _numberOfLines = _data.StartIncompleteOnlyMode();
                nudLineNumber.Maximum = _numberOfLines;
                nudLineNumber.Value = 1;
            }
            else
            {
                MessageBox.Show("No lines were incomplete. Returning to Default Mode.", "No Incomplete Lines!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEditMode.SelectedIndex = 0;
            }

        }
        private void BeginCompleteOnlyMode()
        {
            var noneComplete = Array.TrueForAll(_data.CompletedLines, value => { return value == false; });
            if (!noneComplete)
            {
                _data.DefaultTranslationMode = false;
                _numberOfLines = _data.StartCompleteOnlyMode();
                nudLineNumber.Maximum = _numberOfLines;
                nudLineNumber.Value = 1;
            }
            else
            {
                MessageBox.Show("No lines were complete. Returning to Default Mode.", "No Complete Lines!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEditMode.SelectedIndex = 0;
            }

        }

        private void OpenFile(string fileExt, string path, string fileName)
        {
            string previousSavePath = "";
            TranslationData data;
            switch (fileExt)
            {
                case ".tsp":
                    data = FileHelper.OpenTSPFile(path, fileName);
                    previousSavePath = path;
                    break;
                case ".docx":
                    data = FileHelper.OpenDocFile(path, fileName);
                    break;
                case ".txt":
                    data = FileHelper.OpenTextFile(path, fileName);
                    break;
                default:
                    throw new Exception("File Type Not Handled.");
            }
            ResetTranslationDesk(data);
        }

        public void UpdateTranslationData(TranslationData data)
        {
            _data = data;
            UpdateDesk();
        }

        public void ResetTranslationDesk(TranslationData data)
        {
            _data = data;
            cmbEditMode.SelectedIndex = 0;
            UpdateDesk();
        }

        public void ResetTranslationProject(TranslationData data)
        {
            _data = data;
            _previousSavePath = "";
            DeskSetup();
        }

        #endregion

    }
}
