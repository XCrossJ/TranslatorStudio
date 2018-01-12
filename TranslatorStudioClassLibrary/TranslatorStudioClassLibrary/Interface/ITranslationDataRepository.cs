using Microsoft.Office.Interop.Word;
using System.IO;
using TranslatorStudioClassLibrary.Class;

namespace TranslatorStudioClassLibrary.Interface
{
    public interface ITranslationDataRepository
    {
        ITranslationData CreateTranslationDataFromStream(string fileName, StreamReader sr);

        ITranslationData CreateTranslationDataFromDocument(string fileName, Document document);

        ITranslationData CreateTranslationDataFromProject(IProjectData project);

    }
}
