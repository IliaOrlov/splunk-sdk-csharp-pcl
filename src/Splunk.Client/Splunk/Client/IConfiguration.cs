namespace Splunk.Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading.Tasks;
    public interface IConfiguration<TConfigurationStanza> : IEntityCollection<TConfigurationStanza, Resource>
        where TConfigurationStanza : BaseEntity<Resource>, IConfigurationStanza, new()
    {
        /// <summary>
        /// Asynchronously creates a new configuration stanza.
        /// </summary>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/jae44k">POST
        /// properties/{file_name}</a> endpoint to create the configuration stanza
        /// identified by <paramref name="stanzaName"/>.
        /// </remarks>
        /// <param name="stanzaName">
        /// Name of the configuration stanza to create.
        /// </param>
        /// <returns>
        /// The new asynchronous.
        /// </returns>
        Task<TConfigurationStanza> CreateAsync(string stanzaName);

        /// <summary>
        /// Asynchronously retrieves a setting value from a configuration stanza.
        /// </summary>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/cqT50u">GET
        /// properties/{file_name}/{stanza_name}/{key_name}</a> endpoint to construct
        /// the setting value it returns.
        /// </remarks>
        /// <param name="stanzaName">
        /// Name of the configuration stanza.
        /// </param>
        /// <param name="keyName">
        /// Name of the setting to retrieve.
        /// </param>
        /// <returns>
        /// The value of the setting identified by <paramref name="keyName"/>.
        /// </returns>
        Task<string> GetSettingAsync(string stanzaName, string keyName);

        /// <summary>
        /// Asynchronously removes a configuration stanza.
        /// </summary>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/uMzr3F">DELETE configs/conf-
        /// {file}/{name}</a> endpoint to remove <paramref name= "stanzaName"/>.
        /// </remarks>
        /// <param name="stanzaName">
        /// Name of the configuration stanza to remove.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the operation.
        /// </returns>
        Task RemoveAsync(string stanzaName);

        /// <summary>
        /// Asynchronously updates a configuration stanza with new or revised
        /// settings.
        /// </summary>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/dpbuhQ">DELETE configs/conf-
        /// {file}/{name}</a> endpoint to remove the configuration stanza identified
        /// by <paramref name="stanzaName"/>.
        /// </remarks>
        /// <param name="stanzaName">
        /// Name of the configuration stanza to update.
        /// </param>
        /// <param name="settings">
        /// The new or updated settings.
        /// </param>
        /// <returns>
        /// An object representing the updated configuration stanza.
        /// </returns>
        Task<TConfigurationStanza> UpdateAsync(string stanzaName, params Argument[] settings);

        /// <summary>
        /// Asynchronously updates a setting within a configuration stanza.
        /// </summary>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/w742jw">POST
        /// properties/{file_name}/{stanza_name}</a> endpoint to update the setting
        /// identified by <paramref name="stanzaName"/> and
        /// <paramref name="keyName"/>.
        /// </remarks>
        /// <param name="stanzaName">
        /// Name of the configuration stanza containing the setting.
        /// </param>
        /// <param name="keyName">
        /// Name of the setting.
        /// </param>
        /// <param name="value">
        /// A value for <paramref name="keyName"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the operation.
        /// </returns>
        Task UpdateSettingAsync(string stanzaName, string keyName, object value);

        /// <inheritdoc cref="UpdateSettingAsync(string,string,object)"/>
        Task UpdateSettingAsync(string stanzaName, string keyName, string value);
    }
}
