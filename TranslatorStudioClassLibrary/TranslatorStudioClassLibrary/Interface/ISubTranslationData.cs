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
        ///     returns type List<int>.
        /// </summary>
        List<int> IndexReference { get; set; }

        /// <summary>
        /// Current Reference:
        ///     property that contains the current reference.
        ///     returns type int.
        /// </summary>
        int CurrentReference { get; }

        /// <summary>
        /// Current Index:
        ///     property that contains the current index in the translation mode.
        ///     returns type int.
        /// </summary>
        int CurrentIndex { get; set; }
        /// <summary>
        /// Max Index:
        ///     property that contains the max index in the translation.
        ///     returns type int.
        /// </summary>
        int MaxIndex { get; }

        /// <summary>
        /// Number Of Lines:
        ///     property that contains the number of lines in the translation.
        ///     returns type int.
        /// </summary>
        int NumberOfLines { get; }
        #endregion
    }
}
