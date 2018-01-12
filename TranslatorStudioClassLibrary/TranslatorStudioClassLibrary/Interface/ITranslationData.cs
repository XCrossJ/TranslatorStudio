using System.Collections.Generic;

namespace TranslatorStudioClassLibrary.Interface
{
    public interface ITranslationData
    {
        #region Properties

        #region Project Data
        //IProjectData Data { get; set; }
        //ISubTranslationData SubData { get; set; }
        bool DefaultTranslationMode { get; set; }

        string ProjectName { get; set; }
        List<string> RawLines { get; set; }
        string[] TranslatedLines { get; set; }
        bool[] CompletedLines { get; set; }
        bool[] MarkedLines { get; set; }
        #endregion

        #region Project Controls
        string CurrentRaw { get; set; }
        string CurrentTranslation { get; set; }
        bool CurrentCompletion { get; set; }
        bool CurrentMarked { get; set; }

        int CurrentIndex { get; set; }
        int MaxIndex { get; }

        int NumberOfLines { get; }
        int NumberOfCompletedLines { get; }
        #endregion

        #endregion


        #region Methods
        void IncrementCurrentLine();
        void DecrementCurrentLine();

        string GetSaveString();

        void StartDefaultMode();
        int StartMarkedOnlyMode();
        int StartIncompleteOnlyMode();
        int StartCompleteOnlyMode();
        IProjectData GetProjectData();

        #endregion

    }
}
