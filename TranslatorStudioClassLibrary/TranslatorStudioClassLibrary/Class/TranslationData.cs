using System.Collections.Generic;
using System.Linq;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;
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
        /// Data:
        ///     private property that contains Project Data.
        /// </summary>
        private IProjectData Data { get; set; }
        /// <summary>
        /// Sub Data:
        ///     private property that contains Sub Translation Data.
        /// </summary>
        private ISubTranslationData SubData { get; set; }
        /// <summary>
        /// DefaultTranslationMode:
        ///     property that determines whether Default Translation Mode is turned on or not.
        ///     returns type bool.
        /// </summary>
        public bool DefaultTranslationMode { get; set; } = true;

        /// <summary>
        /// Project Name:
        ///     property that contains the name of the project.
        ///     returns type string.
        /// </summary>
        public string ProjectName
        {
            get => Data.ProjectName;
            set => Data.ProjectName = value;
        }
        /// <summary>
        /// Raw Lines:
        ///     property that contains all of the raw lines in the translation.
        ///     returns type List<string>.
        /// </summary>
        public List<string> RawLines
        {
            get => Data.RawLines;
            set => Data.RawLines = value;
        }
        /// <summary>
        /// Translated Lines:
        ///     property that contains all of the translated lines in the translation.
        ///     returns type List<string>.
        /// </summary>
        public List<string> TranslatedLines
        {
            get => Data.TranslatedLines;
            set => Data.TranslatedLines = value;
        }
        /// <summary>
        /// Completed Lines:
        ///     property that contains the completion status of each line in the translation.
        ///     returns type List<bool>.
        /// </summary>
        public List<bool> CompletedLines
        {
            get => Data.CompletedLines;
            set => Data.CompletedLines = value;
        }
        /// <summary>
        /// Marked Lines:
        ///     property that contains the marked status of each line in the translation.
        ///     returns type List<bool>.
        /// </summary>
        public List<bool> MarkedLines
        {
            get => Data.MarkedLines;
            set => Data.MarkedLines = value;
        }
        #endregion

        #region Project Controls
        /// <summary>
        /// Current Raw:
        ///     property that contains the current raw line in the translation.
        ///     returns type string.
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
        /// Current Translation:
        ///     property that contains the current translated line in the translation.
        ///     returns type string.
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
        /// Current Completion:
        ///     property that contains the completion status of the current line in the translation.
        ///     returns type bool.
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
        /// Current Marked:
        ///     property that contains the marked status of the current line in the translation.
        ///     returns type bool.
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
        /// _index:
        ///     private property that contains the current index.
        ///     returns type int.
        /// </summary>
        private int _index = 0;
        /// <summary>
        /// Current Index:
        ///     property that contains the current index in the translation.
        ///     returns type int.
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
        /// Max Index:
        ///     property that contains the max index in the translation.
        ///     returns type int.
        /// </summary>
        public int MaxIndex => DefaultTranslationMode ? RawLines.Count - 1 : SubData.MaxIndex;

        /// <summary>
        /// Number Of Lines:
        ///     property that contains the number of lines in the translation.
        ///     returns type int.
        /// </summary>
        public int NumberOfLines => RawLines.Count;
        /// <summary>
        /// Numbder Of Completed Lines:
        ///     property that contains max number of lines in the translations.
        ///     returns type int.
        /// </summary>
        public int NumberOfCompletedLines => CompletedLines.Where(c => c).Count();
        #endregion

        #endregion


        #region Constructors
        /// <summary>
        /// Translation Data Default Constructor:
        ///     Creates empty Translation Data.
        /// </summary>
        public TranslationData()
        {

        }

        /// <summary>
        /// Translation Data Project Data Constructor:
        ///     Creates Translation Data based on passed Project Data
        /// </summary>
        /// <param name="data">IProjectData: object that implements Project Data Interface.</param>
        public TranslationData(IProjectData data)
        {
            Data = data;
            CurrentIndex = 0;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Increment Current Line:
        ///     increments the current index.
        /// </summary>
        public void IncrementCurrentLine()
        {
            if (CurrentIndex != MaxIndex)
                CurrentIndex++;
        }

        /// <summary>
        /// Decrement Current Line:
        ///     decrement the current index.
        /// </summary>
        public void DecrementCurrentLine()
        {
            if (CurrentIndex != 0)
                CurrentIndex--;
        }

        /// <summary>
        /// Get Save String:
        ///     gets the save string of the project data.
        /// </summary>
        /// <returns>string: JSON string of project data.</returns>
        public string GetSaveString()
        {
            return Data.ToJSONString();
        }

        /// <summary>
        /// Start Default Mode:
        ///     initiates default translation mode.
        /// </summary>
        public void StartDefaultMode()
        {
            DefaultTranslationMode = true;
            CurrentIndex = 0;
        }

        /// <summary>
        /// Start Marked Only Mode:
        ///     initiates marked only translation mode.
        /// </summary>
        /// <returns>int: returns number of lines.</returns>
        public int StartMarkedOnlyMode()
        {
            SubData = new SubTranslationDataRepository().GetSubData(MarkedLines);
            DefaultTranslationMode = false;
            CurrentIndex = 0;
            return SubData.NumberOfLines;
        }

        /// <summary>
        /// Start Incomplete Only Mode:
        ///     initates incomplete only translation mode.
        /// </summary>
        /// <returns>int: returns number of lines.</returns>
        public int StartIncompleteOnlyMode()
        {
            var incompleteLines = new List<bool>();
            foreach (var line in CompletedLines)
            {
                incompleteLines.Add(!line);
            }

            SubData = new SubTranslationDataRepository().GetSubData(incompleteLines);
            DefaultTranslationMode = false;
            CurrentIndex = 0;
            return SubData.NumberOfLines;
        }

        /// <summary>
        /// Start Complete Only Mode:
        ///     initiates complete only translation mode.
        /// </summary>
        /// <returns>int: returns number of lines.</returns>
        public int StartCompleteOnlyMode()
        {
            SubData = new SubTranslationDataRepository().GetSubData(CompletedLines);
            DefaultTranslationMode = false;
            CurrentIndex = 0;
            return SubData.NumberOfLines;
        }

        /// <summary>
        /// Get Project Data:
        ///     property that returns project data for translation.
        /// </summary>
        /// <returns>IProjectData: object that implements Project Data Interface.</returns>
        public IProjectData GetProjectData()
        {
            return Data;
        }
        #endregion

        public override bool Equals(object obj)
        {
            var toCompareWith = obj as TranslationData;
            if (toCompareWith == null)
            {
                return false;
            }
            else
            {
                if (ProjectName != toCompareWith.ProjectName)
                    return false;

                if (DefaultTranslationMode != toCompareWith.DefaultTranslationMode)
                    return false;

                if (CurrentIndex != toCompareWith.CurrentIndex)
                    return false;

                if (CurrentCompletion != toCompareWith.CurrentCompletion)
                    return false;

                if (CurrentMarked != toCompareWith.CurrentMarked)
                    return false;

                if (CurrentRaw != toCompareWith.CurrentRaw)
                    return false;

                if (CurrentTranslation != toCompareWith.CurrentTranslation)
                    return false;

                if (MaxIndex != toCompareWith.MaxIndex)
                    return false;

                if (NumberOfLines != toCompareWith.NumberOfLines)
                    return false;

                if (NumberOfCompletedLines != toCompareWith.NumberOfCompletedLines)
                    return false;

                return true;
            }
        }
    }
}
