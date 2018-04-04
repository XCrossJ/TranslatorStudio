using System;
using System.Runtime.Serialization;

namespace TranslatorStudioClassLibrary.Exception
{
    /// <summary>
    /// The exception that is thrown when the Raw provided to construct a translation project is empty or null.
    /// </summary>
    [Serializable]
    public class EmptyRawException : System.Exception
    {
        /// <summary>
        /// Initialises a new instance of the Exception.EmptyRawException class.
        /// </summary>
        public EmptyRawException()
        {
            
        }
        /// <summary>
        /// Initialises a new instance of the Exception.EmptyRawException class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public EmptyRawException(string message) : base(message)
        {

        }
        /// <summary>
        /// Initialises a new instance of the Exception.EmptyRawException class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified.</param>
        public EmptyRawException(string message, System.Exception inner)
            : base(message, inner)
        {

        }
        /// <summary>
        /// Initialises a new instance of the Exception.EmptyRawException class with serialised data.
        /// </summary>
        /// <param name="info">The System.Runtime.Serialization.SerializationInfo that holds the serialized
        /// object data about the exception being thrown.</param>
        /// <param name="context">The System.Runtime.Serialization.StreamingContext that contains contextual information 
        /// about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The info parameter is null.</exception>
        /// <exception cref="SerializationException">The class name is null or System.Exception.HResult is zero (0).</exception>
        protected EmptyRawException( SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
