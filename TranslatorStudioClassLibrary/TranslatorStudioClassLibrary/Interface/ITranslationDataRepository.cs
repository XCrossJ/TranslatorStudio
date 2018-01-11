using Microsoft.Office.Interop.Word;
using System.IO;
using TranslatorStudioClassLibrary.Class;

namespace TranslatorStudioClassLibrary.Interface
{
    public interface ITranslationDataRepository
    {
        TranslationData CreateTranslationDataFromStream(string fileName, StreamReader sr);

        TranslationData CreateTranslationDataFromDocument(string fileName, Document document);

        TranslationData CreateTranslationDataFromProject(IProjectData project);

    }
}
