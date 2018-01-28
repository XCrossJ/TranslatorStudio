using System.Windows.Forms;
using TranslatorStudio.Forms;

namespace TranslatorStudio.Interfaces
{
    public interface IPreviewConsumer
    {
        #region Properties
        FrmPreview Preview { get; set; }
        #endregion

        #region Methods
        string GetPreviewTitle(string projectName);

        bool toggleCurrentComplete();
        bool toggleCurrentMarked();

        bool CopyRaw(string copyText);

        bool CellValueChanged(DataGridViewCell currentCell);
        bool UpdateCellStyle(int currentRow);
        
        bool SaveChanges();

        bool LoadPreview(DataGridView dataGridView);
        bool ConfirmSave(FormClosingEventArgs e);
        #endregion

    }
}
