using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
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
        /// The version number of the project save format.
        /// Increments as changes are made to contract.
        /// </summary>
        public int SaveFormatVersion { get; set; } = 1; // Increment as changes are made to contract
        /// <summary>
        /// The name of the project.
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// The url to the project source.
        /// </summary>
        public string SourceLink { get; set; }
        /// <summary>
        /// Contains all lines in the project.
        /// </summary>
        public IList<IProjectLine> ProjectLines { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates empty Project Data.
        /// </summary>
        public ProjectData()
        {

        }

        /// <summary>
        /// Constructor used in Json Serialisation.
        /// </summary>
        /// <param name="projectLines">Project Lines used to construct Project Data.</param>
        [JsonConstructor]
        public ProjectData(IList<ProjectLine> projectLines)
        {
            ProjectLines = projectLines != null ? projectLines.ToList<IProjectLine>() : null;
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
