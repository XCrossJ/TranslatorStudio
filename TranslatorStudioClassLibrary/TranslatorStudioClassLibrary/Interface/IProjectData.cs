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
        /// The version number of the project save format.
        /// Increments as changes are made to contract.
        /// </summary>
        int SaveFormatVersion { get; set; }
        /// <summary>
        /// The name of the project.
        /// </summary>
        string ProjectName { get; set; }
        /// <summary>
        /// The url to the project source.
        /// </summary>
        string SourceLink { get; set; }
        /// <summary>
        /// Contains all lines in the project.
        /// </summary>
        IList<IProjectLine> ProjectLines { get; set; }
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
