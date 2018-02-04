using System.Windows.Forms;
using TranslatorStudio.Forms;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudio.Interfaces
{
    public interface IDeskConsumer
    {
        #region Properties
        FrmDesk Desk { get; set; }
        #endregion

        #region Setup & Update Methods
        bool DeskSetup();
        bool UpdateDesk();
        bool UpdateStatus();
        #endregion

        #region Methods
        bool NewProject();
        bool OpenProject();
        bool SaveProjectAs();
        bool SaveProject();
        bool ExportProject();
        bool PreviewProject();

        bool CopyText(string copyText);

        bool UpdateProjectName(string newProjectName);
        bool UpdateCurrentIndex(int newIndex);
        bool UpdateCurrentRaw(string newRaw);
        bool UpdateCurrentTranslation(string newTranslation);
        bool UpdateCurrentCompletion(bool newCompletion);
        bool UpdateCurrentMarked(bool newMarked);

        bool InsertLine();
        bool RemoveLine();
        bool ChangeEditMode();

        bool GoToNextLine();
        bool GoToPrevLine();
        bool IncreaseTextSize();
        bool DecreaseTextSize();
        bool FlipCompleteState();
        bool FlipMarkedState();
        bool NumberOfLinesChanged();

        bool BeginDefaultMode();
        bool BeginMarkedOnlyMode();
        bool BeginIncompleteOnlyMode();
        bool BeginCompleteOnlyMode();

        bool OpenGoogleTranslate();
        bool OpenWeblio();
        bool ShowAbout();
        bool ShowShortcuts();

        bool UpdateTranslationData(ITranslationData data);
        bool ResetTranslationDesk(ITranslationData data);
        bool ResetTranslationProject(ITranslationData data);

        bool ProcessShortcuts(Keys keyData);
        bool ConfirmSave(FormClosingEventArgs e);

        bool CloseDesk();
        #endregion
    }
}
