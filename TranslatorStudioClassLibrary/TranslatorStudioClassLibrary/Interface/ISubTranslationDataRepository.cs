using System.Collections.Generic;

namespace TranslatorStudioClassLibrary.Interface
{
    /// <summary>
    /// Interface that defines the public properties and methods required to store Sub Translation Data Repository.
    /// </summary>
    public interface ISubTranslationDataRepository
    {
        /// <summary>
        /// Creates sub translation data based on condition list.
        /// </summary>
        /// <param name="conditionList">The condition list used to construct the sub data.</param>
        /// <returns>Object that implements Sub Translation Data Interface.</returns>
        ISubTranslationData GetSubData(List<bool> conditionList);
    }
}
