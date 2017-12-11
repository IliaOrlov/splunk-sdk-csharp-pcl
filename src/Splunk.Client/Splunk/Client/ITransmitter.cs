namespace Splunk.Client
{
    using System;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Threading.Tasks;
    public interface ITransmitter
    {
        /// <summary>
        /// Asynchronously sends a stream of raw events to Splunk.
        /// </summary>
        /// <remarks>
        /// This method the <a href="http://goo.gl/zFKzMp">POST receivers/stream</a>
        /// endpoint to send raw events to Splunk as they become available on
        /// <paramref name="eventStream"/>.
        /// </remarks>
        /// <param name="eventStream">
        /// The event stream.
        /// </param>
        /// <param name="indexName">
        /// Name of the index.
        /// </param>
        /// <param name="args">
        /// Arguments identifying the event type and destination.
        /// </param>
        /// <returns>
        /// A <see cref="Stream"/> used to send events to Splunk.
        /// </returns>
        Task SendAsync(Stream eventStream, string indexName = null, TransmitterArgs args = null);

        /// <summary>
        /// Asynchronously sends a single raw event to Splunk.
        /// </summary>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/GPLUVg">POST
        /// receivers/simple</a> endpoint to obtain the <see cref= "SearchResult"/>
        /// that it returns.
        /// </remarks>
        /// <param name="eventText">
        /// Raw event text.
        /// </param>
        /// <param name="indexName">
        /// Name of the index.
        /// </param>
        /// <param name="args">
        /// Arguments identifying the event type and destination.
        /// </param>
        /// <returns>
        /// An object representing the event created by Splunk.
        /// </returns>
        Task<SearchResult> SendAsync(string eventText, string indexName = null, TransmitterArgs args = null);
    }

}
