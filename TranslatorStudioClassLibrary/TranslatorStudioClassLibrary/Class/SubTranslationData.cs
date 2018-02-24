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
        /// Contains the index references of the lines that meet the criteria.
        /// </summary>
        public List<int> IndexReference { get; set; }

        /// <summary>
        /// Contains the current line reference.
        /// </summary>
        public int CurrentReference => IndexReference[CurrentIndex];

        /// <summary>
        /// Contains the current index reference used to access the line in the main translation project.
        /// </summary>
        public int CurrentIndex { get; set; }
        /// <summary>
        /// Contains the max index in the sub translation project.
        /// </summary>
        public int MaxIndex => IndexReference.Count - 1;

        /// <summary>
        /// Contains the number of lines in the sub translation project.
        /// </summary>
        public int NumberOfLines => IndexReference.Count;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates empty Sub Translation Data.
        /// </summary>
        public SubTranslationData()
        {
            
        }
        #endregion
    }
}
