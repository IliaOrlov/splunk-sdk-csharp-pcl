namespace Splunk.Client
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Net;
    using System.Net.Http;

    /// <summary>
    /// The exception that is thrown when a request is rejected by Splunk because
    /// it is poorly formed.
    /// </summary>
    /// <seealso cref="T:Splunk.Client.RequestException"/>
    [SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification =
        "This is by design.")
    ]
    public sealed class BadRequestException : RequestException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/>
        /// class.
        /// </summary>
        /// <param name="message">
        /// An object representing an HTTP response message including the status code
        /// and data.
        /// </param>
        /// <param name="details">
        /// A sequence of <see cref="Message"/> instances detailing the cause of the
        /// <see cref="BadRequestException"/>.
        /// </param>
        internal BadRequestException(HttpResponseMessage message, ReadOnlyCollection<Message> details)
            : base(message, details)
        {
            if (!(message.StatusCode == HttpStatusCode.BadRequest)) {  throw new ArgumentException("message", "message.StatusCode == HttpStatusCode.BadRequest"); }
        }
    }
}
