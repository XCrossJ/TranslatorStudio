using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TranslatorStudioClassLibrary.Contracts.Roles;
using TranslatorStudioClassLibrary.Contracts.Types;
using TranslatorStudioClassLibrary.Types;

namespace TranslatorStudioClassLibrary.Factories
{
    public class ProjectFactory : IProjectFactory
    {
        /// <summary>
        /// Builds Project Data based on input string.
        /// </summary>
        /// <param name="input">Input used to build project<./param>
        /// <returns>Built Project Data.</returns>
        public IProjectDataType BuildProject(string input)
        {
            var jsonString = input;
            var projectData = JsonConvert.DeserializeObject<ProjectData>(jsonString);
            return projectData;
        }

        /// <summary>
        /// Builds new Project Data based on input string and project name.
        /// </summary>
        /// <param name="input">Input used to build project.</param>
        /// <param name="projectName">Name used to build project.</param>
        /// <param name="sourceLink">Source Link used to build project.</param>
        /// <returns>Built Project Data.</returns>
        public IProjectDataType BuildNewProject(IEnumerable<string> input, string projectName, string sourceLink)
        {
            var projectLines = input.Select(x => new ProjectLine(x)).ToList<IProjectLineType>();
            IProjectDataType projectData = new ProjectData(projectLines, projectName, sourceLink);
            return projectData;
        }
    }
}
