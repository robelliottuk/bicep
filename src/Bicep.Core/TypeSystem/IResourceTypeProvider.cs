// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System.Collections.Generic;
using Bicep.Core.Resources;

namespace Bicep.Core.TypeSystem
{
    public interface IResourceTypeProvider
    {
        /// <summary>
        /// Tries to get a resource type from the set of well known resource types. Returns null if none is available.
        /// </summary>
        ResourceType? TryGetDefinedType(string typeName, ResourceTypeGenerationFlags flags);

        /// <summary>
        /// Tries to generate a default resource type definition, if possible. Returns null if this is not possible.
        /// </summary>
        ResourceType? TryGenerateDefaultType(string typeName, ResourceTypeGenerationFlags flags);

        /// <summary>
        /// Checks whether the type exists in the set of well known resource types.
        /// </summary>
        bool HasDefinedType(string typeName);

        /// <summary>
        /// Returns the full list of available types defined by this provider.
        /// </summary>
        IEnumerable<string> GetAvailableTypes();
    }
}
