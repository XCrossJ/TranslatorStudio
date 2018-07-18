using System;
using System.Linq;
using TranslatorStudioClassLibrary.Contracts.Controllers;
using TranslatorStudioClassLibrary.Contracts.Types;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudioClassLibrary.Controllers
{
    /// <summary>
    /// Project Controller that automatically skips empty raw lines and marks them as complete.
    /// </summary>
    public class AutoProjectController : IProjectController
    {
        #region MyRegion
        /// <summary>
        /// Base Project Controller to Decorate.
        /// </summary>
        private readonly IProjectController projectController;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates Auto Project Controller.
        /// </summary>
        /// <param name="projectController">Base Project Controller to Decorate.</param>
        public AutoProjectController(IProjectController projectController)
        {
            this.projectController = projectController ?? throw new ArgumentNullException(nameof(projectController));
        }
        #endregion

        #region Properties
        /// <summary>
        /// The current line of the project.
        /// </summary>
        public IProjectLineType CurrentLine => projectController.CurrentLine;

        /// <summary>
        /// The current raw line of the project.
        /// </summary>
        public string CurrentRaw { get => projectController.CurrentRaw; set => projectController.CurrentRaw = value; }
        /// <summary>
        /// The current translated line of the project.
        /// </summary>
        public string CurrentTranslation { get => projectController.CurrentTranslation; set => projectController.CurrentTranslation = value; }
        /// <summary>
        /// The comments associated to the project's current line.
        /// </summary>
        public string CurrentComment { get => projectController.CurrentComment; set => projectController.CurrentComment = value; }
        /// <summary>
        /// The completion status of the project's current line.
        /// </summary>
        public bool CurrentCompletion { get => projectController.CurrentCompletion; set => projectController.CurrentCompletion = value; }
        /// <summary>
        /// The marked status of the project's current line.
        /// </summary>
        public bool CurrentMarked { get => projectController.CurrentMarked; set => projectController.CurrentMarked = value; }

        /// <summary>
        /// The current index of the project.
        /// </summary>
        public int CurrentIndex { get => projectController.CurrentIndex; set => projectController.CurrentIndex = value; }
        /// <summary>
        /// The maximum possible index of the project.
        /// </summary>
        public int MaxIndex => projectController.MaxIndex;

        /// <summary>
        /// The number of lines in the project.
        /// </summary>
        public int NumberOfLines => GetProjectData().ProjectLines.Where(x => x.Raw.IsNotWhiteSpace()).Count();
        /// <summary>
        /// The number of completed lines in the project.
        /// </summary>
        public int NumberOfCompletedLines => projectController.NumberOfCompletedLines;
        #endregion

        #region Methods
        #region Commands
        /// <summary>
        /// Increments the current index.
        /// </summary>
        public void IncrementCurrentLine()
        {
            bool isCurrentRawNotEmpty = false;
            do
            {
                // Increment Current Line
                projectController.IncrementCurrentLine();

                // Determine if current raw is not empty
                isCurrentRawNotEmpty = CurrentRaw.IsNotWhiteSpace();

                // If current raw is not empty, Then maintain value. Else, auto mark as true.
                CurrentCompletion = isCurrentRawNotEmpty ? CurrentCompletion : true;

            } while (!isCurrentRawNotEmpty && CurrentIndex < MaxIndex);
        }
        /// <summary>
        /// Decrements the current index.
        /// </summary>
        public void DecrementCurrentLine()
        {
            bool isCurrentRawNotEmpty = false;
            do
            {
                // Decrement Current Line
                projectController.DecrementCurrentLine();

                // Determine if current raw is not empty
                isCurrentRawNotEmpty = CurrentRaw.IsNotWhiteSpace();

                // If current raw is not empty, Then maintain value. Else, auto mark as true.
                CurrentCompletion = isCurrentRawNotEmpty ? CurrentCompletion : true;

            } while (!isCurrentRawNotEmpty && CurrentIndex > 0);
        }

        /// <summary>
        /// Inserts specified raw line to project data at index.
        /// </summary>
        /// <param name="index">Index at which to insert value (null will insert value at end).</param>
        /// <param name="rawValue">Value of raw line to insert.</param>
        public void InsertLine(int? index, string rawValue)
        {
            projectController.InsertLine(index, rawValue);
        }
        /// <summary>
        /// Removes line from project data at index.
        /// </summary>
        /// <param name="index">Index at which to remove value (null will remove value at end).</param>
        public void RemoveLine(int? index)
        {
            projectController.RemoveLine(index);
        }
        #endregion

        #region Queries
        /// <summary>
        /// Gets Project Data.
        /// </summary>
        /// <returns>Project Data</returns>
        public IProjectDataType GetProjectData()
        {
            return projectController.GetProjectData();
        }
        #endregion
        #endregion
    }
}
