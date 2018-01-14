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
    public static class FileHelper
    {
        public static ITranslationData OpenTextFile(string path, string fileName)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default, true);
            var data = new TranslationDataRepository().CreateTranslationDataFromStream(fileName, sr);
            return data;
        }

        public static ITranslationData OpenDocFile(string path, string fileName)
        {
            Application application = new Application();
            Document document = new Document();

            document = application.Documents.Open(path);

            var data = new TranslationDataRepository().CreateTranslationDataFromDocument(fileName, document);

            document.Close();
            application.Quit();

            return data;
        }

        public static ITranslationData OpenTSPFile(string path, string fileName)
        {
            string output = File.ReadAllText(path);
            var projectData = JsonConvert.DeserializeObject<ProjectData>(output);
            var data = new TranslationDataRepository().CreateTranslationDataFromProject(projectData);
            return data;
        }

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

        public static bool SaveProject(ITranslationData data, string path)
        {
            var json = JObject.Parse(data.GetSaveString());
            File.WriteAllText(path, json.ToString());
            return true;
        }

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
