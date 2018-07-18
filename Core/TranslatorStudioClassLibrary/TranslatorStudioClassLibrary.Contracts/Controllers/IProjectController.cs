using TranslatorStudioClassLibrary.Contracts.Types;

namespace TranslatorStudioClassLibrary.Contracts.Controllers
{
    /// <summary>
    /// Describes the properties and methods used to control Project Data.
    /// </summary>
    public interface IProjectController
    {
        #region Properties
        /// <summary>
        /// The current line of the project.
        /// </summary>
        IProjectLineType CurrentLine { get; }

        /// <summary>
        /// The current raw line of the project.
        /// </summary>
        string CurrentRaw { get; set; }
        /// <summary>
        /// The current translated line of the project.
        /// </summary>
        string CurrentTranslation { get; set; }
        /// <summary>
        /// The comments associated to the project's current line.
        /// </summary>
        string CurrentComment { get; set; }
        /// <summary>
        /// The completion status of the project's current line.
        /// </summary>
        bool CurrentCompletion { get; set; }
        /// <summary>
        /// The marked status of the project's current line.
        /// </summary>
        bool CurrentMarked { get; set; }

        /// <summary>
        /// The current index of the project.
        /// </summary>
        int CurrentIndex { get; set; }
        /// <summary>
        /// The maximum possible index of the project.
        /// </summary>
        int MaxIndex { get; }

        /// <summary>
        /// The number of lines in the project.
        /// </summary>
        int NumberOfLines { get; }
        /// <summary>
        /// The number of completed lines in the project.
        /// </summary>
        int NumberOfCompletedLines { get; }
        #endregion


        #region Methods
        #region Commands
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
        #endregion

        #region Queries
        /// <summary>
        /// Gets Project Data.
        /// </summary>
        /// <returns>Project Data</returns>
        IProjectDataType GetProjectData();
        #endregion
        #endregion
    }
}
