using System;
using System.Net.Http;
using System.Runtime.Serialization;

namespace HttpRecorder
{
    /// <summary>
    /// Represents errors that occurs when an <see cref="InteractionMessage" /> is not found.
    /// </summary>
    [Serializable]
    public class InteractionMessageNotFoundException : HttpRecorderException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionMessageNotFoundException" /> class.
        /// </summary>
        public InteractionMessageNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionMessageNotFoundException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InteractionMessageNotFoundException(string message)
          : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionMessageNotFoundException" /> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The <see cref="Exception" /> that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public InteractionMessageNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionMessageNotFoundException" /> class with an
        /// reference to the <see cref="HttpRequestMessage" /> that has no matching <see cref="InteractionMessage" />.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage" /> that has no matching <see cref="InteractionMessage" />.</param>
        public InteractionMessageNotFoundException(HttpRequestMessage request)
            : this($"Unable to find a matching interaction for request {request.Method} {request.RequestUri}.")
        {
            this.Request = request;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionMessageNotFoundException" /> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected InteractionMessageNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Gets the <see cref="HttpRequestMessage" /> that has no matching <see cref="InteractionMessage" />.
        /// </summary>
        public HttpRequestMessage Request { get; }
    }
}
