namespace Splunk.Client
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;

    /// <summary>
    /// The expception that is thrown when a Splunk service request fails.
    /// </summary>
    /// <seealso cref="T:System.Exception"/>
    [SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification =
        "This is by design.")
    ]
    public class RequestException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestException"/>
        /// class.
        /// </summary>
        /// <param name="message">
        /// An object representing an HTTP response message including the status code
        /// and data.
        /// </param>
        /// <param name="details">
        /// A sequence of <see cref="Message"/> instances detailing the cause of the
        /// <see cref="RequestException"/>.
        /// </param>
        protected internal RequestException(HttpResponseMessage message, ReadOnlyCollection<Message> details)
            : base(FormatMessageText(message, details))
        {
            if (message == null) {  throw new ArgumentNullException("message", "message != null"); }

            this.StatusCode = message.StatusCode;
            this.Details = details ?? NoDetails;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the list of Splunk messages detailing the cause of the current
        /// <see cref="RequestException"/>.
        /// </summary>
        /// <remarks>
        /// This list may be empty. Splunk does not provide <c>Details</c> all of the
        /// time.
        /// </remarks>
        /// <value>
        /// The details.
        /// </value>
        public ReadOnlyCollection<Message> Details
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="HttpStatusCode"/> for the current
        /// <see cref= "RequestException"/>.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        public HttpStatusCode StatusCode
        { get; private set; }

        #endregion

        #region Privates/internals

        static readonly ReadOnlyCollection<Message> NoDetails = new ReadOnlyCollection<Message>(new Message[0]);

        static string FormatMessageText(HttpResponseMessage message, IEnumerable<Message> details)
        {
            StringBuilder builder = new StringBuilder(1024);

            if (message.IsSuccessStatusCode)
            {
                if (details != null)
                {
                    foreach (var detail in details)
                    {
                        builder.Append(detail);
                        builder.Append('\n');
                    }
                    builder.Length = builder.Length - 1;
                }

                return builder.ToString();
            }

            builder.Append((int)message.StatusCode);
            builder.Append(": ");
            builder.Append(message.ReasonPhrase);

            if (details != null)
            {
                foreach (var detail in details)
                {
                    builder.Append("\n  ");
                    builder.Append(detail);
                }
            }

            return builder.ToString();
        }

        #endregion
    }
}
