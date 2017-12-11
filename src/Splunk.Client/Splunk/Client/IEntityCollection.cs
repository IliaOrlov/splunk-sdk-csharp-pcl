namespace Splunk.Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading.Tasks;
    public interface IEntityCollection<TEntity, TResource> : IReadOnlyList<TEntity> 
        where TEntity : BaseEntity<TResource>, new()
        where TResource : BaseResource, new()
    {
        /// <summary>
        /// Asynchronously retrieves a <see cref="Entity&lt;TResource&gt;"/> in the current
        /// <see cref="EntityCollection&lt;TEntity,TResource&gt;"/> by name.
        /// </summary>
        /// <param name="name">
        /// Name of the entity to retrieve.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the operation.
        /// </returns>
        Task<TEntity> GetAsync(string name);

        /// <summary>
        /// Asynchronously retrieves a fresh copy of the full list of entities in the
        /// current <see cref="EntityCollection&lt;TEntity,TResource&gt;"/>.
        /// </summary>
        /// <remarks>
        /// Following completion of the operation the list of entites in the current
        /// <see cref="EntityCollection&lt;TEntity,TResource&gt;"/> will contain all changes
        /// since the list was last retrieved.
        /// </remarks>
        /// <returns>
        /// A <see cref="Task"/> representing the operation.
        /// </returns>
        Task GetAllAsync();

        /// <summary>
        /// Asynchronously retrieves select entities from the list of entites in the
        /// current <see cref="EntityCollection&lt;TEntity,TResource&gt;"/>.
        /// </summary>
        /// <remarks>
        /// Following completion of the operation the list of entities in the current
        /// <see cref="EntityCollection&lt;TEntity,TResource&gt;"/> will contain all changes
        /// since the select entites were last retrieved.
        /// </remarks>
        /// <param name="arguments">
        /// The arguments.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the operation.
        /// </returns>
        Task GetSliceAsync(params Argument[] arguments);

        /// <summary>
        /// Asynchronously retrieves select entities from the list of entites in the
        /// current <see cref="EntityCollection&lt;TEntity,TResource&gt;"/>.
        /// </summary>
        /// <remarks>
        /// Following completion of the operation the list of entities in the current
        /// <see cref="EntityCollection&lt;TEntity,TResource&gt;"/> will contain all changes
        /// since the select entites were last retrieved.
        /// </remarks>
        /// <param name="arguments">
        /// The arguments.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the operation.
        /// </returns>
        Task GetSliceAsync(IEnumerable<Argument> arguments);

        /// <summary>
        /// Asynchronously forces the Splunk server to reload data for the current
        /// <see cref="EntityCollection&lt;TEntity,TResource&gt;"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> representing the operation.
        /// </returns>
        Task ReloadAsync();
    }
}
