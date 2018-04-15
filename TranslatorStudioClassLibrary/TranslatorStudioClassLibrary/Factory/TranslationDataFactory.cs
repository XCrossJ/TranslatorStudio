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
        #region Properties
        private readonly IProjectDataFactory _projectDataFactory;
        private readonly ISubTranslationDataFactory _subTranslationDataFactory;
        #endregion

        #region Constructors

        /// <summary>
        /// Creates Translation Data Factory with Project Data Factory.
        /// </summary>
        /// <param name="projectDataFactory">Project Data Factory used to construct Project Data.</param>
        /// <param name="subTranslationDataFactory">Project Data Factory used to construct Sub Translation Data.</param>
        public TranslationDataFactory(IProjectDataFactory projectDataFactory, ISubTranslationDataFactory subTranslationDataFactory)
        {
            _projectDataFactory = projectDataFactory ?? throw new System.ArgumentNullException(nameof(projectDataFactory));
            _subTranslationDataFactory = subTranslationDataFactory ?? throw new System.ArgumentNullException(nameof(subTranslationDataFactory));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates translation data from array.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="rawLines">Array of strings that holds the raw lines.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        public ITranslationData CreateTranslationDataFromArray(string fileName, string[] rawLines)
        {
            try
            {
                var project = _projectDataFactory.CreateProjectDataFromArray(fileName, rawLines);

                var translationData = CreateTranslationDataFromProject(project);
                translationData.DataChanged = true;
                return translationData;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// Creates translation data from word document.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="document">The document that will be used in the conversion.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        public ITranslationData CreateTranslationDataFromDocument(string fileName, Document document)
        {
            try
            {
                var project = _projectDataFactory.CreateProjectDataFromDocument(fileName, document);

                var translationData = CreateTranslationDataFromProject(project);
                translationData.DataChanged = false;
                return translationData;
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
                if (!project.ProjectLines.Any())
                    throw ExceptionHelper.NewEmptyRawException;

                return new TranslationData(project, _subTranslationDataFactory)
                {
                    DataChanged = false
                };
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
        
        /// <summary>
        /// Creates translation data from stream reader.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="sr">The stream reader used to read the file.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        public ITranslationData CreateTranslationDataFromStream(string fileName, StreamReader sr)
        {
            try
            {
                var project = _projectDataFactory.CreateProjectDataFromStream(fileName, sr);

                var translationData = CreateTranslationDataFromProject(project);
                translationData.DataChanged = false;
                return translationData;
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }

        #endregion
    }
}
