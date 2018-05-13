using System;
using System.Windows.Forms;
using TranslatorStudio.Forms;
using TranslatorStudio.Interfaces;
using TranslatorStudio.Utilities;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudio.Consumers
{
    public class PreviewConsumer : IPreviewConsumer
    {
        #region Properties
        public FrmPreview Preview { get; set; }
        #endregion


        #region Constructors
        public PreviewConsumer(FrmPreview newFrmPreview)
        {
            Preview = newFrmPreview ?? throw new ArgumentNullException(nameof(newFrmPreview));
        }
        #endregion


        #region Methods
        public string GetPreviewTitle(string projectName)
        {
            return $@"Translator Studio - Preview ({projectName})";
        }

        public bool toggleCurrentComplete()
        {
            var index = Preview.PreviewCurrentIndex;
            var currentLine = GetProjectLine(index);
            currentLine.Completed = !currentLine.Completed;
            UpdateCellStyle(index);
            Preview.DataChanged = true;
            return true;
        }

        public bool toggleCurrentMarked()
        {
            var index = Preview.PreviewCurrentIndex;
            var currentLine = GetProjectLine(index);
            currentLine.Marked = !currentLine.Marked;
            UpdateCellStyle(index);
            Preview.DataChanged = true;
            return true;
        }


        public bool CopyRaw(string copyText)
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


        public bool CellValueChanged(DataGridViewCell currentCell)
        {
            if (currentCell != null)
            {
                Preview.Data.ProjectLines[currentCell.RowIndex].Translation = Convert.ToString(currentCell.Value);
                Preview.DataChanged = true;
                return true;
            }
            return false;
        }

        public bool UpdateCellStyle(int currentIndex)
        {
            var currentLine = GetProjectLine(currentIndex);
            var currentRow = Preview.Rows[currentIndex];
            if (currentLine.Marked)
                currentRow.DefaultCellStyle = ApplicationData.MarkedCellStyle;
            else if (currentLine.Completed)
                currentRow.DefaultCellStyle = ApplicationData.CompletedCellStyle;
            else
                currentRow.DefaultCellStyle = ApplicationData.DefaultCellStyle;
            return true;
        }


        public bool SaveChanges()
        {
            Preview.Desk.UpdateTranslationData(Preview.Data);
            Preview.DataChanged = false;
            return true;
        }


        public bool LoadPreview(DataGridView dataGridView)
        {
            int numberOfLines = Preview.Data.ProjectLines.Count;
            string numberFormat = numberOfLines.GetNumberFormat();
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            for (int i = 0; i < numberOfLines; i++)
            {
                var lineNumber = (i + 1).ToString(numberFormat);
                var currentLine = GetProjectLine(i);
                var rawLine = currentLine.Raw;
                var translatedLine = currentLine.Translation;

                rawLine = rawLine.IsNotEmpty() ? rawLine : "";
                translatedLine = translatedLine.IsNotEmpty() ? translatedLine : "";

                dataGridView.Rows.Add(new string[] { lineNumber, rawLine, translatedLine });

                UpdateCellStyle(i);
            }
            return true;
        }

        public bool ConfirmSave(FormClosingEventArgs e)
        {
            if (Preview.DataChanged)
            {
                var result = ApplicationData.MsgBox_ClosePreview_Confirmation(Preview);

                // Confirm user wants to close
                switch (result)
                {
                    case DialogResult.Yes:
                        return true;
                    case DialogResult.No: //TO DO: Need to Implement Via Shallow Copy
                                          //return false;
                    case DialogResult.Cancel:
                    default:
                        e.Cancel = true;
                        return false;
                }
            }
            return true;
        }

        private IProjectLine GetProjectLine(int index)
        {
            return Preview.Data.ProjectLines[index];
        }
        #endregion
    }
}
