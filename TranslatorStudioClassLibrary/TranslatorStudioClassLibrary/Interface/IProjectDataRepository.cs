using Microsoft.Office.Interop.Word;
using System.IO;
using TranslatorStudioClassLibrary.Class;

namespace TranslatorStudioClassLibrary.Interface
{
    public interface IProjectDataRepository
    {
        IProjectData CreateProjectDataFromArray(string fileName, string[] rawLines);
        
        IProjectData CreateProjectDataFromStream(string fileName, StreamReader sr);

        IProjectData CreateProjectDataFromDocument(string fileName, Document document);

    }
}
