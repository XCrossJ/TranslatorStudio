using System.Collections.Generic;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudioClassLibrary.Class
{
    public class SubTranslationData : ISubTranslationData
    {
        public SubTranslationData()
        {
            IndexReference = new List<int>();
        }

        public SubTranslationData(bool[] conditionList)
        {
            IndexReference = new List<int>();
            for (int i = 0; i < conditionList.Length; i++)
            {
                if (conditionList[i])
                {
                    IndexReference.Add(i);
                }
            }
        }

        public List<int> IndexReference { get; set; }

        public int CurrentReference => IndexReference[CurrentIndex];

        public int CurrentIndex { get; set; }
        public int MaxIndex => IndexReference.Count - 1;

        public int NumberOfLines => IndexReference.Count;

    }
}
