namespace Splunk.Client
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Net.Http;
    using System.Threading.Tasks;
    public interface IStoragePassword : IEntity
    {
        #region Properties

        /// <summary>
        /// Gets the plain text version of the current <see cref= "StoragePassword"/>.
        /// </summary>
        /// <value>
        /// The clear password.
        /// </value>
        string ClearPassword
        { get; }

        /// <summary>
        /// Gets the extensible administration interface properties for the current
        /// <see cref= "StoragePassword"/>.
        /// </summary>
        /// <value>
        /// The extensible administration interface properties.
        /// </value>
        Eai Eai
        { get; }

        /// <summary>
        /// Gets an encrypted version of the current <see cref= "StoragePassword"/>.
        /// </summary>
        /// <value>
        /// The encrypted password.
        /// </value>
        string EncryptedPassword
        { get; }

        /// <summary>
        /// Gets the masked version of the current <see cref="StoragePassword"/>.
        /// </summary>
        /// <remarks>
        /// This is always stored as <c>"********"</c>.
        /// </remarks>
        /// <value>
        /// The password.
        /// </value>
        string Password
        { get; }

        /// <summary>
        /// Gets the realm in which the current <see cref="StoragePassword"/>
        /// is valid.
        /// </summary>
        /// <value>
        /// The realm.
        /// </value>
        string Realm
        { get; }

        /// <summary>
        /// Gets the Splunk username associated with the current
        /// <see cref= "StoragePassword"/>.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        string Username
        { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Asynchronously updates the storage password represented by the current
        /// instance.
        /// </summary>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/s0Bw7H">POST
        /// storage/passwords/{name}</a> endpoint to update the storage password
        /// represented by the current instance.
        /// </remarks>
        ///
        /// <exception cref="ArgumentNullException">
        /// <paramref name="password"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="RequestException">
        /// 
        /// </exception>
        /// <exception cref="ResourceNotFoundException">
        /// 
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">
        /// 
        /// </exception>
        /// <param name="password">
        /// New storage password.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the operation.
        /// </returns>
        Task UpdateAsync(string password);

        #endregion
    }
}
