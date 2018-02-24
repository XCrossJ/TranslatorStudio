using System.IO;
using System.Linq;
using Microsoft.Office.Interop.Word;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudioClassLibrary.Repository
{
    /// <summary>
    /// Class that contains the properties and method relevant for Translation Data Repository.
    /// Implements Translation Data Repository Interface.
    /// </summary>
    public class TranslationDataRepository: ITranslationDataRepository
    {
        /// <summary>
        /// Creates translation data from word document.
        /// </summary>
        /// <param name="repo">Object that implements Project Data Repository Interface</param>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="document">The document that will be used in the conversion.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        public ITranslationData CreateTranslationDataFromDocument(IProjectDataRepository repo, string fileName, Document document)
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
        /// <returns>Object that implements Translation Data Interface.</returns>
        public ITranslationData CreateTranslationDataFromProject(IProjectData project)
        {
            try
            {
                if (!project.RawLines.Any())
                    throw new System.Exception("No Raw Lines were submitted into the project.");

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
        /// <param name="repo">Object that implements Project Data Repository Interface</param>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="sr">The stream reader used to read the file.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        public ITranslationData CreateTranslationDataFromStream(IProjectDataRepository repo, string fileName, StreamReader sr)
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
