// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Linq;
using Bicep.Core.Resources;

namespace Bicep.Core.TypeSystem
{
    public class EmptyResourceTypeProvider : IResourceTypeProvider
    {
        public IEnumerable<string> GetAvailableTypes()
            => Enumerable.Empty<string>();

        public ResourceType? TryGetDefinedType(string reference, ResourceTypeGenerationFlags flags)
            => null;

        public ResourceType? TryGenerateDefaultType(string reference, ResourceTypeGenerationFlags flags)
            => null;

        public bool HasDefinedType(string typeReference)
            => false;
    }
}
