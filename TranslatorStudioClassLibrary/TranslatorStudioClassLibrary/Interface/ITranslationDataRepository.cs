using Microsoft.Office.Interop.Word;
using System.IO;

namespace TranslatorStudioClassLibrary.Interface
{
    /// <summary>
    /// Interface that defines the public properties and methods required to store Translation Data Repository.
    /// </summary>
    public interface ITranslationDataRepository
    {
        /// <summary>
        /// Creates translation data from word document.
        /// </summary>
        /// <param name="repo">Object that implements Project Data Repository Interface</param>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="document">The document that will be used in the conversion.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        ITranslationData CreateTranslationDataFromDocument(IProjectDataRepository repo, string fileName, Document document);
        /// <summary>
        /// Create translation data from project.
        /// </summary>
        /// <param name="project">Object that implements Project Data Interface</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        ITranslationData CreateTranslationDataFromProject(IProjectData project);
        /// <summary>
        /// Creates translation data from stream reader.
        /// </summary>
        /// <param name="repo">Object that implements Project Data Repository Interface</param>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="sr">The stream reader used to read the file.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        ITranslationData CreateTranslationDataFromStream(IProjectDataRepository repo, string fileName, StreamReader sr);
    }
}
