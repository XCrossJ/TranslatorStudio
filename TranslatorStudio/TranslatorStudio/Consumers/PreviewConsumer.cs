using System;
using System.Windows.Forms;
using TranslatorStudio.Forms;
using TranslatorStudio.Interfaces;
using TranslatorStudio.Utilities;
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
            Preview = newFrmPreview;
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
            Preview.Data.CompletedLines[index] = !Preview.Data.CompletedLines[index];
            UpdateCellStyle(index);
            Preview.DataChanged = true;
            return true;
        }

        public bool toggleCurrentMarked()
        {
            var index = Preview.PreviewCurrentIndex;
            Preview.Data.MarkedLines[index] = !Preview.Data.MarkedLines[index];
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
                Preview.Data.TranslatedLines[currentCell.RowIndex] = Convert.ToString(currentCell.Value);
                Preview.DataChanged = true;
                return true;
            }
            return false;
        }

        public bool UpdateCellStyle(int currentRow)
        {
            if (Preview.Data.MarkedLines[currentRow])
                Preview.Rows[currentRow].DefaultCellStyle = ApplicationData.MarkedCellStyle;
            else if (Preview.Data.CompletedLines[currentRow])
                Preview.Rows[currentRow].DefaultCellStyle = ApplicationData.CompletedCellStyle;
            else
                Preview.Rows[currentRow].DefaultCellStyle = ApplicationData.DefaultCellStyle;
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
            int numberOfLines = Preview.Data.RawLines.Count;
            string numberFormat = numberOfLines.GetNumberFormat();
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            for (int i = 0; i < numberOfLines; i++)
            {
                var lineNumber = (i + 1).ToString(numberFormat);
                var rawLine = Preview.Data.RawLines[i];
                var translatedLine = Preview.Data.TranslatedLines[i];

                rawLine = !string.IsNullOrEmpty(rawLine) ? rawLine : "";
                translatedLine = !string.IsNullOrEmpty(translatedLine) ? translatedLine : "";

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
        #endregion

    }
}
