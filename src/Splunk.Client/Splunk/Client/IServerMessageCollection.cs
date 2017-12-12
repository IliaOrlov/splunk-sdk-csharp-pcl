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
    public interface IServerMessageCollection<TServerMessage> : IPaginated, IEntityCollection<TServerMessage, Resource>
        where TServerMessage : BaseEntity<Resource>, IServerMessage, new()
    {
        /// <summary>
        /// Asyncrhonously creates a new <see cref="ServerMessage"/>.
        /// </summary>
        /// <param name="name">
        /// Name of the server message to create.
        /// </param>
        /// <param name="type">
        /// The severity of the server message.
        /// </param>
        /// <param name="text">
        /// The text of the server message.
        /// </param>
        /// <returns>
        /// An object representing the newly created server message.
        /// </returns>
        Task<TServerMessage> CreateAsync(string name, ServerMessageSeverity type, string text);

        /// <summary>
        /// Asynchronously retrieves select entities from the list of entites in the
        /// current <see cref="ServerMessageCollection"/>.
        /// </summary>
        /// <remarks>
        /// Following completion of the operation the list of entities in the current
        /// <see cref="ServerMessageCollection"/> will contain all changes since the
        /// select entites were last retrieved.
        /// </remarks>
        /// <param name="criteria">
        /// The criteria.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the operation.
        /// </returns>
        Task GetSliceAsync(ServerMessageCollection.Filter criteria);
    }
}
