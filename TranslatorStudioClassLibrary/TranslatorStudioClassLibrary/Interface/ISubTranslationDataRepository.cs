using System.Collections.Generic;

namespace TranslatorStudioClassLibrary.Interface
{
    /// <summary>
    /// Interface that defines the public properties and methods required to store Sub Translation Data Repository.
    /// </summary>
    public interface ISubTranslationDataRepository
    {
        /// <summary>
        /// Get Sub Data:
        ///     creates sub translation data based on condition list.
        /// </summary>
        /// <param name="conditionList">List<bool>: the condition list used to construct the sub data.</param>
        /// <returns>ISubTranslationData: object that implements Sub Translation Data Interface.</returns>
        ISubTranslationData GetSubData(List<bool> conditionList);
    }
}
