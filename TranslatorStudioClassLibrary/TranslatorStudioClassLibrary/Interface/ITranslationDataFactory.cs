using Microsoft.Office.Interop.Word;
using System.IO;
using TranslatorStudioClassLibrary.Exception;

namespace TranslatorStudioClassLibrary.Interface
{
    /// <summary>
    /// Interface that defines the public properties and methods required to construct Translation Data.
    /// </summary>
    public interface ITranslationDataFactory
    {
        #region Methods

        /// <summary>
        /// Creates translation data from array.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="rawLines">Array of strings that holds the raw lines.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        ITranslationData CreateTranslationDataFromArray(string fileName, string[] rawLines);
        
        /// <summary>
        /// Creates translation data from word document.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="document">The document that will be used in the conversion.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        ITranslationData CreateTranslationDataFromDocument(string fileName, Document document);
        
        /// <summary>
        /// Create translation data from project.
        /// </summary>
        /// <param name="project">Object that implements Project Data Interface</param>
        /// <exception cref="EmptyRawException">Thrown when provided raw lines are empty.</exception>
        /// <returns>Object that implements Translation Data Interface.</returns>
        ITranslationData CreateTranslationDataFromProject(IProjectData project);
        
        /// <summary>
        /// Creates translation data from stream reader.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="sr">The stream reader used to read the file.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        ITranslationData CreateTranslationDataFromStream(string fileName, StreamReader sr);

        #endregion
    }
}
