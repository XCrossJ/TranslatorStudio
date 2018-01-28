using System.Windows.Forms;
using TranslatorStudio.Forms;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudio.Interfaces
{
    public interface INewConsumer
    {
        #region Properties
        frmNew New { get; set; }
        #endregion

        #region Methods
        bool CreateNewProject();
        IProjectData CreateNewProjectFromRaw(DialogResult dialogResult, string fileName, string[] rawLines);
        bool QuitNew();
        bool ProcessShortcuts(Keys keyData);
        #endregion
    }
}
