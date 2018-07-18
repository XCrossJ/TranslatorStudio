using System;
using System.Collections.Generic;
using System.Linq;
using TranslatorStudioClassLibrary.Contracts.Controllers;
using TranslatorStudioClassLibrary.Contracts.Types;
using TranslatorStudioClassLibrary.Types;

namespace TranslatorStudioClassLibrary.Controllers
{
    public class ProjectController : IProjectController
    {
        #region Fields
        /// <summary>
        /// Project Data used as Data Source 
        /// </summary>
        private IProjectDataType projectData;
        /// <summary>
        /// Project Lines obtained from Project Data
        /// </summary>
        private IList<IProjectLineType> ProjectLines => projectData.ProjectLines;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates Project Controller.
        /// </summary>
        /// <param name="projectData">Project Data used as Data Source.</param>
        public ProjectController(IProjectDataType projectData)
        {
            this.projectData = projectData ?? throw new ArgumentNullException(nameof(projectData));
        }
        #endregion

        #region Properties
        /// <summary>
        /// The current line of the project.
        /// </summary>
        public IProjectLineType CurrentLine => ProjectLines[CurrentIndex];

        /// <summary>
        /// The current raw line of the project.
        /// </summary>
        public string CurrentRaw { get => CurrentLine.Raw; set => CurrentLine.Raw = value; }
        /// <summary>
        /// The current translated line of the project.
        /// </summary>
        public string CurrentTranslation { get => CurrentLine.Translation; set => CurrentLine.Translation = value; }
        /// <summary>
        /// The comments associated to the project's current line.
        /// </summary>
        public string CurrentComment { get => CurrentLine.Comment; set => CurrentLine.Comment = value; }
        /// <summary>
        /// The completion status of the project's current line.
        /// </summary>
        public bool CurrentCompletion { get => CurrentLine.Completed; set => CurrentLine.Completed = value; }
        /// <summary>
        /// The marked status of the project's current line.
        /// </summary>
        public bool CurrentMarked { get => CurrentLine.Marked; set => CurrentLine.Marked = value; }

        /// <summary>
        /// The current index of the project.
        /// </summary>
        public int CurrentIndex { get; set; }
        /// <summary>
        /// The maximum possible index of the project.
        /// </summary>
        public int MaxIndex => NumberOfLines - 1;

        /// <summary>
        /// The number of lines in the project.
        /// </summary>
        public int NumberOfLines => ProjectLines.Count;
        /// <summary>
        /// The number of completed lines in the project.
        /// </summary>
        public int NumberOfCompletedLines => ProjectLines.Where(x => x.Completed).Count();
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
            int insertionIndex = index ?? NumberOfLines;

            rawValue = rawValue ?? "";

            IProjectLineType newLine = new ProjectLine(rawValue);

            ProjectLines.Insert(insertionIndex, newLine);
        }
        /// <summary>
        /// Removes line from project data at index.
        /// </summary>
        /// <param name="index">Index at which to remove value (null will remove value at end).</param>
        public void RemoveLine(int? index)
        {
            if (MaxIndex == 0)
                //throw ExceptionHelper.NewRemovalOfLastLineException;
                throw new Exception();
            int removalIndex = index ?? MaxIndex;

            ProjectLines.RemoveAt(removalIndex);
        }
        #endregion

        #region Queries
        /// <summary>
        /// Gets Project Data.
        /// </summary>
        /// <returns>Project Data</returns>
        public IProjectDataType GetProjectData()
        {
            return projectData;
        }
        #endregion
        #endregion
    }
}
