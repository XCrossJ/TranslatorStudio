using Newtonsoft.Json;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudioClassLibrary.Utilities
{
    public static class ExtensionHelper
    {
        /// <summary>
        /// To Json String:
        ///     converts project data to json string.
        /// </summary>
        /// <param name="data">IProjectData: object that implements Project Data interface.</param>
        /// <returns>string: JSON string.</returns>
        public static string ToJSONString(this IProjectData data)
        {
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// Get Number Format:
        ///     obtains string format (number of digits) for certain number.
        /// </summary>
        /// <param name="number">int: the number to get string format from.</param>
        /// <returns>string: a string that contains the string format of the number.</returns>
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
