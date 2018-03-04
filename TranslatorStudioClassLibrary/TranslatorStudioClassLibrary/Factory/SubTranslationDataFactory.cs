using System.Collections.Generic;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudioClassLibrary.Factory
{
    /// <summary>
    /// Class responsible for constructing Sub Translation Data.
    /// Class that contains the properties and method relevant for Sub Translation Data Factory.
    /// Implements Sub Translation Data Factory Interface.
    /// </summary>
    public class SubTranslationDataFactory : ISubTranslationDataFactory
    {
        #region Methods

        #region Public
        
        /// <summary>
        /// Creates sub translation data based on condition list.
        /// </summary>
        /// <param name="conditionList">The condition list used to construct the sub data.</param>
        /// <returns>Object that implements Sub Translation Data Interface.</returns>
        public ISubTranslationData GetSubData(List<bool> conditionList)
        {
            if (conditionList.Count == 0)
                throw ExceptionHelper.NewInvalidConditionListException_Empty;

            var newIndexReference = new List<int>();
            for (int i = 0; i < conditionList.Count; i++)
            {
                if (conditionList[i]) newIndexReference.Add(i);
            }

            if (newIndexReference.Count == 0)
                throw ExceptionHelper.NewInvalidConditionListException_NoResults;

            return ConstructSubTranslationData(newIndexReference);
        }

        #endregion

        #region Private

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

        #endregion

        #endregion
    }
}
