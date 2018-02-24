using TranslatorStudioClassLibrary.Exception;

namespace TranslatorStudioClassLibrary.Utilities
{
    /// <summary>
    /// Helper that contains commonly used exception methods.
    /// </summary>
    public static class ExceptionHelper
    {
        /// <summary>
        /// Creates a new empty raw exception.
        /// </summary>
        /// <returns>EmptyRawException to be thrown.</returns>
        public static EmptyRawException NewEmptyRawException()
        {
            string description = "No Raw Lines were submitted into the project.";

            return new EmptyRawException(description);
        }
        /// <summary>
        /// Creates a new removal of last line exception.
        /// </summary>
        /// <returns>RemovalOfLastLineException to be thrown.</returns>
        public static RemovalOfLastLineException NewRemovalOfLastLineException()
        {
            string description = "Cannot remove last line of the translation project.";

            return new RemovalOfLastLineException(description);
        }
    }
}
