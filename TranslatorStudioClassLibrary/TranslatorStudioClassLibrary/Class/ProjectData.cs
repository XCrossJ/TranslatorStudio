using System.Collections.Generic;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudioClassLibrary.Class
{
    /// <summary>
    /// Class that contains the properties and method relevant for Project Data.
    /// Implements Project Data Interface.
    /// </summary>
    public class ProjectData : IProjectData
    {
        #region Properties
        /// <summary>
        /// The name of the project.
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// Contains all of the raw lines in the project.
        /// </summary>
        public List<string> RawLines { get; set; }
        /// <summary>
        /// Contains all of the translated lines in the project.
        /// </summary>
        public List<string> TranslatedLines { get; set; }
        /// <summary>
        /// Contains the completion status of each line in the project.
        /// </summary>
        public List<bool> CompletedLines { get; set; }
        /// <summary>
        /// Contains the marked status of each line in the project.
        /// </summary>
        public List<bool> MarkedLines { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates empty Project Data.
        /// </summary>
        public ProjectData()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets JSON string of the project data used for saving.
        /// </summary>
        /// <returns>JSON string of project data.</returns>
        public string GetSaveString()
        {
            return this.ToJSONString();
        }
        #endregion        
    }
}
