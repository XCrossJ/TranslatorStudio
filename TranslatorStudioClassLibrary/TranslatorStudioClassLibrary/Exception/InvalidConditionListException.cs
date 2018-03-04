using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorStudioClassLibrary.Exception
{
    /// <summary>
    /// The exception that is thrown when the condition list provided to construct sub translation data is empty or invalid.
    /// </summary>
    [Serializable]
    public class InvalidConditionListException : System.Exception
    {
        /// <summary>
        /// Initialises a new instance of the Exception.InvalidConditionListException class.
        /// </summary>
        public InvalidConditionListException()
        {

        }
        /// <summary>
        /// Initialises a new instance of the Exception.InvalidConditionListException class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public InvalidConditionListException(string message) : base(message)
        {

        }
        /// <summary>
        /// Initialises a new instance of the Exception.InvalidConditionListException class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified.</param>
        public InvalidConditionListException(string message, System.Exception inner)
            : base(message, inner)
        {

        }
        /// <summary>
        /// Initialises a new instance of the Exception.InvalidConditionListException class with serialised data.
        /// </summary>
        /// <param name="info">The System.Runtime.Serialization.SerializationInfo that holds the serialized
        /// object data about the exception being thrown.</param>
        /// <param name="context">The System.Runtime.Serialization.StreamingContext that contains contextual information 
        /// about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The info parameter is null.</exception>
        /// <exception cref="SerializationException">The class name is null or System.Exception.HResult is zero (0).</exception>
        protected InvalidConditionListException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
