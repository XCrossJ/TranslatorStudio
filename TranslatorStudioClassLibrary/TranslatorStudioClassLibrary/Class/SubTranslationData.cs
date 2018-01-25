using System.Collections.Generic;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudioClassLibrary.Class
{
    /// <summary>
    /// Class that contains the properties and method relevant for Sub Translation Data.
    /// Implements Sub Translation Data Interface.
    /// </summary>
    public class SubTranslationData : ISubTranslationData
    {
        #region Properties
        /// <summary>
        /// Index Reference:
        ///     property that contains the index reference.
        /// </summary>
        public List<int> IndexReference { get; set; }

        /// <summary>
        /// Current Reference:
        ///     property that contains the current reference.
        /// </summary>
        public int CurrentReference => IndexReference[CurrentIndex];

        /// <summary>
        /// Current Index:
        ///     property that contains the current index in the translation mode.
        /// </summary>
        public int CurrentIndex { get; set; }
        /// <summary>
        /// Max Index:
        ///     property that contains the max index in the translation.
        /// </summary>
        public int MaxIndex => IndexReference.Count - 1;

        /// <summary>
        /// Number Of Lines:
        ///     property that contains the number of lines in the translation.
        /// </summary>
        public int NumberOfLines => IndexReference.Count;
        #endregion

        #region Constructors
        /// <summary>
        /// Sub Translation Data Default Constructor:
        ///     Creates empty Sub Translation Data.
        /// </summary>
        public SubTranslationData()
        {
            IndexReference = new List<int>();
        }

        /// <summary>
        /// Sub Translation Data Condition List Constructor:
        ///     Creates Sub Translation Data based on condition list.
        /// </summary>
        /// <param name="conditionList"></param>
        public SubTranslationData(bool[] conditionList)
        {
            IndexReference = new List<int>();
            for (int i = 0; i < conditionList.Length; i++)
            {
                if (conditionList[i])
                {
                    IndexReference.Add(i);
                }
            }
        }
        #endregion
    }
}
