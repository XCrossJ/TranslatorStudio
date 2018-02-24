using System.IO;
using System.Text;
using TranslatorStudioClassLibrary.Class;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Office.Interop.Word;
using TranslatorStudioClassLibrary.Repository;
using TranslatorStudioClassLibrary.Interface;
using System;

namespace TranslatorStudioClassLibrary.Utilities
{
    /// <summary>
    /// Helper that contains commonly used methods for file input/output
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Translation Data Repository: repository that obtains translation data.
        /// </summary>
        private static readonly ITranslationDataRepository translationDataRepository = new TranslationDataRepository();
        /// <summary>
        /// Project Data Repository: repository that obtains project data.
        /// </summary>
        private static readonly IProjectDataRepository projectDataRepository = new ProjectDataRepository();

        /// <summary>
        /// Open Text File:
        ///     opens translation data from text file.
        /// </summary>
        /// <param name="path">string: path of the file.</param>
        /// <param name="fileName">string: name of the file.</param>
        /// <returns>ITranslationData: object that implements Translation Data Interface.</returns>
        public static ITranslationData OpenTextFile(string path, string fileName)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default, true);
            var data = translationDataRepository.CreateTranslationDataFromStream(projectDataRepository, fileName, sr);
            return data;
        }

        /// <summary>
        /// Open Doc File:
        ///     opens translation data from word document.
        /// </summary>
        /// <param name="path">string: path of the file.</param>
        /// <param name="fileName">string: name of the file.</param>
        /// <returns>ITranslationData: object that implements Translation Data Interface.</returns>
        public static ITranslationData OpenDocFile(string path, string fileName)
        {
            Application application = new Application();
            Document document = new Document();

            document = application.Documents.Open(path);

            var data = translationDataRepository.CreateTranslationDataFromDocument(projectDataRepository, fileName, document);

            document.Close();
            application.Quit();

            return data;
        }

        /// <summary>
        /// Open TSP File:
        ///     opens translation data from translation studio project file.
        /// </summary>
        /// <param name="path">string: path of the file.</param>
        /// <param name="fileName">string: name of the file.</param>
        /// <returns>ITranslationData: object that implements Translation Data Interface.</returns>
        public static ITranslationData OpenTSPFile(string path, string fileName)
        {
            string output = File.ReadAllText(path);
            var projectData = JsonConvert.DeserializeObject<ProjectData>(output);
            var data = new TranslationDataRepository().CreateTranslationDataFromProject(projectData);
            return data;
        }

        /// <summary>
        /// Open Handler:
        ///     handler that returns TranslationData and Previous Save Path from parameters.
        /// </summary>
        /// <param name="fileExt">string: extension of the file.</param>
        /// <param name="path">string: path of the file.</param>
        /// <param name="fileName">string: name of the file.</param>
        /// <returns>Tuple: object that returns an object that implements Translation Data Interface and a string.</returns>
        public static Tuple<ITranslationData, string> OpenHandler(string fileExt, string path, string fileName)
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
        /// Save Project:
        ///     saves translation project data to file.
        /// </summary>
        /// <param name="data">ITranslationData: translation data to save.</param>
        /// <param name="path">string: path of the file.</param>
        /// <returns>bool: the result of the save.</returns>
        public static bool SaveProject(ITranslationData data, string path)
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
        /// Export Translation:
        ///     exports translated lines in translation project to file.
        /// </summary>
        /// <param name="data">ITranslationData: translation data to save.</param>
        /// <param name="path">string: path of the file.</param>
        public static void ExportTranslation(ITranslationData data, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var item in data.TranslatedLines)
                {
                    sw.WriteLine(item);
                }
            }
        }
        
    }
}
