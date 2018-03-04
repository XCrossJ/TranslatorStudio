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
        public static EmptyRawException NewEmptyRawException
        {
            get
            {
                string description = "No Raw Lines were submitted into the project.";

                return new EmptyRawException(description);
            }
        }

        /// <summary>
        /// Creates a new removal of last line exception.
        /// </summary>
        /// <returns>RemovalOfLastLineException to be thrown.</returns>
        public static RemovalOfLastLineException NewRemovalOfLastLineException
        {
            get
            {
                string description = "Cannot remove last line of the translation project.";

                return new RemovalOfLastLineException(description);
            }
        }

        /// <summary>
        /// Creates a new invalid condition list exception for empty condition list.
        /// </summary>
        /// <returns>RemovalOfLastLineException to be thrown.</returns>
        public static InvalidConditionListException NewInvalidConditionListException_Empty
        {
            get
            {
                string description = "Passed Condition List is Empty.";

                return new InvalidConditionListException(description);
            }
        }

        /// <summary>
        /// Creates a new invalid condition list exception for when condition list obtains no results.
        /// </summary>
        /// <returns>RemovalOfLastLineException to be thrown.</returns>
        public static InvalidConditionListException NewInvalidConditionListException_NoResults
        {
            get
            {
                string description = "Condition list retrieved no indices.";

                return new InvalidConditionListException(description);
            }
        }
    }
}
