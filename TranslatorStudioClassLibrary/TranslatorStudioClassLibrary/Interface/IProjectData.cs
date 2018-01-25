using System.Collections.Generic;

namespace TranslatorStudioClassLibrary.Interface
{
    /// <summary>
    /// Interface that defines the public properties and methods required to store Project Data.
    /// </summary>
    public interface IProjectData
    {
        #region Properties
        /// <summary>
        /// Project Name:
        ///     property that contains the name of the project.
        /// </summary>
        string ProjectName { get; set; }
        /// <summary>
        /// Raw Lines:
        ///     property that contains all of the raw lines in the project.
        /// </summary>
        List<string> RawLines { get; set; }
        /// <summary>
        /// Translated Lines:
        ///     property that contains all of the translated lines in the project.
        /// </summary>
        List<string> TranslatedLines { get; set; }
        /// <summary>
        /// Completed Lines:
        ///     property that contains the completion status of each line in the project.
        /// </summary>
        List<bool> CompletedLines { get; set; }
        /// <summary>
        /// Marked Lines:
        ///     property that contains the marked status of each line in the project.
        /// </summary>
        List<bool> MarkedLines { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Get Save String:
        ///     gets the save string of the project data.
        /// </summary>
        /// <returns>string: JSON string of project data.</returns>
        string GetSaveString();
        #endregion
    }
}
