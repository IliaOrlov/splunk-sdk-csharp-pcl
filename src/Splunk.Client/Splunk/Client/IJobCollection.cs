namespace Splunk.Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.Contracts;
    using System.Threading.Tasks;
    public interface IJobCollection<TJob> : IPaginated, IEntityCollection<TJob, Resource> 
        where TJob : BaseEntity<Resource>, IJob, new()
    {
        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="search">
        /// The search.
        /// </param>
        /// <param name="count">
        /// 
        /// </param>
        /// <param name="mode">
        ///                    
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        /// <param name="customArgs">
        /// The custom arguments.
        /// </param>
        /// <param name="requiredState">
        /// State of the required.
        /// </param>
        /// <returns>
        /// The new asynchronous.
        /// </returns>
        Task<TJob> CreateAsync(string search, int count = 0, ExecutionMode mode = ExecutionMode.Normal, 
            JobArgs args = null, CustomJobArgs customArgs = null, 
            DispatchState requiredState = DispatchState.Running);

        /// <summary>
        /// Gets slice asynchronous.
        /// </summary>
        /// <param name="criteria">
        /// The criteria.
        /// </param>
        /// <returns>
        /// The slice asynchronous.
        /// </returns>
        Task GetSliceAsync(JobCollection.Filter criteria);
    }
}
