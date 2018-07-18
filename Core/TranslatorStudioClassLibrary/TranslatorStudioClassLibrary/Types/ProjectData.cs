using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TranslatorStudioClassLibrary.Contracts.Enums;
using TranslatorStudioClassLibrary.Contracts.Types;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudioClassLibrary.Types
{
    /// <summary>
    /// Describes the core Project Data in the Translation Project.
    /// Used for saving.
    /// </summary>
    public class ProjectData : IProjectDataType, IEquatable<ProjectData>
    {
        #region Constructors
        /// <summary>
        /// Creates Project Data. Used in Json Serialisation.
        /// </summary>
        /// <param name="projectLines">Project Lines used in Project.</param>
        [JsonConstructor]
        public ProjectData(IList<ProjectLine> projectLines) :
            this(projectLines: projectLines.ToList<IProjectLineType>())
        {
            
        }
        /// <summary>
        /// Creates Project Data.
        /// (Will automatically set Save Format Version to Latest Available).
        /// </summary>
        /// <param name="projectLines">Project Lines used in Project.</param>
        public ProjectData(IList<IProjectLineType> projectLines) :
            this(projectLines: projectLines, projectName: null)
        {

        }
        /// <summary>
        /// Creates Project Data.
        /// (Will automatically set Save Format Version to Latest Available).
        /// </summary>
        /// <param name="projectLines">Project Lines used in Project.</param>
        public ProjectData(IList<IProjectLineType> projectLines, string projectName) :
            this(projectLines: projectLines, projectName: projectName, sourceLink: null)
        {

        }
        /// <summary>
        /// Creates Project Data.
        /// (Will automatically set Save Format Version to Latest Available).
        /// </summary>
        /// <param name="projectLines">Project Lines used in Project.</param>
        /// <param name="projectName">Project Name used in Project</param>
        /// <param name="sourceLink">Source Link used in Project</param>
        public ProjectData(IList<IProjectLineType> projectLines, string projectName, string sourceLink) :
            this(projectLines: projectLines, projectName: projectName, sourceLink: sourceLink, saveFormatVersion: SaveFormatVersionEnum.Legacy)
        {

        }
        /// <summary>
        /// Creates Project Data.
        /// </summary>
        /// <param name="projectLines">Project Lines used in Project.</param>
        /// <param name="projectName">Project Name used in Project</param>
        /// <param name="sourceLink">Source Link used in Project</param>
        /// <param name="saveFormatVersion">Save Format used in Project.</param>
        public ProjectData(IList<IProjectLineType> projectLines, string projectName, string sourceLink, SaveFormatVersionEnum saveFormatVersion)
        {
            ProjectLines = projectLines ?? throw new ArgumentNullException(nameof(projectLines));
            ProjectName = projectName;
            SourceLink = sourceLink;
            SaveFormatVersion = saveFormatVersion;
        }
        #endregion

        #region Properties
        /// <summary>
        /// The version number of the project save format.
        /// Increments as changes are made to contract.
        /// </summary>
        public SaveFormatVersionEnum SaveFormatVersion { get; set; }
        /// <summary>
        /// The name of the project.
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// The url to the project source (if applicable).
        /// </summary>
        public string SourceLink { get; set; }
        /// <summary>
        /// Contains all lines in the project.
        /// </summary>
        public IList<IProjectLineType> ProjectLines { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Gets JSON save string of the object used for saving.
        /// </summary>
        /// <returns>JSON string of object.</returns>
        public string GetSaveString()
        {
            return this.ToJSONString();
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(ProjectData other)
        {
            return other != null &&
                   SaveFormatVersion == other.SaveFormatVersion &&
                   ProjectName == other.ProjectName &&
                   SourceLink == other.SourceLink &&
                   ProjectLines.SequenceEqual(other.ProjectLines);
        }
        #endregion
    }
}
