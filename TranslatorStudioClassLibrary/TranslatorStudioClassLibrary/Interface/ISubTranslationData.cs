using System.Collections.Generic;

namespace TranslatorStudioClassLibrary.Interface
{
    /// <summary>
    /// Interface that defines the public properties and methods required to store Sub Translation Data.
    /// </summary>
    public interface ISubTranslationData
    {
        #region Property
        /// <summary>
        /// Contains the index references of the lines that meet the criteria.
        /// </summary>
        List<int> IndexReference { get; set; }

        /// <summary>
        /// Contains the current line reference.
        /// </summary>
        int CurrentReference { get; }

        /// <summary>
        /// Contains the current index reference used to access the line in the main translation project.
        /// </summary>
        int CurrentIndex { get; set; }
        /// <summary>
        /// Contains the max index in the sub translation project.
        /// </summary>
        int MaxIndex { get; }

        /// <summary>
        /// Contains the number of lines in the sub translation project.
        /// </summary>
        int NumberOfLines { get; }
        #endregion
    }
}
