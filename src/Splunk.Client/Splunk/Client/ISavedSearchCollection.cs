/*
 * Copyright 2014 Splunk, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"): you may
 * not use this file except in compliance with the License. You may obtain
 * a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 */

//// TODO:
//// [O] Contracts
//// [O] Documentation

﻿namespace Splunk.Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.Contracts;
    using System.Threading.Tasks;
    public interface ISavedSearchCollection<TSavedSearch> : IPaginated, IEntityCollection<TSavedSearch, Resource>
        where TSavedSearch : BaseEntity<Resource>, ISavedSearch, new()
    {
        /// <summary>
        /// Asynchronously creates a new saved search.
        /// </summary>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/EPQypw">POST
        /// saved/searches</a> endpoint to create the <see cref="SavedSearch"/>
        /// represented by the current instance.
        /// </remarks>
        /// <param name="name">
        /// Name of the saved search to be created.
        /// </param>
        /// <param name="search">
        /// A Splunk search command.
        /// </param>
        /// <param name="attributes">
        /// Attributes of the saved search to be created.
        /// </param>
        /// <param name="dispatchArgs">
        /// Dispatch arguments for the saved search to be created.
        /// </param>
        /// <param name="templateArgs">
        /// Template arguments for the saved search to be created.
        /// </param>
        /// <returns>
        /// The new asynchronous.
        /// </returns>
        Task<TSavedSearch> CreateAsync(string name, string search, SavedSearchAttributes attributes, 
            SavedSearchDispatchArgs dispatchArgs, SavedSearchTemplateArgs templateArgs);

        /// <summary>
        /// Asynchronously retrieves select entities in the current saved search
        /// entity collection.
        /// </summary>
        /// <remarks>
        /// Following completion of the operation the list of entities in the current
        /// saved search entity collection will contain all changes since the select
        /// entities were last retrieved.
        /// </remarks>
        /// <param name="criteria">
        /// The criteria.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the operation.
        /// </returns>
        Task GetSliceAsync(SavedSearchCollection.Filter criteria);
    }
}
