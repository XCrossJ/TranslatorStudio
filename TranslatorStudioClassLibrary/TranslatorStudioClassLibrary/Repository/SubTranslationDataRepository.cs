using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudioClassLibrary.Repository
{
    public class SubTranslationDataRepository : ISubTranslationDataRepository
    {
        public SubTranslationData GetSubData(bool[] conditionList)
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

        private SubTranslationData ConstructSubTranslationData(List<int> newIndexReference)
        {
            return new SubTranslationData()
            {
                IndexReference = newIndexReference
            };
        }
    }
}
