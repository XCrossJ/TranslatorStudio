using System.Collections.Generic;
using System.ComponentModel;
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
        /// Private property that constructs sub translation data;
        /// </summary>
        private ISubTranslationDataFactory _subTranslationDataFactory;

        /// <summary>
        /// Private property that contains Project Data.
        /// </summary>
        private IProjectData _data { get; set; }
        /// <summary>
        /// Private property that contains Sub Translation Data.
        /// </summary>
        private ISubTranslationData _subData { get; set; }
        /// <summary>
        /// Private property that contains Auto Translation Data.
        /// </summary>
        private ISubTranslationData _autoData { get; set; }

        /// <summary>
        /// Private property that contains Auto Translation Mode flag.
        /// </summary>
        private bool _autoMode { get; set; } = false;
        /// <summary>
        /// Determines whether Default Translation Mode is turned on or not.
        /// </summary>
        public bool DefaultTranslationMode { get; set; } = true;
        /// <summary>
        /// Determines whether Auto Translation Mode is turned on or not.
        /// </summary>
        public bool AutoTranslationMode { get => _autoMode; }
        /// <summary>
        /// Determines whether changed have been made to Translation Data.
        /// </summary>
        public bool DataChanged { get; set; }

        /// <summary>
        /// The name of the project.
        /// </summary>
        public string ProjectName
        {
            get => _data.ProjectName;
            set => SetPropertyValue(_data.ProjectName, value);
        }
        /// <summary>
        /// Contains all of the raw lines in the translation.
        /// </summary>
        public List<string> RawLines
        {
            get => _data.RawLines;
            set => SetPropertyValue(_data.RawLines, value);
        }
        /// <summary>
        /// Contains all of the translated lines in the translation.
        /// </summary>
        public List<string> TranslatedLines
        {
            get => _data.TranslatedLines;
            set => SetPropertyValue(_data.TranslatedLines, value);
        }
        /// <summary>
        /// Contains the completion status of each line in the translation.
        /// </summary>
        public List<bool> CompletedLines
        {
            get => _data.CompletedLines;
            set => SetPropertyValue(_data.CompletedLines, value);
        }
        /// <summary>
        /// Contains the marked status of each line in the translation.
        /// </summary>
        public List<bool> MarkedLines
        {
            get => _data.MarkedLines;
            set => SetPropertyValue(_data.MarkedLines, value);
        }
        #endregion

        #region Project Controls

        /// <summary>
        /// The current raw line in the translation.
        /// </summary>
        public string CurrentRaw
        {
            get
            {
                var index = DefaultTranslationMode ?
                    (AutoTranslationMode ? _autoData.CurrentReference : CurrentIndex)
                    : _subData.CurrentReference;

                return RawLines[index];
            }
            set
            {
                var index = DefaultTranslationMode ?
                    (AutoTranslationMode ? _autoData.CurrentReference : CurrentIndex)
                    : _subData.CurrentReference;

                SetPropertyValue(RawLines[index], value);
            }
        }
        /// <summary>
        /// The current translated line in the translation.
        /// </summary>
        public string CurrentTranslation
        {
            get
            {
                var index = DefaultTranslationMode ?
                    (AutoTranslationMode ? _autoData.CurrentReference : CurrentIndex)
                    : _subData.CurrentReference;

                return TranslatedLines[index];
            }
            set
            {
                var index = DefaultTranslationMode ?
                    (AutoTranslationMode ? _autoData.CurrentReference : CurrentIndex)
                    : _subData.CurrentReference;

                SetPropertyValue(TranslatedLines[index], value);
            }
        }
        /// <summary>
        /// The completion status of the current line in the translation.
        /// </summary>
        public bool CurrentCompletion
        {
            get
            {
                var index = DefaultTranslationMode ?
                    (AutoTranslationMode ? _autoData.CurrentReference : CurrentIndex)
                    : _subData.CurrentReference;

                return CompletedLines[index];
            }
            set
            {
                var index = DefaultTranslationMode ?
                    (AutoTranslationMode ? _autoData.CurrentReference : CurrentIndex)
                    : _subData.CurrentReference;

                SetPropertyValue(CompletedLines[index], value);
            }
        }
        /// <summary>
        /// The marked status of the current line in the translation.
        /// </summary>
        public bool CurrentMarked
        {
            get
            {
                var index = DefaultTranslationMode ?
                    (AutoTranslationMode ? _autoData.CurrentReference : CurrentIndex)
                    : _subData.CurrentReference;

                return MarkedLines[index];
            }
            set
            {
                var index = DefaultTranslationMode ?
                    (AutoTranslationMode ? _autoData.CurrentReference : CurrentIndex)
                    : _subData.CurrentReference;

                SetPropertyValue(MarkedLines[index], value);
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
            get
            {
                if (DefaultTranslationMode)
                    return AutoTranslationMode ? _autoData.CurrentIndex: _index;
                else
                    return _subData.CurrentIndex;
            }
            set
            {
                if (DefaultTranslationMode)
                    if (AutoTranslationMode)
                        _autoData.CurrentIndex = value;
                    else
                        _index = value;
                else
                    _subData.CurrentIndex = value;

            }
        }
        /// <summary>
        /// The max index in the translation.
        /// </summary>
        public int MaxIndex
        {
            get
            {
                if (DefaultTranslationMode)
                    return AutoTranslationMode ? _autoData.MaxIndex : RawLines.Count - 1;
                else
                    return _subData.MaxIndex;
            }
        }

        /// <summary>
        /// The number of lines in the translation.
        /// </summary>
        public int NumberOfLines => AutoTranslationMode ? _autoData.NumberOfLines : RawLines.Count;
        /// <summary>
        ///The number of completed lines in the translation.
        /// </summary>
        public int NumberOfCompletedLines
        {
            get
            {
                return CompletedLines.Select((v, i) => new { v, i })
                        .Where(x => x.v == true && (AutoTranslationMode ? RawLines[x.i].Any() : true))
                        .Select(x => x.i).ToList().Count();
            }
        }
        #endregion

        #endregion

        #region Property Changed
        
        private void SetPropertyValue<T>(T property, T value)
        {
            property = value;
            DataChanged = true;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates empty Translation Data.
        /// </summary>
        /// <param name="subTranslationDataFactory">Sub Translation Data Factory used to construct Sub Translation Data.</param>
        public TranslationData(ISubTranslationDataFactory subTranslationDataFactory)
        {
            _subTranslationDataFactory = subTranslationDataFactory ?? throw new System.ArgumentNullException(nameof(subTranslationDataFactory));
        }

        /// <summary>
        /// Creates Translation Data based on passed Project Data.
        /// </summary>
        /// <param name="projectData">Object that implements Project Data Interface.</param>
        /// <param name="subTranslationDataFactory"></param>
        public TranslationData(IProjectData projectData, ISubTranslationDataFactory subTranslationDataFactory) : this(subTranslationDataFactory)
        {
            _data = projectData ?? throw new System.ArgumentNullException(nameof(projectData));
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
            {
                CurrentIndex++;
                var testIndex = _autoData != null ? _autoData.CurrentReference - 1 : 0;
                if (_autoMode && !RawLines[testIndex].Any())
                    CompletedLines[testIndex] = true;
            }
        }
        /// <summary>
        /// Decrements the current index.
        /// </summary>
        public void DecrementCurrentLine()
        {
            if (CurrentIndex != 0)
            {
                CurrentIndex--;
                var testIndex = _autoData != null ? _autoData.CurrentReference - 1 : 0;
                if (_autoMode && !RawLines[testIndex].Any())
                    CompletedLines[testIndex] = true;
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
                throw ExceptionHelper.NewRemovalOfLastLineException;
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
            return _data.GetSaveString();
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
        /// Initiates auto translation mode. (Removes empty lines.)
        /// </summary>
        /// <returns>Number of lines that are not empty.</returns>
        public int StartAutoMode()
        {
            _autoMode = true;
            var nonEmptyRaw = RawLines.Where(x => x.Any()).Select(x => true);

            _autoData = _subTranslationDataFactory.GetSubData(nonEmptyRaw.ToList());
            CurrentIndex = 0;
            return _autoData.NumberOfLines;
        }
        /// <summary>
        /// Initiates marked only translation mode. (Shows all marked lines only).
        /// </summary>
        /// <returns>Number of lines that are marked.</returns>
        public int StartMarkedOnlyMode()
        {
            List<bool> conditionList;
            if (_autoMode)
                conditionList = _autoData.IndexReference.Where(x => MarkedLines[x]).Select(x => true).ToList();
            else
                conditionList = MarkedLines;

            _subData = _subTranslationDataFactory.GetSubData(conditionList);
            DefaultTranslationMode = false;
            CurrentIndex = 0;
            return _subData.NumberOfLines;
        }
        /// <summary>
        /// Initates incomplete only translation mode. (Shows all incomplete lines only.)
        /// </summary>
        /// <returns>Number of lines that are incomplete.</returns>
        public int StartIncompleteOnlyMode()
        {
            List<bool> conditionList;
            if (_autoMode)
                conditionList = _autoData.IndexReference.Where(x => !CompletedLines[x]).Select(x => true).ToList();
            else
                conditionList = CompletedLines.Select(x => !x).ToList();

            _subData = _subTranslationDataFactory.GetSubData(conditionList);
            DefaultTranslationMode = false;
            CurrentIndex = 0;
            return _subData.NumberOfLines;
        }
        /// <summary>
        /// Initiates complete only translation mode. (Shows all complete lines only.)
        /// </summary>
        /// <returns>Number of lines that are complete.</returns>
        public int StartCompleteOnlyMode()
        {
            List<bool> conditionList;
            if (_autoMode)
                conditionList = _autoData.IndexReference.Where(x => CompletedLines[x]).Select(x => true).ToList();
            else
                conditionList = CompletedLines;

            _subData = _subTranslationDataFactory.GetSubData(conditionList);
            DefaultTranslationMode = false;
            CurrentIndex = 0;
            return _subData.NumberOfLines;
        }

        /// <summary>
        /// Returns the project data used in the translation project.
        /// </summary>
        /// <returns>Object that implements Project Data Interface.</returns>
        public IProjectData GetProjectData()
        {
            return _data;
        }
        #endregion
    }
}
