namespace TranslatorStudioClassLibrary.Class
{
    using System.Collections.Generic;
    using System.Linq;
    using Exception;
    using Interface;
    using Utilities;

    /// <summary>
    /// Class that contains the properties and method relevant for Translation Data.
    /// Implements Translation Data Interface.
    /// </summary>
    public class TranslationData : ITranslationData //, IEquatable<TranslationData>
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
            set => _data.ProjectName = SetPropertyValue(value);
        }
        /// <summary>
        /// The url to the project source.
        /// </summary>
        public string SourceLink
        {
            get => _data.ProjectName;
            set => _data.ProjectName = SetPropertyValue(value);
        }
        /// <summary>
        /// Contains all lines in the translation.
        /// </summary>
        public IList<IProjectLine> ProjectLines { get => _data.ProjectLines; set => _data.ProjectLines = value; }

        #endregion

        #region Project Controls

        /// <summary>
        /// The current project line in the translation.
        /// </summary>
        public IProjectLine CurrentLine
        {
            get
            {
                var index = DefaultTranslationMode ?
                   (AutoTranslationMode ? _autoData.CurrentReference : CurrentIndex)
                   : _subData.CurrentReference;

                return ProjectLines[index];
            }
            set
            {
                var index = DefaultTranslationMode ?
                    (AutoTranslationMode ? _autoData.CurrentReference : CurrentIndex)
                    : _subData.CurrentReference;

                ProjectLines[index] = SetPropertyValue(value);
            }
        }

        /// <summary>
        /// The current raw line in the translation.
        /// </summary>
        public string CurrentRaw { get => CurrentLine.Raw; set => CurrentLine.Raw = SetPropertyValue(value); }
        /// <summary>
        /// The current translated line in the translation.
        /// </summary>
        public string CurrentTranslation { get => CurrentLine.Translation; set => CurrentLine.Translation = SetPropertyValue(value); }
        /// <summary>
        /// The comment of the current line in the translation.
        /// </summary>
        public string CurrentComment { get => CurrentLine.Comment; set => CurrentLine.Comment = SetPropertyValue(value); }
        /// <summary>
        /// The completion status of the current line in the translation.
        /// </summary>
        public bool CurrentCompletion { get => CurrentLine.Completed; set => CurrentLine.Completed = SetPropertyValue(value); }
        /// <summary>
        /// The marked status of the current line in the translation.
        /// </summary>
        public bool CurrentMarked { get => CurrentLine.Marked; set => CurrentLine.Marked = SetPropertyValue(value); }

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
                    return AutoTranslationMode ? _autoData.MaxIndex : ProjectLines.Count - 1;
                else
                    return _subData.MaxIndex;
            }
        }

        /// <summary>
        /// The number of lines in the translation.
        /// </summary>
        public int NumberOfLines => AutoTranslationMode ? _autoData.NumberOfLines : ProjectLines.Count;
        /// <summary>
        ///The number of completed lines in the translation.
        /// </summary>
        public int NumberOfCompletedLines
        {
            get
            {
                return ProjectLines
                    .Where(x => x.Completed == true && (AutoTranslationMode ? x.Raw.Any() : true))
                    .Select(x => x).ToList().Count();
            }
        }

        #endregion

        #endregion


        #region Property Changed
        
        private T SetPropertyValue<T>(T value)
        {
            DataChanged = true;
            return value;
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
                if (_autoMode)
                {
                    var testIndex = _autoData.CurrentReference != 0 ? _autoData.CurrentReference - 1 : 0;
                    if (string.IsNullOrWhiteSpace(ProjectLines[testIndex].Raw))
                        ProjectLines[testIndex].Completed = true;
                }
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
                if (_autoMode)
                {
                    var testIndex = _autoData.CurrentReference != 0 ? _autoData.CurrentReference - 1 : 0;
                    if (string.IsNullOrWhiteSpace(ProjectLines[testIndex].Raw))
                        ProjectLines[testIndex].Completed = true;
                }
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

            var newLine = new ProjectLine
            {
                Raw = rawValue,
                Translation = "",
                Completed = false,
                Marked = false
            };

            ProjectLines.Insert(insertionIndex, newLine);
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

            ProjectLines.RemoveAt(insertionIndex);
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
        /// Toggles auto translation mode. (Removes empty lines.)
        /// </summary>
        /// <param name="autoOn">Whether or not auto mode should be turned on or not.</param>
        /// <returns>Number of lines that are not empty.</returns>
        public int ToggleAutoMode(bool autoOn)
        {
            if (autoOn)
            {
                var rawLines = ProjectLines.Select(x => x.Raw).ToList();
                var nonEmptyRaw = rawLines.Select(x => x.IsNotEmpty()).ToList();
                _autoData = _subTranslationDataFactory.GetSubData(nonEmptyRaw);

                _autoMode = true;
                CurrentIndex = 0;
            }
            else
                _autoMode = false;

            return NumberOfLines;
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
        /// <returns>Number of lines that are marked.</returns>
        public int StartMarkedOnlyMode()
        {
            List<bool> conditionList;
            var rawLines = ProjectLines.Select(x => x.Raw).ToList();
            var markedLines = ProjectLines.Select(x => x.Marked).ToList();
            if (_autoMode)
                conditionList = rawLines.Select((v, i) => new { v, i }).Select(x => markedLines[x.i] && x.v.IsNotEmpty()).ToList();
            else
                conditionList = markedLines;

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
            var rawLines = ProjectLines.Select(x => x.Raw).ToList();
            var completedLines = ProjectLines.Select(x => x.Completed).ToList();
            if (_autoMode)
                conditionList = rawLines.Select((v, i) => new { v, i }).Select(x => !completedLines[x.i] && x.v.IsNotEmpty()).ToList();
            else
                conditionList = completedLines.Select(x => !x).ToList();

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
            var rawLines = ProjectLines.Select(x => x.Raw).ToList();
            var completedLines = ProjectLines.Select(x => x.Completed).ToList();
            if (_autoMode)
                conditionList = rawLines.Select((v, i) => new { v, i }).Select(x => completedLines[x.i] && x.v.IsNotEmpty()).ToList();
            else
                conditionList = completedLines;

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

        //public bool Equals(TranslationData other)
        //{
        //    return other != null &&
        //           EqualityComparer<ISubTranslationDataFactory>.Default.Equals(_subTranslationDataFactory, other._subTranslationDataFactory) &&
        //           EqualityComparer<IProjectData>.Default.Equals(_data, other._data) &&
        //           EqualityComparer<ISubTranslationData>.Default.Equals(_subData, other._subData) &&
        //           EqualityComparer<ISubTranslationData>.Default.Equals(_autoData, other._autoData) &&
        //           _autoMode == other._autoMode &&
        //           DefaultTranslationMode == other.DefaultTranslationMode &&
        //           AutoTranslationMode == other.AutoTranslationMode &&
        //           DataChanged == other.DataChanged &&
        //           ProjectName == other.ProjectName &&
        //           EqualityComparer<List<IProjectLine>>.Default.Equals(ProjectLines, other.ProjectLines) &&
        //           EqualityComparer<IProjectLine>.Default.Equals(CurrentLine, other.CurrentLine) &&
        //           CurrentRaw == other.CurrentRaw &&
        //           CurrentTranslation == other.CurrentTranslation &&
        //           CurrentCompletion == other.CurrentCompletion &&
        //           CurrentMarked == other.CurrentMarked &&
        //           _index == other._index &&
        //           CurrentIndex == other.CurrentIndex &&
        //           MaxIndex == other.MaxIndex &&
        //           NumberOfLines == other.NumberOfLines &&
        //           NumberOfCompletedLines == other.NumberOfCompletedLines;
        //}

        //public override int GetHashCode()
        //{
        //    var hashCode = 471267684;
        //    hashCode = hashCode * -1521134295 + EqualityComparer<ISubTranslationDataFactory>.Default.GetHashCode(_subTranslationDataFactory);
        //    hashCode = hashCode * -1521134295 + EqualityComparer<IProjectData>.Default.GetHashCode(_data);
        //    hashCode = hashCode * -1521134295 + EqualityComparer<ISubTranslationData>.Default.GetHashCode(_subData);
        //    hashCode = hashCode * -1521134295 + EqualityComparer<ISubTranslationData>.Default.GetHashCode(_autoData);
        //    hashCode = hashCode * -1521134295 + _autoMode.GetHashCode();
        //    hashCode = hashCode * -1521134295 + DefaultTranslationMode.GetHashCode();
        //    hashCode = hashCode * -1521134295 + AutoTranslationMode.GetHashCode();
        //    hashCode = hashCode * -1521134295 + DataChanged.GetHashCode();
        //    hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProjectName);
        //    hashCode = hashCode * -1521134295 + EqualityComparer<List<IProjectLine>>.Default.GetHashCode(ProjectLines);
        //    hashCode = hashCode * -1521134295 + EqualityComparer<IProjectLine>.Default.GetHashCode(CurrentLine);
        //    hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CurrentRaw);
        //    hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CurrentTranslation);
        //    hashCode = hashCode * -1521134295 + CurrentCompletion.GetHashCode();
        //    hashCode = hashCode * -1521134295 + CurrentMarked.GetHashCode();
        //    hashCode = hashCode * -1521134295 + _index.GetHashCode();
        //    hashCode = hashCode * -1521134295 + CurrentIndex.GetHashCode();
        //    hashCode = hashCode * -1521134295 + MaxIndex.GetHashCode();
        //    hashCode = hashCode * -1521134295 + NumberOfLines.GetHashCode();
        //    hashCode = hashCode * -1521134295 + NumberOfCompletedLines.GetHashCode();
        //    return hashCode;
        //}
    }
}
