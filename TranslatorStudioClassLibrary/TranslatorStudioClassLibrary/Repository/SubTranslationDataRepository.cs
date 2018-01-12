using System.Collections.Generic;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudioClassLibrary.Repository
{
    public class SubTranslationDataRepository : ISubTranslationDataRepository
    {
        public ISubTranslationData GetSubData(bool[] conditionList)
        {
            var newIndexReference = new List<int>();
            for (int i = 0; i < conditionList.Length; i++)
            {
                if (conditionList[i])
                {
                    newIndexReference.Add(i);
                }
            }

            return ConstructSubTranslationData(newIndexReference);
        }

        private ISubTranslationData ConstructSubTranslationData(List<int> newIndexReference)
        {
            return new SubTranslationData()
            {
                IndexReference = newIndexReference
            };
        }
    }
}
