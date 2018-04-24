namespace TranslatorStudioClassLibrary.Interface
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface that defines the public properties and methods required to store Translation Data.
    /// </summary>
    public interface ITranslationData
    {
        #region Properties

        #region Project Data

        /// <summary>
        /// Determines whether Default Translation Mode is turned on or not.
        /// </summary>
        bool DefaultTranslationMode { get; set; }
        /// <summary>
        /// Determines whether Auto Translation Mode is turned on or not.
        /// </summary>
        bool AutoTranslationMode { get; }
        /// <summary>
        /// Determines whether changed have been made to Translation Data.
        /// </summary>
        bool DataChanged { get; set; }

        /// <summary>
        /// The name of the project.
        /// </summary>
        string ProjectName { get; set; }
        /// <summary>
        /// The url to the project source.
        /// </summary>
        string SourceLink { get; set; }
        /// <summary>
        /// Contains all the lines in the translation.
        /// </summary>
        IList<IProjectLine> ProjectLines { get; set; }

        #endregion

        #region Project Controls

        /// <summary>
        /// The current project line in the translation.
        /// </summary>
        IProjectLine CurrentLine { get; set; }

        /// <summary>
        /// The current raw line in the translation.
        /// </summary>
        string CurrentRaw { get; set; }
        /// <summary>
        /// The current translated line in the translation.
        /// </summary>
        string CurrentTranslation { get; set; }
        /// <summary>
        /// The comment of the current line in the translation.
        /// </summary>
        string CurrentComment { get; set; }
        /// <summary>
        /// The completion status of the current line in the translation.
        /// </summary>
        bool CurrentCompletion { get; set; }
        /// <summary>
        /// The marked status of the current line in the translation.
        /// </summary>
        bool CurrentMarked { get; set; }

        /// <summary>
        /// The current index in the translation.
        /// </summary>
        int CurrentIndex { get; set; }
        /// <summary>
        /// The max index in the translation.
        /// </summary>
        int MaxIndex { get; }

        /// <summary>
        /// The number of lines in the translation.
        /// </summary>
        int NumberOfLines { get; }
        /// <summary>
        ///The number of completed lines in the translation.
        /// </summary>
        int NumberOfCompletedLines { get; }

        #endregion

        #endregion


        #region Methods

        /// <summary>
        /// Increments the current index.
        /// </summary>
        void IncrementCurrentLine();
        /// <summary>
        /// Decrements the current index.
        /// </summary>
        void DecrementCurrentLine();

        /// <summary>
        /// Inserts specified raw line to project data at index.
        /// </summary>
        /// <param name="index">Index at which to insert value (null will insert value at end).</param>
        /// <param name="rawValue">Value of raw line to insert.</param>
        void InsertLine(int? index, string rawValue);
        /// <summary>
        /// Removes line from project data at index.
        /// </summary>
        /// <param name="index">Index at which to remove value (null will remove value at end).</param>
        void RemoveLine(int? index);

        /// <summary>
        /// Gets JSON string of the project data used to save project.
        /// </summary>
        /// <returns>JSON string of project data.</returns>
        string GetProjectSaveString();

        /// <summary>
        /// Toggles auto translation mode. (Removes empty lines.)
        /// </summary>
        /// <param name="autoOn">Whether or not auto mode should be turned on or not.</param>
        /// <returns>Number of lines that are not empty.</returns>
        int ToggleAutoMode(bool autoOn);
        /// <summary>
        /// Initiates default translation mode.
        /// </summary>
        void StartDefaultMode();
        /// <summary>
        /// Initiates marked only translation mode. (Shows all marked lines only).
        /// </summary>
        /// <returns>Number of lines that are marked.</returns>
        int StartMarkedOnlyMode();
        /// <summary>
        /// Initates incomplete only translation mode. (Shows all incomplete lines only.)
        /// </summary>
        /// <returns>Number of lines that are incomplete.</returns>
        int StartIncompleteOnlyMode();
        /// <summary>
        /// Initiates complete only translation mode. (Shows all complete lines only.)
        /// </summary>
        /// <returns>Number of lines that are complete.</returns>
        int StartCompleteOnlyMode();
        /// <summary>
        /// Returns the project data used in the translation project.
        /// </summary>
        /// <returns>Object that implements Project Data Interface.</returns>
        IProjectData GetProjectData();

        #endregion
    }
}
