using System;
using System.Collections.Generic;
using System.Linq;
using TranslatorStudioClassLibrary.Contracts.Controllers;
using TranslatorStudioClassLibrary.Contracts.Enums;
using TranslatorStudioClassLibrary.Contracts.Types;

namespace TranslatorStudioClassLibrary.Controllers
{
    /// <summary>
    /// Desk Controller used to operate the translation desk.
    /// </summary>
    public class DeskController : ITranslationController, IProjectController
    {
        #region Fields
        /// <summary>
        /// Translation Controller used to operate translation controls.
        /// </summary>
        private readonly ITranslationController translationController;
        /// <summary>
        /// Default Project Controller used to operate project controls.
        /// </summary>
        private readonly IProjectController defaultProjectController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates Desk Controller.
        /// </summary>
        /// <param name="translationController">Translation Controller used to operate translation controls.</param>
        /// <param name="defaultProjectController">Default Project Controller used to operate project controls.</param>
        public DeskController(ITranslationController translationController, IProjectController defaultProjectController)
        {
            this.translationController = translationController ?? throw new ArgumentNullException(nameof(translationController));
            this.defaultProjectController = defaultProjectController ?? throw new ArgumentNullException(nameof(defaultProjectController));

            ProjectController = SetupProjectController();
        }
        #endregion

        #region Properties
        #region Translation Controls
        /// <summary>
        /// Determines the Translation Mode.
        /// </summary>
        public TranslationModeEnum TranslationMode => translationController.TranslationMode;
        /// <summary>
        /// Determines whether Auto Translation Mode is turned on or not.
        /// </summary>
        public bool AutoTranslationMode => translationController.AutoTranslationMode;
        #endregion

        #region Project Controls
        /// <summary>
        /// The current line of the project.
        /// </summary>
        public IProjectLineType CurrentLine => ProjectController.CurrentLine;

        /// <summary>
        /// The current raw line of the project.
        /// </summary>
        public string CurrentRaw { get => ProjectController.CurrentRaw; set => ProjectController.CurrentRaw = value; }
        /// <summary>
        /// The current translated line of the project.
        /// </summary>
        public string CurrentTranslation { get => ProjectController.CurrentTranslation; set => ProjectController.CurrentTranslation = value; }
        /// <summary>
        /// The comments associated to the project's current line.
        /// </summary>
        public string CurrentComment { get => ProjectController.CurrentComment; set => ProjectController.CurrentComment = value; }
        /// <summary>
        /// The completion status of the project's current line.
        /// </summary>
        public bool CurrentCompletion { get => ProjectController.CurrentCompletion; set => ProjectController.CurrentCompletion = value; }
        /// <summary>
        /// The marked status of the project's current line.
        /// </summary>
        public bool CurrentMarked { get => ProjectController.CurrentMarked; set => ProjectController.CurrentMarked = value; }

        /// <summary>
        /// The current index of the project.
        /// </summary>
        public int CurrentIndex { get => ProjectController.CurrentIndex; set => ProjectController.CurrentIndex = value; }
        /// <summary>
        /// The maximum possible index of the project.
        /// </summary>
        public int MaxIndex => ProjectController.MaxIndex;

        /// <summary>
        /// The number of lines in the project.
        /// </summary>
        public int NumberOfLines => ProjectController.NumberOfLines;

        /// <summary>
        /// The number of completed lines in the project.
        /// </summary>
        public int NumberOfCompletedLines => ProjectController.NumberOfCompletedLines;
        #endregion

        #region Other
        /// <summary>
        /// Project Controller used to operate project controls.
        /// </summary>
        private IProjectController ProjectController { get; set; }
        #endregion
        #endregion

        #region Methods
        #region Translation Controls
        #region Commands
        /// <summary>
        /// Changes translation mode.
        /// </summary>
        /// <param name="newTranslationMode">The Translation Mode to change to.</param>
        public void ChangeTranslationMode(TranslationModeEnum newTranslationMode)
        {
            translationController.ChangeTranslationMode(newTranslationMode);
            ProjectController = SetupProjectController();
        }

