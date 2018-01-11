using Microsoft.Office.Interop.Word;
using System.IO;
using TranslatorStudioClassLibrary.Class;

namespace TranslatorStudioClassLibrary.Interface
{
    public interface IProjectDataRepository
    {
        ProjectData CreateProjectDataFromArray(string fileName, string[] rawLines);
        
        ProjectData CreateProjectDataFromStream(string fileName, StreamReader sr);

        ProjectData CreateProjectDataFromDocument(string fileName, Document document);

    }
}
