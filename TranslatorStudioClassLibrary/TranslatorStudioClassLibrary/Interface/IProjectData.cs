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
        /// The name of the project.
        /// </summary>
        string ProjectName { get; set; }
        /// <summary>
        /// Contains all of the raw lines in the project.
        /// </summary>
        List<string> RawLines { get; set; }
        /// <summary>
        /// Contains all of the translated lines in the project.
        /// </summary>
        List<string> TranslatedLines { get; set; }
        /// <summary>
        /// Contains the completion status of each line in the project.
        /// </summary>
        List<bool> CompletedLines { get; set; }
        /// <summary>
        /// Contains the marked status of each line in the project.
        /// </summary>
        List<bool> MarkedLines { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Gets JSON string of the project data used for saving.
        /// </summary>
        /// <returns>JSON string of project data.</returns>
        string GetSaveString();
        #endregion
    }
}
