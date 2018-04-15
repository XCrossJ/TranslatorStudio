using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TranslatorStudioClassLibrary.Class;
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
        #endregion

        #region Constructor
        /// <summary>
        /// Creates File Repository.
        /// </summary>
        /// <param name="translationDataFactory">Factory that constructs the translation data.</param>
        public FileRepository(ITranslationDataFactory translationDataFactory)
        {
            _translationDataFactory = translationDataFactory ?? throw new ArgumentNullException(nameof(translationDataFactory));
        }
        #endregion

        #region Public Methods

        #region Read Methods
        /// <summary>
        /// Opens translation data from text file.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        public ITranslationData OpenTextFile(string path, string fileName)
        {
            using (StreamReader sr = new StreamReader(path, Encoding.Default, true))
            {
                var data = _translationDataFactory.CreateTranslationDataFromStream(fileName, sr);
                return data;
            }
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

            var data = _translationDataFactory.CreateTranslationDataFromDocument(fileName, document);

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
            var projectData = OpenProject(output);
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
        public Tuple<ITranslationData, string> OpenFile(string fileExt, string path, string fileName)
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
        #endregion

        #region Write Methods
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
                    foreach (var item in data.ProjectLines)
                    {
                        sw.WriteLine(item.Translation);
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

        #endregion

        #region Private Methods
        /// <summary>
        /// Opens Project Data from JSON.
        /// </summary>
        /// <param name="jsonString">String used in conversion.</param>
        /// <returns>Object that implements IProjectData interface.</returns>
        private IProjectData OpenProject(string jsonString)
        {
            var success = TryConvertProjectLegacy(jsonString, out IProjectData projectData);

            if (success)
                return projectData;
            else
                success = TryConvertProjectV2(jsonString, out projectData);

            if (success)
                return projectData;
            else
                throw new System.Exception("Unable to open file");
        }

        /// <summary>
        /// Tries to convert Project Data from JSON using Project Data Structure Version 2.
        /// </summary>
        /// <param name="jsonString">String used in conversion.</param>
        /// <param name="projectData">Object that implements IProjectData interface.</param>
        /// <returns>Result of attempt to convert project.</returns>
        private bool TryConvertProjectV2(string jsonString, out IProjectData projectData)
        {
            try
            {
                projectData = JsonConvert.DeserializeObject<ProjectData>(jsonString);
                return true;
            }
            catch (System.Exception)
            {
                try // Will need to fix later
                {
                    var definition = new
                    {
                        ProjectName = "",
                        ProjectLines = new List<ProjectLine>()
                    };

                    var newProject = JsonConvert.DeserializeAnonymousType(jsonString, definition);

                    projectData = new ProjectData
                    {
                        ProjectName = newProject.ProjectName,
                        ProjectLines = newProject.ProjectLines.ToList<IProjectLine>()
                    };
                    return true;
                }
                catch (System.Exception)
                {
                    projectData = null;
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to convert Project Data from JSON using Legacy Project Data Structure.
        /// </summary>
        /// <param name="jsonString">String used in conversion.</param>
        /// <param name="projectData">Object that implements IProjectData interface.</param>
        /// <returns>Result of attempt to convert project.</returns>
        private bool TryConvertProjectLegacy(string jsonString, out IProjectData projectData)
        {
            try
            {
                var definition = new
                {
                    ProjectName = "",
                    RawLines = new List<string>(),
                    TranslatedLines = new List<string>(),
                    CompletedLines = new List<bool>(),
                    MarkedLines = new List<bool>(),
                };
                var oldProject = JsonConvert.DeserializeAnonymousType(jsonString, definition);

                var projectLines = new List<IProjectLine>();

                for (int i = 0; i < oldProject.RawLines.Count - 1; i++)
                {
                    projectLines.Add(new ProjectLine
                    {
                        Raw = oldProject.RawLines[i],
                        Translation = oldProject.TranslatedLines[i],
                        Completed = oldProject.CompletedLines[i],
                        Marked = oldProject.MarkedLines[i]
                    });
                }

                projectData = new ProjectData
                {
                    ProjectName = oldProject.ProjectName,
                    ProjectLines = projectLines
                };
                
                return true;
            }
            catch (System.Exception)
            {
                projectData = null;
                return false;
            }
        }
        #endregion
    }
}
