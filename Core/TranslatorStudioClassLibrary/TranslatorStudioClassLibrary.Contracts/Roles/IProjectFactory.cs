using System.Collections.Generic;
using TranslatorStudioClassLibrary.Contracts.Types;

namespace TranslatorStudioClassLibrary.Contracts.Roles
{
    /// <summary>
    /// Module that builds Project Data.
    /// </summary>
    public interface IProjectFactory
    {
        /// <summary>
        /// Builds Project Data based on input string.
        /// </summary>
        /// <param name="input">Input used to build project<./param>
        /// <returns>Built Project Data.</returns>
        IProjectDataType BuildProject(string input);

        /// <summary>
        /// Builds new Project Data based on input string and project name.
        /// </summary>
        /// <param name="input">Input used to build project.</param>
        /// <param name="projectName">Name used to build project.</param>
        /// <param name="sourceLink">Source Link used to build project.</param>
        /// <returns>Built Project Data.</returns>
        IProjectDataType BuildNewProject(IEnumerable<string> input, string projectName, string sourceLink);
    }
}
