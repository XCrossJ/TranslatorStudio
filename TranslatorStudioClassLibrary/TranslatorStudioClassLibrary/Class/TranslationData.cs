using System.Collections.Generic;
using System.Linq;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudioClassLibrary.Class
{
    public class TranslationData : ITranslationData
    {
        #region Properties

        #region Project Data
        private IProjectData Data { get; set; }
        private ISubTranslationData SubData { get; set; }
        public bool DefaultTranslationMode { get; set; } = true;

        public string ProjectName
        {
            get => Data.ProjectName;
            set => Data.ProjectName = value;
        }
        public List<string> RawLines
        {
            get => Data.RawLines;
            set => Data.RawLines = value;
        }
        public string[] TranslatedLines
        {
            get => Data.TranslatedLines;
            set => Data.TranslatedLines = value;
        }
        public bool[] CompletedLines
        {
            get => Data.CompletedLines;
            set => Data.CompletedLines = value;
        }
        public bool[] MarkedLines
        {
            get => Data.MarkedLines;
            set => Data.MarkedLines = value;
        }
        #endregion

        #region Project Controls
        
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

        private int _index = 0;
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
        public int MaxIndex => DefaultTranslationMode ? RawLines.Count - 1 : SubData.MaxIndex;

        public int NumberOfLines => RawLines.Count;
        public int NumberOfCompletedLines => CompletedLines.Where(c => c).Count();

        #endregion

        #endregion


        #region Constructors
        public TranslationData()
        {

        }

        public TranslationData(IProjectData data)
        {
            Data = data;
            CurrentIndex = 0;
        }
        #endregion


        #region Methods
        public void IncrementCurrentLine()
        {
            if (CurrentIndex != MaxIndex)
                CurrentIndex++;
        }

        public void DecrementCurrentLine()
        {
            if (CurrentIndex != 0)
                CurrentIndex--;
        }

        public string GetSaveString()
        {
            return Data.ToJSONString();
        }

        public int StartMarkedOnlyMode()
        {
            SubData = new SubTranslationDataRepository().GetSubData(MarkedLines);
            return SubData.NumberOfLines;
        }

        public int StartIncompleteOnlyMode()
        {
            var incompleteLines = new bool[NumberOfLines];
            CompletedLines.CopyTo(incompleteLines, 0);
            for (int i = 0; i < incompleteLines.Length; i++)
            {
                incompleteLines[i] = !incompleteLines[i];
            }
            SubData = new SubTranslationDataRepository().GetSubData(incompleteLines);
            return SubData.NumberOfLines;
        }

        public int StartCompleteOnlyMode()
        {
            SubData = new SubTranslationDataRepository().GetSubData(CompletedLines);
            return SubData.NumberOfLines;
        }

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
