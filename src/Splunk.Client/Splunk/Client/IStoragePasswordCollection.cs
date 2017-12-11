namespace Splunk.Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.Contracts;
    using System.Threading.Tasks;
    public interface IStoragePasswordCollection<TStoragePassword> : IPaginated, IEntityCollection<TStoragePassword, Resource>
        where TStoragePassword : BaseEntity<Resource>, IStoragePassword, new()
    {
        /// <summary>
        /// Asynchronously creates a new <see cref="StoragePassword"/>.
        /// </summary>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/JgyIeN">POST
        /// storage/passwords</a> endpoint to create a <see cref= "StoragePassword"/>
        /// identified by <paramref name="username"/> and <paramref name="realm"/>.
        /// </remarks>
        /// <param name="password">
        /// Password to be stored.
        /// </param>
        /// <param name="username">
        /// The username associated with the password to be stored.
        /// </param>
        /// <param name="realm">
        /// Optional domain or realm name associated with the password to be stored.
        /// </param>
        /// <returns>
        /// The new asynchronous.
        /// </returns>
        Task<TStoragePassword> CreateAsync(string password, string username, string realm = null);

        /// <summary>
        /// Asynchronously retrieves a <see cref="StoragePassword"/>.
        /// </summary>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/HL3c0T">GET
        /// storage/passwords/{name}</a> endpoint to retrieve the
        /// <see cref= "StoragePassword"/> identified by <paramref name="username"/>
        /// and
        /// <paramref name="realm"/>.
        /// </remarks>
        /// <param name="username">
        /// The username associated with the password to be retrieved.
        /// </param>
        /// <param name="realm">
        /// Optional domain or realm name associated with the password to be
        /// retrieved.
        /// </param>
        /// <returns>
        /// An object representing the storage password retrieved.
        /// </returns>
        Task<TStoragePassword> GetAsync(string username, string realm = null);

        /// <summary>
        /// Asynchronously retrieves a <see cref="StoragePassword"/>.
        /// </summary>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/HL3c0T">GET
        /// storage/passwords/{name}</a> endpoint to retrieve the
        /// <see cref= "StoragePassword"/> identified by <paramref name="username"/>
        /// and
        /// <paramref name="realm"/>.
        /// </remarks>
        /// <param name="username">
        /// The username associated with the password to be retrieved.
        /// </param>
        /// <param name="realm">
        /// Optional domain or realm name associated with the password to be
        /// retrieved.
        /// </param>
        /// <returns>
        /// An object representing the storage password retrieved or <c>null</c>, if
        /// no such storage password exists.
        /// </returns>
        Task<TStoragePassword> GetOrNullAsync(string username, string realm = null);

        /// <summary>
        /// Asynchronously retrieves select storage passwords from Splunk.
        /// </summary>
        /// <param name="criteria">
        /// Specifies the criteria used in selecting storage passwords.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the operation.
        /// </returns>
        Task GetSliceAsync(StoragePasswordCollection.Filter criteria);
    }
}
