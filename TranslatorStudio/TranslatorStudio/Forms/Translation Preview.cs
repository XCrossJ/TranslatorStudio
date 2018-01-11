using System;
using System.ComponentModel;
using System.Windows.Forms;
using TranslatorStudio.Utilities;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudio.Forms
{
    public partial class FrmPreview : Form
    {
        //Possible Drag Drop Functionality
        //https://www.experts-exchange.com/questions/27604665/Swap-2-cells-on-datagridview-with-drag-and-drop-VB-NET.html

        #region Global Variables
        private FrmDesk _desk;
        private TranslationData _data;
        private bool _dataChanged = false;
        #endregion

        #region Constructors
        public FrmPreview(FrmDesk desk, TranslationData data)
        {
            InitializeComponent();
            _desk = desk;
            _data = data;
            LoadPreview();
        }
        #endregion

        #region Control Events
        private void Translation_Preview_Load(object sender, EventArgs e)
        {
            Text = $@"Translator Studio - Preview ({_data.ProjectName})";
        }

        private void dgvPreview_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPreview.CurrentCell != null)
            {
                var currentCell = dgvPreview.CurrentCell;
                _data.TranslatedLines[currentCell.RowIndex] = Convert.ToString(currentCell.Value);
                _dataChanged = true;
            }
        }

        private void cmsPreview_Opening(object sender, CancelEventArgs e)
        {
            var currentRow = dgvPreview.CurrentRow.Index;
            tsmiMarkComplete.Checked = _data.CompletedLines[currentRow];
            tsmiMarkAttention.Checked = _data.MarkedLines[currentRow];
        }

        private void tsmiMarkComplete_Click(object sender, EventArgs e)
        {
            var currentRow = dgvPreview.CurrentRow.Index;
            _data.CompletedLines[currentRow] = !_data.CompletedLines[currentRow];
            UpdateCellStyle(currentRow);
            _dataChanged = true;
        }

        private void tsmiMarkAttention_Click(object sender, EventArgs e)
        {
            var currentRow = dgvPreview.CurrentRow.Index;
            _data.MarkedLines[currentRow] = !_data.MarkedLines[currentRow];
            UpdateCellStyle(currentRow);
            _dataChanged = true;
        }

        private void tsmiCopyRaw_Click(object sender, EventArgs e)
        {
            var currentRow = dgvPreview.CurrentRow.Index;
            var copyText = _data.RawLines[currentRow];
            if (!string.IsNullOrEmpty(copyText))
                Clipboard.SetText(copyText);
            else
                MessageBox.Show("Unable to copy to clipboard because Raw is empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tsmiSaveChanges_Click(object sender, EventArgs e)
        {
            _desk.UpdateTranslationData(_data);
            _dataChanged = false;
        }
        #endregion

        #region Methods
        private void LoadPreview()
        {
            int numberOfLines = _data.RawLines.Count;
            string numberFormat = numberOfLines.GetNumberFormat();
            dgvPreview.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvPreview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            for (int i = 0; i < numberOfLines; i++)
            {
                var lineNumber = (i + 1).ToString(numberFormat);
                var rawLine = _data.RawLines[i];
                var translatedLine = _data.TranslatedLines[i];

                rawLine = !string.IsNullOrEmpty(rawLine) ? rawLine : "";
                translatedLine = !string.IsNullOrEmpty(translatedLine) ? translatedLine : "";

                dgvPreview.Rows.Add(new string[] { lineNumber, rawLine, translatedLine });

                UpdateCellStyle(i);
            }
        }

        private void UpdateCellStyle(int currentRow)
        {
            if (_data.MarkedLines[currentRow])
                dgvPreview.Rows[currentRow].DefaultCellStyle = ApplicationData.MarkedCellStyle;
            else if (_data.CompletedLines[currentRow])
                dgvPreview.Rows[currentRow].DefaultCellStyle = ApplicationData.CompletedCellStyle;
            else
                dgvPreview.Rows[currentRow].DefaultCellStyle = ApplicationData.DefaultCellStyle;
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (_dataChanged)
            {
                // Confirm user wants to close
                switch (MessageBox.Show(this, "Do you want to bring the changes made in this preview to the original project?", "Closing", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        break;
                    case DialogResult.No:
                    case DialogResult.Cancel:
                    default:
                        e.Cancel = true;
                        break;
                }
            }
            _desk.ResetTranslationDesk(_data);
        }
        #endregion

    }
}
