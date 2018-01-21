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
        /// Create Translation Data From Stream:
        ///     creates translation data from stream reader.
        /// </summary>
        /// <param name="fileName">string: the name of the file.</param>
        /// <param name="sr">StreamReader: the stream reader used to read the file.</param>
        /// <returns>ITranslationData: object that implements Translation Data Interface.</returns>
        public ITranslationData CreateTranslationDataFromDocument(string fileName, Document document)
        {
            try
            {
                var project = new ProjectDataRepository().CreateProjectDataFromDocument(fileName, document);

                return CreateTranslationDataFromProject(project);
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Create Translation Data From Document:
        ///     creates translation data from document.
        /// </summary>
        /// <param name="fileName">string: name of file.</param>
        /// <param name="document">Document: the document that will be used in the conversion.</param>
        /// <returns>ITranslationData: object that implements Translation Data Interface.</returns>
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
        /// Create Translation Data From Project:
        ///     create translation data from project.
        /// </summary>
        /// <param name="project">IProjectData: object that implements Project Data Interface</param>
        /// <returns>ITranslationData: object that implements Translation Data Interface.</returns>
        public ITranslationData CreateTranslationDataFromStream(string fileName, StreamReader sr)
        {
            try
            {
                var project = new ProjectDataRepository().CreateProjectDataFromStream(fileName, sr);

                return CreateTranslationDataFromProject(project);
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
        
    }
}
