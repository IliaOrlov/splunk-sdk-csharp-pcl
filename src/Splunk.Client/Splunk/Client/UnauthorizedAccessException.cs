namespace Splunk.Client
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Net;
    using System.Net.Http;

    /// <summary>
    /// The exception that is thrown when a request to access a resource results
    /// in <see cref="HttpStatusCode.Forbidden"/>.
    /// </summary>
    /// <seealso cref="T:Splunk.Client.RequestException"/>
    [SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification =
        "This is by design.")
    ]
    public sealed class UnauthorizedAccessException : RequestException
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="UnauthorizedAccessException"/>
        /// class.
        /// </summary>
        /// <param name="message">
        /// An object representing an HTTP response message including the status code
        /// and data.
        /// </param>
        /// <param name="details">
        /// A sequence of <see cref="Message"/> instances detailing the cause of the
        /// <see cref="UnauthorizedAccessException"/>.
        /// </param>
        internal UnauthorizedAccessException(HttpResponseMessage message, ReadOnlyCollection<Message> details)
            : base(message, details)
        {
            if (!(message.StatusCode == HttpStatusCode.Forbidden)) {  throw new ArgumentException("message", "message.StatusCode == HttpStatusCode.Forbidden"); }
        }
    }
}
