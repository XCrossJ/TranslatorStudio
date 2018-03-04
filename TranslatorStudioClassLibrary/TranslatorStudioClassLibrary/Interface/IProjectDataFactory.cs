using Microsoft.Office.Interop.Word;
using System.IO;
using TranslatorStudioClassLibrary.Exception;

namespace TranslatorStudioClassLibrary.Interface
{
    /// <summary>
    /// Interface that defines the public properties and methods required to construct Project Data.
    /// </summary>
    public interface IProjectDataFactory
    {
        /// <summary>
        /// Creates project data from array.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="rawLines">Array of strings that holds the raw lines.</param>
        /// <exception cref="EmptyRawException">Thrown when provided raw lines are empty.</exception>
        /// <returns>Object that implements Project Data Interface.</returns>
        IProjectData CreateProjectDataFromArray(string fileName, string[] rawLines);

        /// <summary>
        /// Creates project data from stream reader.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="sr">The stream reader used to read the file.</param>
        /// <exception cref="EmptyRawException">Thrown when provided raw lines are empty.</exception>
        /// <returns>Object that implements Project Data Interface.</returns>
        IProjectData CreateProjectDataFromStream(string fileName, StreamReader sr);

        /// <summary>
        /// Creates project data from word document.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="document">The document that will be used in the conversion.</param>
        /// <exception cref="EmptyRawException">Thrown when provided raw lines are empty.</exception>
        /// <returns>Object that implements Project Data Interface.</returns>
        IProjectData CreateProjectDataFromDocument(string fileName, Document document);
    }
}
