using System.Collections.Generic;

namespace TranslatorStudioClassLibrary.Interface
{
    public interface ISubTranslationData
    {
        List<int> IndexReference { get; set; }

        int CurrentReference { get; }

        int CurrentIndex { get; set; }
        int MaxIndex { get; }

        int NumberOfLines { get; }
    }
}
