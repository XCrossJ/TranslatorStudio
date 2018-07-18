using System;
using TranslatorStudioClassLibrary.Contracts.Controllers;
using TranslatorStudioClassLibrary.Contracts.Types;
using TranslatorStudioClassLibrary.Controllers;

namespace TranslatorStudioClassLibrary.Builders
{
    /// <summary>
    /// Class dedicated to building the Desk Controller.
    /// </summary>
    public class DeskControllerBuilder
    {
        #region Constructors
        /// <summary>
        /// Creates Desk Controller Builder without params.
        /// (You will be required to supply necessary params to build Desk Controller.)
        /// </summary>
        public DeskControllerBuilder()
        {
        }
        /// <summary>
        /// Creates Desk Controller Builder with params.
        /// </summary>
        /// <param name="translationController">Translation Controller used to Build Desk Controller.</param>
        /// <param name="projectController">Project Controller used to Build Desk Controller.</param>
        public DeskControllerBuilder(ITranslationController translationController, IProjectController projectController)
        {
            TranslationController = translationController ?? throw new ArgumentNullException(nameof(translationController));
            ProjectController = projectController ?? throw new ArgumentNullException(nameof(projectController));
        }
        /// <summary>
        /// Creates Desk Controller Builder with default controllers.
        /// (Must supply Project Data).
        /// </summary>
        /// <param name="projectData">Project Data used to Build Desk Controller.</param>
        public DeskControllerBuilder(IProjectDataType projectData)
        {
            var data = projectData ?? throw new ArgumentNullException(nameof(projectData));
            
            TranslationController = new TranslationControllerBuilder().Build();
            ProjectController = new ProjectControllerBuilder(projectData).Build();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Translation Controller used to Build Desk Controller.
        /// </summary>
        private ITranslationController TranslationController { get; set; }
        /// <summary>
        /// Project Controller used to Build Desk Controller.
        /// </summary>
        private IProjectController ProjectController { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Assigns Translation Controller that Desk Controller Builder will build with.
        /// </summary>
        /// <param name="translationController">The Translation Controller that Desk Controller will be built with.</param>
        /// <returns>Desk Controller Builder.</returns>
        public DeskControllerBuilder With(ITranslationController translationController)
        {
            TranslationController = translationController ?? throw new ArgumentNullException(nameof(translationController));

            return this;
        }
        /// <summary>
        /// Assigns Project Controller that Desk Controller Builder will build with.
        /// </summary>
        /// <param name="projectController">The Project Controller that Desk Controller will be built with.</param>
        /// <returns>Desk Controller Builder.</returns>
        public DeskControllerBuilder With(IProjectController projectController)
        {
            ProjectController = projectController ?? throw new ArgumentNullException(nameof(projectController));

            return this;
        }

        /// <summary>
        /// Builds the Desk Controller.
        /// </summary>
        /// <returns>Desk Controller.</returns>
        public DeskController Build()
        {
            if (TranslationController == null)
                throw new ArgumentNullException(nameof(TranslationController));

            if (ProjectController == null)
                throw new ArgumentNullException(nameof(ProjectController));

            var deskController = new DeskController(TranslationController, ProjectController);

            return deskController;
        }
        #endregion
    }
}
