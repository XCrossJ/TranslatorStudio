using System.Collections.Generic;

namespace TranslatorStudioClassLibrary.Interface
{
    public interface ISubTranslationDataRepository
    {
        ISubTranslationData GetSubData(bool[] conditionList);
    }
}
