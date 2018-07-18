using System.Collections.Generic;
using TranslatorStudioClassLibrary.Contracts.Enums;
using TranslatorStudioClassLibrary.Contracts.Roles;

namespace TranslatorStudioClassLibrary.Contracts.Types
{
    /// <summary>
    /// Describes the core Project Data in the Translation Project.
    /// Used for saving.
    /// </summary>
    public interface IProjectDataType : IProjectSaveable
    {
        /// <summary>
        /// The version number of the project save format.
        /// Increments as changes are made to contract.
        /// </summary>
        SaveFormatVersionEnum SaveFormatVersion { get; set; }
        /// <summary>
        /// The name of the project.
        /// </summary>
        string ProjectName { get; set; }
        /// <summary>
        /// The url to the project source (if applicable).
        /// </summary>
        string SourceLink { get; set; }
        /// <summary>
        /// Contains all lines in the project.
        /// </summary>
        IList<IProjectLineType> ProjectLines { get; set; }
    }
}
