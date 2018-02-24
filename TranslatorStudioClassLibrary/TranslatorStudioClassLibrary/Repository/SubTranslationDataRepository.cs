using System.Collections.Generic;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudioClassLibrary.Repository
{
    /// <summary>
    /// Class that contains the properties and method relevant for Sub Translation Data Repository.
    /// Implements Sub Translation Data Repository Interface.
    /// </summary>
    public class SubTranslationDataRepository : ISubTranslationDataRepository
    {
        /// <summary>
        /// Creates sub translation data based on condition list.
        /// </summary>
        /// <param name="conditionList">The condition list used to construct the sub data.</param>
        /// <returns>Object that implements Sub Translation Data Interface.</returns>
        public ISubTranslationData GetSubData(List<bool> conditionList)
        {
            if (conditionList.Count == 0)
                throw new System.Exception("Passed Condition List is Empty.");

            var newIndexReference = new List<int>();
            for (int i = 0; i < conditionList.Count; i++)
            {
                if (conditionList[i]) newIndexReference.Add(i);
            }

            if (newIndexReference.Count == 0)
                throw new System.Exception("Condition list retrieved no indices.");

            return ConstructSubTranslationData(newIndexReference);
        }

        /// <summary>
        /// Private method that constructs sub translation data based on index reference.
        /// </summary>
        /// <param name="newIndexReference">Index reference list used to construct the sub data.</param>
        /// <returns>Object that implements Sub Translation Data Interface.</returns>
        private ISubTranslationData ConstructSubTranslationData(List<int> newIndexReference)
        {
            return new SubTranslationData
            {
                IndexReference = newIndexReference
            };
        }
    }
}
