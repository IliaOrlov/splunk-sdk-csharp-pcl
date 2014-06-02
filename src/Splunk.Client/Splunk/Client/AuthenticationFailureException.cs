﻿/*
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
//// [X] Documentation

namespace Splunk.Client
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;

    /// <summary>
    /// The exception that is thrown when invalid credentials are passed to
    /// <see cref="Service.LoginAsync"/> or a request fails because the session 
    /// timed out.
    /// </summary>
    public sealed class AuthenticationFailureException : RequestException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationFailureException"/>
        /// class.
        /// </summary>
        /// <param name="message">
        /// An object representing an HTTP response message including the status
        /// code and data.
        /// </param>
        /// <param name="details">
        /// A sequence of <see cref="Message"/> instances detailing the cause
        /// of the <see cref="AuthenticationFailureException"/>.
        /// </param>
        internal AuthenticationFailureException(HttpResponseMessage message, IEnumerable<Message> details)
            : base(message, details)
        {
            Debug.Assert(message.StatusCode == HttpStatusCode.Unauthorized);
        }
    }
}
