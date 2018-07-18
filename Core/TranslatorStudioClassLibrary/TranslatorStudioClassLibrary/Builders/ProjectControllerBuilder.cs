using System;
using TranslatorStudioClassLibrary.Contracts.Types;
using TranslatorStudioClassLibrary.Controllers;

namespace TranslatorStudioClassLibrary.Builders
{
    /// <summary>
    /// Class dedicated to building the Project Controller.
    /// </summary>
    public class ProjectControllerBuilder
    {
        #region Constructors
        /// <summary>
        /// Creates Project Controller Builder without params.
        /// (You will be required to supply necessary params to build Desk Controller.)
        /// </summary>
        public ProjectControllerBuilder()
        {
        }
        /// <summary>
        /// Creates Project Controller Builder with params.
        /// </summary>
        /// <param name="projectData">Project Data used to Build Project Controller.</param>
        public ProjectControllerBuilder(IProjectDataType projectData)
        {
            ProjectData = projectData ?? throw new ArgumentNullException(nameof(projectData));
        }
        #endregion

        #region Properties
        /// <summary>
        /// Project Data used to Build Project Controller.
        /// </summary>
        private IProjectDataType ProjectData { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Assigns Project Data that Project Controller Builder will build with.
        /// </summary>
        /// <param name="projectData">The Project Data that Project Controller will be built with.</param>
        /// <returns>Project Controller Builder.</returns>
        public ProjectControllerBuilder With(IProjectDataType projectData)
        {
            this.ProjectData = projectData ?? throw new ArgumentNullException(nameof(projectData));
            return this;
        }

        /// <summary>
        /// Builds the Project Controller.
        /// </summary>
        /// <returns>Project Controller.</returns>
        public ProjectController Build()
        {
            if (ProjectData == null)
                throw new ArgumentNullException(nameof(ProjectData));

            var projectController = new ProjectController(ProjectData);

            return projectController;
        }
        #endregion
    }
}