        /// <summary>
        /// Toggles auto translation mode. (Removes empty lines.)
        /// </summary>
        /// <param name="autoOn">Whether or not auto mode should be turned on or not.</param>
        public void ToggleAutoMode(bool autoOn)
        {
            translationController.ToggleAutoMode(autoOn);
            ProjectController = SetupProjectController();
        }
        #endregion

        #region Queries
        /// <summary>
        /// Sets up Project Controller upon change of state.
        /// </summary>
        /// <returns>Set up Project Controller</returns>
        private IProjectController SetupProjectController()
        {
            var filterController = SetupFilterProjectController();
            var autoController = SetupAutoProjectController(filterController);
            return autoController;
        }

        /// <summary>
        /// Sets Up Project Controller upon change of Auto Translation Mode.
        /// </summary>
        /// <param name="filterProjectController">Filter Project Controller</param>
        /// <returns>Set up Project Controller.</returns>
        private IProjectController SetupAutoProjectController(IProjectController filterProjectController)
        {
            if (AutoTranslationMode)
            {
                return new AutoProjectController(filterProjectController);
            }
            return filterProjectController;
        }

        /// <summary>
        /// Sets Up Project Controller upon change of Translation Mode.
        /// </summary>
        /// <returns>Set up Project Controller.</returns>
        private IProjectController SetupFilterProjectController()
        {
            // Get original Project Data from Default Controller
            var sourceProjectData = GetProjectData();
            // Set up variable to contain lines with index
            var linesWithIndex = sourceProjectData.ProjectLines.Select((v, i) => new { v, i });

            switch (TranslationMode)
            {
                case TranslationModeEnum.Marked:
                    // Only gets marked lines
                    linesWithIndex = linesWithIndex.Where(x => x.v.Marked);
                    break;
                case TranslationModeEnum.Incomplete:
                    // Only gets incomplete lines
                    linesWithIndex = linesWithIndex.Where(x => !x.v.Completed);
                    break;
                case TranslationModeEnum.Complete:
                    // Only gets complete lines
                    linesWithIndex = linesWithIndex.Where(x => x.v.Completed);
                    break;
                case TranslationModeEnum.Default:
                    // Returns default project controller
                    return defaultProjectController;
                default:
                    throw new Exception();
            }

            // Get List of Indexes of Filtered Values
            IList<int> indexReference = linesWithIndex.Select(x => x.i).ToList();

            return new FilterProjectController(defaultProjectController, indexReference);
        }
        #endregion
        #endregion

        #region Project Controls
        #region Commands
        /// <summary>
        /// Increments the current index.
        /// </summary>
        public void IncrementCurrentLine()
        {
            ProjectController.IncrementCurrentLine();
        }
        /// <summary>
        /// Decrements the current index.
        /// </summary>
        public void DecrementCurrentLine()
        {
            ProjectController.DecrementCurrentLine();
        }

        /// <summary>
        /// Inserts specified raw line to project data at index.
        /// </summary>
        /// <param name="index">Index at which to insert value (null will insert value at end).</param>
        /// <param name="rawValue">Value of raw line to insert.</param>
        public void InsertLine(int? index, string rawValue)
        {
            ProjectController.InsertLine(index, rawValue);
        }
        /// <summary>
        /// Removes line from project data at index.
        /// </summary>
        /// <param name="index">Index at which to remove value (null will remove value at end).</param>
        public void RemoveLine(int? index)
        {
            ProjectController.RemoveLine(index);
        }
        #endregion

        #region Queries
        /// <summary>
        /// Gets Project Data.
        /// </summary>
        /// <returns>Project Data</returns>
        public IProjectDataType GetProjectData()
        {
            return defaultProjectController.GetProjectData();
        }
        #endregion
        #endregion
        #endregion
    }
}
