namespace Splunk.Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Net.Http;
    using System.Threading.Tasks;
    public interface IConfigurationStanza : IEntity, IReadOnlyList<ConfigurationSetting>
    {
        /// <summary>
        /// Gets the author of the current <see cref="ConfigurationStanza"/>.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        string Author { get; }

        /// <summary>
        /// Asynchronously retrieves a configuration setting value from the current
        /// <see cref="ConfigurationStanza"/>
        /// </summary>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/cqT50u">GET
        /// properties/{file_name}/{stanza_name}/{key_Name}</a> endpoint to construct
        /// the <see cref="ConfigurationSetting"/> identified by
        /// <paramref name="keyName"/>.
        /// </remarks>
        /// <param name="keyName">
        /// The name of a configuration setting.
        /// </param>
        /// <returns>
        /// The string value of <paramref name="keyName"/>.
        /// </returns>
        Task<string> GetAsync(string keyName);

        /// <summary>
        /// Asynchronously updates the value of an existing setting in the current
        /// <see cref="ConfigurationStanza"/>.
        /// </summary>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/sSzcMy">POST
        /// properties/{file_name}/{stanza_name}/{key_Name}</a> endpoint to update
        /// the <see cref="ConfigurationSetting"/> identified by
        /// <paramref name="keyName"/>.
        /// </remarks>
        /// <param name="keyName">
        /// The name of a configuration setting in the current
        /// <see cref= "ConfigurationStanza"/>.
        /// </param>
        /// <param name="value">
        /// A new value for the setting identified by <paramref name="keyName"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the operation.
        /// </returns>
        Task UpdateAsync(string keyName, object value);

        /// <inheritdoc/>
        Task UpdateAsync(string keyName, string value);
    }
}
