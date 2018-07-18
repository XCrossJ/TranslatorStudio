using System;
using System.Collections.Generic;
using System.Linq;
using TranslatorStudioClassLibrary.Contracts.Controllers;
using TranslatorStudioClassLibrary.Contracts.Types;

namespace TranslatorStudioClassLibrary.Controllers
{
    /// <summary>
    /// Project Controller that filters out lines based on index reference.
    /// </summary>
    public class FilterProjectController : IProjectController
    {
        #region Fields
        /// <summary>
        /// Base Project Controller to Decorate
        /// </summary>
        private IProjectController projectController;
        /// <summary>
        /// Index Reference used to determine filtered lines.
        /// </summary>
        private readonly IList<int> indexReference;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates Filter Project Controller.
        /// </summary>
        /// <param name="projectController">Base Project Controller to Decorate.</param>
        /// <param name="indexReference">Index Reference used to determine filtered lines.</param>
        public FilterProjectController(IProjectController projectController, IList<int> indexReference)
        {
            this.projectController = projectController ?? throw new ArgumentNullException(nameof(projectController));
            this.indexReference = indexReference ?? throw new ArgumentNullException(nameof(indexReference));
            if (!this.indexReference.Any())
                throw new ArgumentNullException(nameof(indexReference));
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
        public int CurrentIndex
        {
            get
            {
                return Index;
            }
            set
            {
                Index = value;
                projectController.CurrentIndex = CurrentReference;
            }
        }
        /// <summary>
        /// The maximum possible index of the project.
        /// </summary>
        public int MaxIndex => NumberOfLines - 1;

        /// <summary>
        /// The number of lines in the project.
        /// </summary>
        public int NumberOfLines => indexReference.Count;
        /// <summary>
        /// The number of completed lines in the project.
        /// </summary>
        public int NumberOfCompletedLines => projectController.NumberOfCompletedLines;

        /// <summary>
        /// Stores the index of the project.
        /// </summary>
        private int Index { get; set; }
        /// <summary>
        /// Gets the current reference based on the current index.
        /// </summary>
        private int CurrentReference => indexReference[CurrentIndex];
        #endregion

        #region Methods
        #region Commands
        /// <summary>
        /// Increments the current index.
        /// </summary>
        public void IncrementCurrentLine()
        {
            if (CurrentIndex < MaxIndex)
            {
                CurrentIndex++;
            }
        }
        /// <summary>
        /// Decrements the current index.
        /// </summary>
        public void DecrementCurrentLine()
        {
            if (CurrentIndex > 0)
            {
                CurrentIndex--;
            }
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
