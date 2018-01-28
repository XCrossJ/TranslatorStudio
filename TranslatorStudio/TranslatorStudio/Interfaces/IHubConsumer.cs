using System.Windows.Forms;
using TranslatorStudio.Forms;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudio.Interfaces
{
    public interface IHubConsumer
    {
        #region Properties
        FrmHub Hub { get; set; }
        #endregion

        #region Methods
        bool OpenFile();
        bool OpenNewFile();

        bool OpenDesk();
        bool SetDesk(ITranslationData data);

        FrmDesk CreateDeskFromOpenFile(OpenFileDialog dialog);

        bool ProcessShortcuts(Keys keyData);
        #endregion


        void Quit();
    }
}
