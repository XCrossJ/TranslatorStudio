using System.Collections.Generic;
using System.Linq;
using TranslatorStudioClassLibrary.Exception;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudioClassLibrary.Class
{
    /// <summary>
    /// Class that contains the properties and method relevant for Translation Data.
    /// Implements Translation Data Interface.
    /// </summary>
    public class TranslationData : ITranslationData
    {
        #region Properties

        #region Project Data
        /// <summary>
        /// Private property that contains Project Data.
        /// </summary>
        private IProjectData Data { get; set; }
        /// <summary>
        /// Private property that contains Sub Translation Data.
        /// </summary>
        private ISubTranslationData SubData { get; set; }
        /// <summary>
        /// Determines whether Default Translation Mode is turned on or not.
        /// </summary>
        public bool DefaultTranslationMode { get; set; } = true;

        /// <summary>
        /// The name of the project.
        /// </summary>
        public string ProjectName
        {
            get => Data.ProjectName;
            set => Data.ProjectName = value;
        }
        /// <summary>
        /// Contains all of the raw lines in the translation.
        /// </summary>
        public List<string> RawLines
        {
            get => Data.RawLines;
            set => Data.RawLines = value;
        }
        /// <summary>
        /// Contains all of the translated lines in the translation.
        /// </summary>
        public List<string> TranslatedLines
        {
            get => Data.TranslatedLines;
            set => Data.TranslatedLines = value;
        }
        /// <summary>
        /// Contains the completion status of each line in the translation.
        /// </summary>
        public List<bool> CompletedLines
        {
            get => Data.CompletedLines;
            set => Data.CompletedLines = value;
        }
        /// <summary>
        /// Contains the marked status of each line in the translation.
        /// </summary>
        public List<bool> MarkedLines
        {
            get => Data.MarkedLines;
            set => Data.MarkedLines = value;
        }
        #endregion

        #region Project Controls
        /// <summary>
        /// The current raw line in the translation.
        /// </summary>
        public string CurrentRaw
        {
            get => DefaultTranslationMode ? Data.RawLines[CurrentIndex] : Data.RawLines[SubData.CurrentReference];
            set
            {
                if (DefaultTranslationMode)
                    RawLines[CurrentIndex] = value;
                else
                    RawLines[SubData.CurrentReference] = value;
            }
        }
        /// <summary>
        /// The current translated line in the translation.
        /// </summary>
        public string CurrentTranslation
        {
            get => DefaultTranslationMode ? TranslatedLines[CurrentIndex] : TranslatedLines[SubData.CurrentReference];
            set
            {
                if (DefaultTranslationMode)
                    TranslatedLines[CurrentIndex] = value;
                else
                    TranslatedLines[SubData.CurrentReference] = value;
            }
        }
        /// <summary>
        /// The completion status of the current line in the translation.
        /// </summary>
        public bool CurrentCompletion
        {
            get => DefaultTranslationMode ? CompletedLines[CurrentIndex] : CompletedLines[SubData.CurrentReference];
            set
            {
                if (DefaultTranslationMode)
                    CompletedLines[CurrentIndex] = value;
                else
                    CompletedLines[SubData.CurrentReference] = value;
            }
        }
        /// <summary>
        /// The marked status of the current line in the translation.
        /// </summary>
        public bool CurrentMarked
        {
            get => DefaultTranslationMode ? MarkedLines[CurrentIndex] : MarkedLines[SubData.CurrentReference];
            set
            {
                if (DefaultTranslationMode)
                    MarkedLines[CurrentIndex] = value;
                else
                    MarkedLines[SubData.CurrentReference] = value;
            }
        }

        /// <summary>
        /// Private property that contains the current index.
        /// </summary>
        private int _index = 0;
        /// <summary>
        /// The current index in the translation.
        /// </summary>
        public int CurrentIndex
        {
            get => DefaultTranslationMode ? _index : SubData.CurrentIndex;
            set
            {
                if (DefaultTranslationMode)
                    _index = value;
                else
                    SubData.CurrentIndex = value;

            }
        }
        /// <summary>
        /// The max index in the translation.
        /// </summary>
        public int MaxIndex => DefaultTranslationMode ? RawLines.Count - 1 : SubData.MaxIndex;

        /// <summary>
        /// The number of lines in the translation.
        /// </summary>
        public int NumberOfLines => RawLines.Count;
        /// <summary>
        ///The number of completed lines in the translation.
        /// </summary>
        public int NumberOfCompletedLines => CompletedLines.Where(c => c).Count();
        #endregion

        #endregion


        #region Constructors
        /// <summary>
        /// Creates empty Translation Data.
        /// </summary>
        public TranslationData()
        {

        }

        /// <summary>
        /// Creates Translation Data based on passed Project Data
        /// </summary>
        /// <param name="data">Object that implements Project Data Interface.</param>
        public TranslationData(IProjectData data)
        {
            Data = data;
            CurrentIndex = 0;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Increments the current index.
        /// </summary>
        public void IncrementCurrentLine()
        {
            if (CurrentIndex != MaxIndex)
                CurrentIndex++;
        }
        /// <summary>
        /// Decrements the current index.
        /// </summary>
        public void DecrementCurrentLine()
        {
            if (CurrentIndex != 0)
                CurrentIndex--;
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
            RawLines.Insert(insertionIndex, rawValue);
            TranslatedLines.Insert(insertionIndex, "");
            CompletedLines.Insert(insertionIndex, false);
            MarkedLines.Insert(insertionIndex, false);
        }
        /// <summary>
        /// Removes line from project data at index.
        /// </summary>
        /// <param name="index">Index at which to remove value (null will remove value at end).</param>
        /// <exception cref="RemovalOfLastLineException">Thrown when trying to remove last line of translation project.</exception>
        public void RemoveLine(int? index)
        {
            if (MaxIndex == 0)
                throw ExceptionHelper.NewRemovalOfLastLineException();
            int insertionIndex = index ?? MaxIndex;

            RawLines.RemoveAt(insertionIndex);
            TranslatedLines.RemoveAt(insertionIndex);
            CompletedLines.RemoveAt(insertionIndex);
            MarkedLines.RemoveAt(insertionIndex);
        }

        /// <summary>
        /// Gets JSON string of the project data used to save project.
        /// </summary>
        /// <returns>JSON string of project data.</returns>
        public string GetProjectSaveString()
        {
            return Data.GetSaveString();
        }

        /// <summary>
        /// Initiates default translation mode.
        /// </summary>
        public void StartDefaultMode()
        {
            DefaultTranslationMode = true;
            CurrentIndex = 0;
        }
        /// <summary>
        /// Initiates marked only translation mode. (Shows all marked lines only).
        /// </summary>
        /// <param name="subRepo">Object that implements Sub Translation Data Repository Interface.</param>
        /// <returns>Number of lines that are marked.</returns>
        public int StartMarkedOnlyMode(ISubTranslationDataRepository subRepo)
        {
            SubData = subRepo.GetSubData(MarkedLines);
            DefaultTranslationMode = false;
            CurrentIndex = 0;
            return SubData.NumberOfLines;
        }
        /// <summary>
        /// Initates incomplete only translation mode. (Shows all incomplete lines only.)
        /// </summary>
        /// <param name="subRepo">Object that implements Sub Translation Data Repository Interface.</param>
        /// <returns>Number of lines that are incomplete.</returns>
        public int StartIncompleteOnlyMode(ISubTranslationDataRepository subRepo)
        {
            var incompleteLines = new List<bool>();
            foreach (var line in CompletedLines)
            {
                incompleteLines.Add(!line);
            }

            SubData = subRepo.GetSubData(incompleteLines);
            DefaultTranslationMode = false;
            CurrentIndex = 0;
            return SubData.NumberOfLines;
        }

        /// <summary>
        /// Initiates complete only translation mode. (Shows all complete lines only.)
        /// </summary>
        /// <param name="subRepo">Object that implements Sub Translation Data Repository Interface.</param>
        /// <returns>Number of lines that are complete.</returns>
        public int StartCompleteOnlyMode(ISubTranslationDataRepository subRepo)
        {
            SubData = subRepo.GetSubData(CompletedLines);
            DefaultTranslationMode = false;
            CurrentIndex = 0;
            return SubData.NumberOfLines;
        }

        /// <summary>
        /// Returns the project data used in the translation project.
        /// </summary>
        /// <returns>Object that implements Project Data Interface.</returns>

        public IProjectData GetProjectData()
        {
            return Data;
        }
        #endregion
    }
}
