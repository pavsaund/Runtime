﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.Validation;

namespace Dolittle.Queries.Validation
{
    /// <summary>
    /// Defines a descriptor for describing the validation rules for a query.
    /// </summary>
    /// <remarks>
    /// Types inheriting from this interface and also <see cref="QueryValidationDescriptorFor{T}"/> will be automatically registered.
    /// </remarks>
    public interface IQueryValidationDescriptor
    {
        /// <summary>
        /// Gets the argument rules
        /// </summary>
        IEnumerable<IValueRule> ArgumentRules { get; }
    }
}
