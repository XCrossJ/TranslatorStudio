using TranslatorStudioClassLibrary.Class;

namespace TranslatorStudioClassLibrary.Interface
{
    public interface ISubTranslationDataRepository
    {
        SubTranslationData GetSubData(bool[] conditionList);
    }
}
