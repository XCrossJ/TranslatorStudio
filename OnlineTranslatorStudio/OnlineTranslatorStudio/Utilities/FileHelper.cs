using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Repository;

namespace OnlineTranslatorStudio.Utilities
{
    public static class FileHelper
    {
        public static TranslationData OpenTextFile(string path, string fileName)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default, true);
            var data = new TranslationDataRepository().CreateTranslationDataFromStream(fileName, sr);
            return data;
        }

        public static TranslationData OpenTSPFile(string path, string fileName)
        {
            string output = File.ReadAllText(path);
            var projectData = JsonConvert.DeserializeObject<ProjectData>(output);
            var data = new TranslationData(projectData);
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