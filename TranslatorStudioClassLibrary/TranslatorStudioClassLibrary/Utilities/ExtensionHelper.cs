using Newtonsoft.Json;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudioClassLibrary.Utilities
{
    /// <summary>
    /// Helper that houses commonly used extension methods
    /// </summary>
    public static class ExtensionHelper
    {
        /// <summary>
        /// Converts object to json string.
        /// </summary>
        /// <param name="data">Object to be serialised to json string.</param>
        /// <returns>JSON string.</returns>
        public static string ToJSONString(this object data)
        {
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// Obtains string format (number of digits) for certain number.
        /// </summary>
        /// <param name="number">The number to get string format from.</param>
        /// <returns>A string that contains the string format of the number.</returns>
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
