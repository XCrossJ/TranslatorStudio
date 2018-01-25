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
        /// Index Reference:
        ///     property that contains the index reference.
        /// </summary>
        List<int> IndexReference { get; set; }

        /// <summary>
        /// Current Reference:
        ///     property that contains the current reference.
        /// </summary>
        int CurrentReference { get; }

        /// <summary>
        /// Current Index:
        ///     property that contains the current index in the translation mode.
        /// </summary>
        int CurrentIndex { get; set; }
        /// <summary>
        /// Max Index:
        ///     property that contains the max index in the translation.
        /// </summary>
        int MaxIndex { get; }

        /// <summary>
        /// Number Of Lines:
        ///     property that contains the number of lines in the translation.
        /// </summary>
        int NumberOfLines { get; }
        #endregion
    }
}
