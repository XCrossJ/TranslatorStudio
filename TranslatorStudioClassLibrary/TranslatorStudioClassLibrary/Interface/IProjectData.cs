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
        /// Contains all lines in the project.
        /// </summary>
        List<IProjectLine> ProjectLines { get; set; }
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
