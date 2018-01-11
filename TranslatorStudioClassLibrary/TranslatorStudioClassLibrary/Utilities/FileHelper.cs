using System.IO;
using System.Text;
using TranslatorStudioClassLibrary.Class;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Office.Interop.Word;
using TranslatorStudioClassLibrary.Repository;

namespace TranslatorStudioClassLibrary.Utilities
{
    public static class FileHelper
    {
        public static TranslationData OpenTextFile(string path, string fileName)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default, true);
            var data = new TranslationDataRepository().CreateTranslationDataFromStream(fileName, sr);
            return data;
        }

        public static TranslationData OpenDocFile(string path, string fileName)
        {
            Application application = new Application();
            Document document = new Document();

            document = application.Documents.Open(path);

            var data = new TranslationDataRepository().CreateTranslationDataFromDocument(fileName, document);

            document.Close();
            application.Quit();

            return data;
        }

        public static TranslationData OpenTSPFile(string path, string fileName)
        {
            string output = File.ReadAllText(path);
            var projectData = JsonConvert.DeserializeObject<ProjectData>(output);
            var data = new TranslationDataRepository().CreateTranslationDataFromProject(projectData);
            return data;
        }

        public static bool SaveProject(TranslationData data, string path)
        {
            var json = JObject.Parse(data.GetSaveString());
            File.WriteAllText(path, json.ToString());
            return true;
        }

        public static void ExportTranslation(TranslationData data, string path)
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
