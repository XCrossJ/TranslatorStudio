using Newtonsoft.Json;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudioClassLibrary.Utilities
{
    public static class ExtensionHelper
    {
        public static string ToJSONString(this IProjectData data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public static string GetNumberFormat(this int number)
        {
            string stringFormat = "";

            var digits = number.ToString().Length;

            for (int i = 0; i < digits; i++)
            {
                stringFormat += "0";
            }

            return stringFormat;
        }
    }
}
