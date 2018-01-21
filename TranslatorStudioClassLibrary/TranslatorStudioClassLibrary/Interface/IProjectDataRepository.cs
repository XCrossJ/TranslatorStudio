using Microsoft.Office.Interop.Word;
using System.IO;
using TranslatorStudioClassLibrary.Class;

namespace TranslatorStudioClassLibrary.Interface
{
    /// <summary>
    /// Interface that defines the public properties and methods required to store Project Data Repository.
    /// </summary>
    public interface IProjectDataRepository
    {
        /// <summary>
        /// Create Project Data From Array:
        ///     creates project data from array.
        /// </summary>
        /// <param name="fileName">string: the name of the file.</param>
        /// <param name="rawLines">string[]: array of strings that holds the raw lines.</param>
        /// <returns>IProjectData: object that implements Project Data Interface.</returns>
        IProjectData CreateProjectDataFromArray(string fileName, string[] rawLines);

        /// <summary>
        /// Create Project Data From Stream:
        ///     creates project data from stream reader.
        /// </summary>
        /// <param name="fileName">string: the name of the file.</param>
        /// <param name="sr">StreamReader: the stream reader used to read the file.</param>
        /// <returns>IProjectData: object that implements Project Data Interface.</returns>
        IProjectData CreateProjectDataFromStream(string fileName, StreamReader sr);

        /// <summary>
        /// Create Project Data From Document:
        ///     creates project data from document.
        /// </summary>
        /// <param name="fileName">string: the name of the file.</param>
        /// <param name="document">Document: the document that will be used in the conversion.</param>
        /// <returns>IProjectData: object that implements Project Data Interface.</returns>
        IProjectData CreateProjectDataFromDocument(string fileName, Document document);

    }
}
