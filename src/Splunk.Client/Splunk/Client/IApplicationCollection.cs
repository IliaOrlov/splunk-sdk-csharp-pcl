namespace Splunk.Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.Contracts;
    using System.Threading.Tasks;
    public interface IApplicationCollection<TApplication> : IPaginated, IEntityCollection<TApplication, Resource> 
        where TApplication : BaseEntity<Resource>, IApplication, new()
    {
        /// <summary>
        /// Asynchronously creates a new Splunk application from a template.
        /// </summary>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/SzKzNX">POST apps/local</a>
        /// endpoint to create the current <see cref= "Application"/>.
        /// </remarks>
        /// <param name="name">
        /// Name of the application to be created.
        /// </param>
        /// <param name="template">
        /// Name of the template for the application to be created.
        /// </param>
        /// <param name="attributes">
        /// Optional attribute values for the application to be created.
        /// </param>
        /// <returns>
        /// An object representing the Splunk application created.
        /// </returns>
        Task<TApplication> CreateAsync(string name, string template, ApplicationAttributes attributes = null);

        /// <summary>
        /// Asynchronously retrieves select entities in the current application
        /// entity collection.
        /// </summary>
        /// <remarks>
        /// Following completion of the operation the list of entities in the current
        /// application entity collection will contain all changes since the select
        /// entities were last retrieved.
        /// </remarks>
        /// <param name="criteria">
        /// The criteria.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the operation.
        /// </returns>
        Task GetSliceAsync(ApplicationCollection.Filter criteria);

        /// <summary>
        /// Asynchronously installs an application from a Splunk application archive
        /// file.
        /// </summary>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/SzKzNX">POST apps/local</a>
        /// endpoint to install the application from the archive file on
        /// <paramref name="path"/>.
        /// </remarks>
        /// <param name="path">
        /// Specifies the location of a Splunk application archive file.
        /// </param>
        /// <param name="name">
        /// Optionally specifies an explicit name for the application. This value
        /// overrides the name of the application as specified in the archive file.
        /// </param>
        /// <param name="update">
        /// <c>true</c> if Splunk should allow the installation to update an existing
        /// application. The default value is <c>false</c>.
        /// </param>
        /// <returns>
        /// An object representing the installed application.
        /// </returns>
        Task<TApplication> InstallAsync(string path, string name = null, bool update = false);
    }
}
