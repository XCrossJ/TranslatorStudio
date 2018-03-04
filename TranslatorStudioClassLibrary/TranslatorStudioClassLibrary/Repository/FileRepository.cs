using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudioClassLibrary.Repository
{
    /// <summary>
    /// Class responsible for writing and reading files.
    /// Class that contains the properties and method relevant for File Repository.
    /// Implements File Repository Interface.
    /// </summary>
    public class FileRepository : IFileRepository
    {
        #region Properties
        /// <summary>
        /// Factory that constructs the translation data.
        /// </summary>
        private readonly ITranslationDataFactory _translationDataFactory;
        /// <summary>
        /// Factory that constructs the project data.
        /// </summary>
        private readonly IProjectDataFactory _projectDataFactory;
        #endregion

        #region Constructor

        /// <summary>
        /// Creates File Repository.
        /// </summary>
        /// <param name="translationDataFactory">Factory that constructs the translation data.</param>
        /// <param name="projectDataFactory">Factory that constructs the project data.</param>
        public FileRepository(ITranslationDataFactory translationDataFactory, IProjectDataFactory projectDataFactory)
        {
            _translationDataFactory = translationDataFactory ?? throw new System.Exception("No Translation Data Factory");
            _projectDataFactory = projectDataFactory ?? throw new System.Exception("No Project Data Factory");
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Opens translation data from text file.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        public ITranslationData OpenTextFile(string path, string fileName)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default, true);
            var data = _translationDataFactory.CreateTranslationDataFromStream(_projectDataFactory, fileName, sr);
            return data;
        }
        /// <summary>
        /// Opens translation data from word document.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        public ITranslationData OpenDocFile(string path, string fileName)
        {
            Application application = new Application();
            Document document = new Document();

            document = application.Documents.Open(path);

            var data = _translationDataFactory.CreateTranslationDataFromDocument(_projectDataFactory, fileName, document);

            document.Close();
            application.Quit();

            return data;
        }
        /// <summary>
        /// Opens translation data from translation studio project file.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        public ITranslationData OpenTSPFile(string path, string fileName)
        {
            string output = File.ReadAllText(path);
            var projectData = JsonConvert.DeserializeObject<IProjectData>(output);
            var data = _translationDataFactory.CreateTranslationDataFromProject(projectData);
            return data;
        }

        /// <summary>
        /// Handler that returns Translation Data and Previous Save Path from parameters.
        /// </summary>
        /// <param name="fileExt">Extension of the file.</param>
        /// <param name="path">Path of the file.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>An object that implements Translation Data Interface and the previous save path.</returns>
        public Tuple<ITranslationData, string> OpenHandler(string fileExt, string path, string fileName)
        {
            string previousSavePath = "";
            ITranslationData data;
            switch (fileExt)
            {
                case ".tsp":
                    data = OpenTSPFile(path, fileName);
                    previousSavePath = path;
                    break;
                case ".doc":
                case ".docx":
                    data = OpenDocFile(path, fileName);
                    break;
                case ".txt":
                    data = OpenTextFile(path, fileName);
                    break;
                default:
                    throw new System.Exception("File Type Not Handled.");
            }
            var openData = new Tuple<ITranslationData, string>(data, previousSavePath);
            return openData;
        }

        /// <summary>
        /// Saves translation project data to file.
        /// </summary>
        /// <param name="data">Translation data to save.</param>
        /// <param name="path">Path of the file.</param>
        /// <returns>The result of the save.</returns>
        public bool SaveProject(ITranslationData data, string path)
        {
            try
            {
                var json = JObject.Parse(data.GetProjectSaveString());
                File.WriteAllText(path, json.ToString());
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Exports translated lines in translation project to file.
        /// </summary>
        /// <param name="data">Translation data to save.</param>
        /// <param name="path">Path of the file.</param>
        /// <returns>The result of the export.</returns>
        public bool ExportTranslation(ITranslationData data, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (var item in data.TranslatedLines)
                    {
                        sw.WriteLine(item);
                    }
                }
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        
        #endregion
    }
}
