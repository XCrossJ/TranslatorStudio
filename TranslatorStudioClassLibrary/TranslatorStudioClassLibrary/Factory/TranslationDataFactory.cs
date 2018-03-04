using System.IO;
using System.Linq;
using Microsoft.Office.Interop.Word;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Exception;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Utilities;

namespace TranslatorStudioClassLibrary.Factory
{
    /// <summary>
    /// Class responsible for constructing Translation Data.
    /// Class that contains the properties and method relevant for Translation Data Factory.
    /// Implements Translation Data Factory Interface.
    /// </summary>
    public class TranslationDataFactory: ITranslationDataFactory
    {
        /// <summary>
        /// Creates translation data from word document.
        /// </summary>
        /// <param name="repo">Object that implements Project Data Factory Interface</param>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="document">The document that will be used in the conversion.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        public ITranslationData CreateTranslationDataFromDocument(IProjectDataFactory repo, string fileName, Document document)
        {
            try
            {
                var project = repo.CreateProjectDataFromDocument(fileName, document);

                return CreateTranslationDataFromProject(project);
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
        /// <summary>
        /// Create translation data from project.
        /// </summary>
        /// <param name="project">Object that implements Project Data Interface</param>
        /// <exception cref="EmptyRawException">Thrown when provided raw lines are empty.</exception>
        /// <returns>Object that implements Translation Data Interface.</returns>
        public ITranslationData CreateTranslationDataFromProject(IProjectData project)
        {
            try
            {
                if (!project.RawLines.Any())
                    throw ExceptionHelper.NewEmptyRawException;

                return new TranslationData(project);
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
        /// <summary>
        /// Creates translation data from stream reader.
        /// </summary>
        /// <param name="repo">Object that implements Project Data Factory Interface</param>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="sr">The stream reader used to read the file.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        public ITranslationData CreateTranslationDataFromStream(IProjectDataFactory repo, string fileName, StreamReader sr)
        {
            try
            {
                var project = repo.CreateProjectDataFromStream(fileName, sr);

                return CreateTranslationDataFromProject(project);
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
    }
}
