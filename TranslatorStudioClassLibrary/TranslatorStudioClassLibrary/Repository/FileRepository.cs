namespace TranslatorStudioClassLibrary.Repository
{
    using Microsoft.Office.Interop.Word;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Class;
    using Interface;

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
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("File path to open not supplied.", nameof(path));
            }
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("File name to open not supplied.", nameof(fileName));
            }

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
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("File path to open not supplied.", nameof(path));
            }
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("File name to open not supplied.", nameof(fileName));
            }

            Application application = new Application();
            Document document = new Document();

            document = application.Documents.Open(path);

            var data = _translationDataFactory.CreateTranslationDataFromDocument(fileName, document);

            document.Close();
            application.Quit();

            return data;
        }
        /// <summary>
        /// Opens translation data from translation studio project file (legacy).
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        public ITranslationData OpenTSPFile(string path, string fileName)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("File path to open not supplied.", nameof(path));
            }
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("File name to open not supplied.", nameof(fileName));
            }

            string output = File.ReadAllText(path);
            var projectData = OpenLegacyProject(output);
            var data = _translationDataFactory.CreateTranslationDataFromProject(projectData);
            return data;
        }
        /// <summary>
        /// Opens translation data from translation studio project file.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Object that implements Translation Data Interface.</returns>
        public ITranslationData OpenTSProjFile(string path, string fileName)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("File path to open not supplied.", nameof(path));
            }
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("File name to open not supplied.", nameof(fileName));
            }

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
            if (string.IsNullOrWhiteSpace(fileExt))
            {
                throw new ArgumentException("File extension to open not supplied.", nameof(fileExt));
            }
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("File path to open not supplied.", nameof(path));
            }
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("File name to open not supplied.", nameof(fileName));
            }

            string previousSavePath = "";
            ITranslationData data;
            switch (fileExt)
            {
                case ".tsp":
                    data = OpenTSPFile(path, fileName);
                    previousSavePath = path;
                    break;
                case ".tsproj":
                    data = OpenTSProjFile(path, fileName);
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
                    throw new Exception("File Type Not Handled.");
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
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("File path to save to not supplied", nameof(path));
            }

            try
            {
                var json = JObject.Parse(data.GetProjectSaveString());
                File.WriteAllText(path, json.ToString());
                return true;
            }
            catch (Exception)
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
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("File path to export to not supplied", nameof(path));
            }

            return TextDumpEnumerable(data.ProjectLines.Select(x => x.Translation), path);
        }
        #endregion

        #endregion


        #region Private Methods
        /// <summary>
        /// Writes enumerable to text path in specified path.
        /// </summary>
        /// <param name="data">String Enumerable to be dumped to text file.</param>
        /// <param name="path">Path where the text file will be stored/saved.</param>
        /// <returns>Result of attempt to dump text.</returns>
        private bool TextDumpEnumerable(IEnumerable<string> data, string path)
        {
            try
            {
                File.WriteAllLines(path, data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region Open Project Data (.tsproj)
        /// <summary>
        /// Opens Project Data from JSON. (.tsproj)
        /// </summary>
        /// <param name="jsonString">String used in conversion.</param>
        /// <returns>Object that implements IProjectData interface.</returns>
        private IProjectData OpenProject(string jsonString)
        {
            var success = TryConvertProjectV1(jsonString, out IProjectData projectData);

            if (success)
                return projectData;
            else
                throw new Exception("Unable to open file");
        }

        /// <summary>
        /// Tries to convert Project Data from JSON using Project Data Structure Version 1.
        /// </summary>
        /// <param name="jsonString">String used in conversion.</param>
        /// <param name="projectData">Object that implements IProjectData interface.</param>
        /// <returns>Result of attempt to convert project.</returns>
        private bool TryConvertProjectV1(string jsonString, out IProjectData projectData)
        {
            try
            {
                projectData = JsonConvert.DeserializeObject<ProjectData>(jsonString);
                return true;
            }
            catch (Exception)
            {
                try // Will need to fix later
                {
                    var definition = new
                    {
                        SaveFormatVersion = 0,
                        ProjectName = "",
                        SourceLink = "",
                        ProjectLines = new List<ProjectLine>()
                    };

                    var newProject = JsonConvert.DeserializeAnonymousType(jsonString, definition);

                    projectData = new ProjectData
                    {
                        SaveFormatVersion = newProject.SaveFormatVersion,
                        ProjectName = newProject.ProjectName,
                        SourceLink = newProject.SourceLink,
                        ProjectLines = newProject.ProjectLines.ToList<IProjectLine>()
                    };
                    return true;
                }
                catch (Exception)
                {
                    projectData = null;
                    return false;
                }
            }
        }
        #endregion

        #region Open Legacy Project Data (.tsp)
        /// <summary>
        /// Opens Legacy Project Data from JSON. (.tsp)
        /// </summary>
        /// <param name="jsonString">String used in conversion.</param>
        /// <returns>Object that implements IProjectData interface.</returns>
        private IProjectData OpenLegacyProject(string jsonString)
        {
            var success = TryConvertProjectLegacy(jsonString, out IProjectData projectData);

            if (success)
                return projectData;
            else
                success = TryConvertProjectLegacyV1(jsonString, out projectData);

            if (success)
                return projectData;
            else
                throw new Exception("Unable to open file");
        }

        /// <summary>
        /// Tries to convert Project Data from JSON using Legacy Project Data Structure Version 1.
        /// </summary>
        /// <param name="jsonString">String used in conversion.</param>
        /// <param name="projectData">Object that implements IProjectData interface.</param>
        /// <returns>Result of attempt to convert project.</returns>
        private bool TryConvertProjectLegacyV1(string jsonString, out IProjectData projectData)
        {
            try
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
            catch (Exception)
            {
                projectData = null;
                return false;
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

                for (int i = 0; i < oldProject.RawLines.Count; i++)
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
            catch (Exception)
            {
                projectData = null;
                return false;
            }
        }
        #endregion

        #endregion
    }
}
