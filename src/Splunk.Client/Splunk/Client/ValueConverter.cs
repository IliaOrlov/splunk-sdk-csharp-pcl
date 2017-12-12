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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.IO;
    public abstract class ValueConverter<TValue>
    {
        #region Properties

        /// <summary>
        /// Gets the default value.
        /// </summary>
        /// <value>
        /// The default value.
        /// </value>
        public virtual TValue DefaultValue
        { 
            get { return default(TValue); } 
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts the given input.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// A TValue.
        /// </returns>
        public abstract TValue Convert(object input);

        /// <summary>
        /// Creates a new invalid data exception.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// An InvalidDataException.
        /// </returns>
        protected static InvalidDataException NewInvalidDataException(object input)
        {
            var text = string.Format(CultureInfo.CurrentCulture, "Expected {0} value: {1}", TypeName, input);
            return new InvalidDataException(text);
        }

        #endregion

        /// <summary>
        /// The comparer.
        /// </summary>
        protected static readonly EqualityComparer<TValue> Comparer = EqualityComparer<TValue>.Default;

        /// <summary>
        /// Name of the type.
        /// </summary>
        protected static readonly string TypeName = typeof(TValue).Name;
    }
}
