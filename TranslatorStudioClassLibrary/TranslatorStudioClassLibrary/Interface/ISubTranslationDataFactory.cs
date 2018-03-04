using System.Collections.Generic;

namespace TranslatorStudioClassLibrary.Interface
{
    /// <summary>
    /// Interface that defines the public properties and methods required to construct Sub Translation Data.
    /// </summary>
    public interface ISubTranslationDataFactory
    {
        /// <summary>
        /// Creates sub translation data based on condition list.
        /// </summary>
        /// <param name="conditionList">The condition list used to construct the sub data.</param>
        /// <returns>Object that implements Sub Translation Data Interface.</returns>
        ISubTranslationData GetSubData(List<bool> conditionList);
    }
}
