using Newtonsoft.Json;

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
        /// <returns>JSON string of serialised object.</returns>
        public static string ToJSONString(this object data)
        {
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// Checks whether text is not empty, null, or whitespace.
        /// </summary>
        /// <param name="text">Text to check.</param>
        /// <returns>Result of empty check.</returns>
        public static bool IsNotWhiteSpace(this string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }
    }
}
