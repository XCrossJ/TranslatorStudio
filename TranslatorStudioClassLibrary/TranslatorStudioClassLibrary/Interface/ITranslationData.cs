using System.Collections.Generic;

namespace TranslatorStudioClassLibrary.Interface
{
    /// <summary>
    /// Interface that defines the public properties and methods required to store Translation Data.
    /// </summary>
    public interface ITranslationData
    {
        #region Properties

        #region Project Data
        /// <summary>
        /// DefaultTranslationMode:
        ///     property that determines whether Default Translation Mode is turned on or not.
        ///     returns type bool.
        /// </summary>
        bool DefaultTranslationMode { get; set; }

        /// <summary>
        /// Project Name:
        ///     property that contains the name of the project.
        ///     returns type string.
        /// </summary>
        string ProjectName { get; set; }
        /// <summary>
        /// Raw Lines:
        ///     property that contains all of the raw lines in the translation.
        ///     returns type List<string>.
        /// </summary>
        List<string> RawLines { get; set; }
        /// <summary>
        /// Translated Lines:
        ///     property that contains all of the translated lines in the translation.
        ///     returns type List<string>.
        /// </summary>
        List<string> TranslatedLines { get; set; }
        /// <summary>
        /// Completed Lines:
        ///     property that contains the completion status of each line in the translation.
        ///     returns type List<bool>.
        /// </summary>
        List<bool> CompletedLines { get; set; }
        /// <summary>
        /// Marked Lines:
        ///     property that contains the marked status of each line in the translation.
        ///     returns type List<bool>.
        /// </summary>
        List<bool> MarkedLines { get; set; }
        #endregion

        #region Project Controls
        /// <summary>
        /// Current Raw:
        ///     property that contains the current raw line in the translation.
        ///     returns type string.
        /// </summary>
        string CurrentRaw { get; set; }
        /// <summary>
        /// Current Translation:
        ///     property that contains the current translated line in the translation.
        ///     returns type string.
        /// </summary>
        string CurrentTranslation { get; set; }
        /// <summary>
        /// Current Completion:
        ///     property that contains the completion status of the current line in the translation.
        ///     returns type bool.
        /// </summary>
        bool CurrentCompletion { get; set; }
        /// <summary>
        /// Current Marked:
        ///     property that contains the marked status of the current line in the translation.
        ///     returns type bool.
        /// </summary>
        bool CurrentMarked { get; set; }

        /// <summary>
        /// Current Index:
        ///     property that contains the current index in the translation.
        ///     returns type int.
        /// </summary>
        int CurrentIndex { get; set; }
        /// <summary>
        /// Max Index:
        ///     property that contains the max index in the translation.
        ///     returns type int.
        /// </summary>
        int MaxIndex { get; }

        /// <summary>
        /// Number Of Lines:
        ///     property that contains the number of lines in the translation.
        ///     returns type int.
        /// </summary>
        int NumberOfLines { get; }
        /// <summary>
        /// Numbder Of Completed Lines:
        ///     property that contains max number of lines in the translations.
        ///     returns type int.
        /// </summary>
        int NumberOfCompletedLines { get; }
        #endregion

        #endregion


        #region Methods
        /// <summary>
        /// Increment Current Line:
        ///     increments the current index.
        /// </summary>
        void IncrementCurrentLine();
        /// <summary>
        /// Decrement Current Line:
        ///     decrement the current index.
        /// </summary>
        void DecrementCurrentLine();

        /// <summary>
        /// Get Save String:
        ///     gets the save string of the project data.
        /// </summary>
        /// <returns>string: JSON string of project data.</returns>
        string GetSaveString();

        /// <summary>
        /// Start Default Mode:
        ///     initiates default translation mode.
        /// </summary>
        void StartDefaultMode();
        /// <summary>
        /// Start Marked Only Mode:
        ///     initiates marked only translation mode.
        /// </summary>
        /// <returns>int: returns number of lines.</returns>
        int StartMarkedOnlyMode();
        /// <summary>
        /// Start Incomplete Only Mode:
        ///     initates incomplete only translation mode.
        /// </summary>
        /// <returns>int: returns number of lines.</returns>
        int StartIncompleteOnlyMode();
        /// <summary>
        /// Start Complete Only Mode:
        ///     initiates complete only translation mode.
        /// </summary>
        /// <returns>int: returns number of lines.</returns>
        int StartCompleteOnlyMode();
        /// <summary>
        /// Get Project Data:
        ///     property that returns project data for translation.
        /// </summary>
        /// <returns>IProjectData: object that implements Project Data Interface.</returns>
        IProjectData GetProjectData();
        #endregion

    }
}
