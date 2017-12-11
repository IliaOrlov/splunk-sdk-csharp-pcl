namespace Splunk.Client
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.Contracts;
    using System.Threading.Tasks;
    using System.Xml;

    /// <summary>
    /// Represents a search result preview on a <see cref="SearchPreviewStream"/>.
    /// </summary>
    public class SearchPreview
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating whether this <see cref="SearchPreview"/>
        /// contains the final results from a search job.
        /// </summary>
        /// <value>
        /// <c>true</c> if this object is final, <c>false</c> if not.
        /// </value>
        public bool IsFinal
        {
            get { return this.metadata.IsFinal; }
        }

        /// <summary>
        /// Gets the read-only list of field names that may appear in a
        /// <see cref="SearchResult"/>.
        /// </summary>
        /// <remarks>
        /// Be aware that any given result will contain a subset of these fields.
        /// </remarks>
        /// <value>
        /// A list of names of the fields.
        /// </value>
        public ReadOnlyCollection<string> FieldNames
        {
            get { return this.metadata.FieldNames; }
        }

        /// <summary>
        /// Gets the read-only list of field names that may appear in a search event
        /// <see cref="SearchResult"/>.
        /// </summary>
        /// <remarks>
        /// Be aware that any given result will contain a subset of these fields.
        /// </remarks>
        /// <value>
        /// The results.
        /// </value>
        public ReadOnlyCollection<SearchResult> Results
        { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Asynchronously reads data into the current <see cref="SearchPreview"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="XmlReader"/> from which to read.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the operation.
        /// </returns>
        public async Task ReadXmlAsync(XmlReader reader)
        {
            if (reader == null) {  throw new ArgumentNullException("reader", "reader != null"); }

            //// Intitialize data members
            
            this.metadata = new SearchResultMetadata();
            await metadata.ReadXmlAsync(reader).ConfigureAwait(false);

            var results = new List<SearchResult>();
            this.Results = new ReadOnlyCollection<SearchResult>(results);

            //// Read the search preview

            while (!(reader.NodeType == XmlNodeType.EndElement && reader.Name == "results"))
            {
                var result = new SearchResult(this.metadata);

                await result.ReadXmlAsync(reader).ConfigureAwait(false);
                results.Add(result);
                await reader.ReadAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Gets a string representation of the current instance.
        /// </summary>
        /// <returns>
        /// A string instance representing the current instance.
        /// </returns>
        /// <seealso cref="M:System.Object.ToString()"/>
        public override string ToString()
        {
            return base.ToString();
        }

        #endregion

        #region Privates/internals

        SearchResultMetadata metadata;

        #endregion
    }
}
