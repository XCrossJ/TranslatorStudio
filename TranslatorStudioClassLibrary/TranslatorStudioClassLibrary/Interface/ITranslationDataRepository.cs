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
        /// Create Translation Data From Stream:
        ///     creates translation data from stream reader.
        /// </summary>
        /// <param name="repo">IProjectDataRepository: object that implements Project Data Repository Interface</param>
        /// <param name="fileName">string: the name of the file.</param>
        /// <param name="sr">StreamReader: the stream reader used to read the file.</param>
        /// <returns>ITranslationData: object that implements Translation Data Interface.</returns>
        ITranslationData CreateTranslationDataFromStream(IProjectDataRepository repo, string fileName, StreamReader sr);

        /// <summary>
        /// Create Translation Data From Document:
        ///     creates translation data from document.
        /// </summary>
        /// <param name="repo">IProjectDataRepository: object that implements Project Data Repository Interface</param>
        /// <param name="fileName">string: name of file.</param>
        /// <param name="document">Document: the document that will be used in the conversion.</param>
        /// <returns>ITranslationData: object that implements Translation Data Interface.</returns>
        ITranslationData CreateTranslationDataFromDocument(IProjectDataRepository repo, string fileName, Document document);

        /// <summary>
        /// Create Translation Data From Project:
        ///     create translation data from project.
        /// </summary>
        /// <param name="project">IProjectData: object that implements Project Data Interface</param>
        /// <returns>ITranslationData: object that implements Translation Data Interface.</returns>
        ITranslationData CreateTranslationDataFromProject(IProjectData project);
    }
}
