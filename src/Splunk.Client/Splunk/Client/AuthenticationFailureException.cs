namespace Splunk.Client
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Net;
    using System.Net.Http;

    /// <summary>
    /// The exception that is thrown when invalid credentials are passed to
    /// <see cref="Service.LogOnAsync"/> or a request fails because the session
    /// timed out.
    /// </summary>
    /// <seealso cref="T:Splunk.Client.RequestException"/>
    [SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification =
        "This is by design.")
    ]
    public sealed class AuthenticationFailureException : RequestException
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="AuthenticationFailureException"/>
        /// class.
        /// </summary>
        /// <param name="message">
        /// An object representing an HTTP response message including the status code
        /// and data.
        /// </param>
        /// <param name="details">
        /// A sequence of <see cref="Message"/> instances detailing the cause of the
        /// <see cref="AuthenticationFailureException"/>.
        /// </param>
        internal AuthenticationFailureException(HttpResponseMessage message, ReadOnlyCollection<Message> details)
            : base(message, details)
        {
            if (!(message.StatusCode == HttpStatusCode.Unauthorized)) {  throw new ArgumentException("message", "message.StatusCode == HttpStatusCode.Unauthorized"); }
        }
    }
}
