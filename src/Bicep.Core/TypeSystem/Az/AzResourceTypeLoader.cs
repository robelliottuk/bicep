// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Azure.Bicep.Types.Az;

namespace Bicep.Core.TypeSystem.Az
{
    public class AzResourceTypeLoader : IAzResourceTypeLoader
    {
        private readonly ITypeLoader typeLoader;
        private readonly AzResourceTypeFactory resourceTypeFactory;
        private readonly ImmutableDictionary<string, TypeLocation> availableTypes;

        public AzResourceTypeLoader()
        {
            this.typeLoader = new TypeLoader();
            this.resourceTypeFactory = new AzResourceTypeFactory();
            this.availableTypes = typeLoader.GetIndexedTypes().Types.ToImmutableDictionary(StringComparer.OrdinalIgnoreCase);
        }

        public IEnumerable<string> GetAvailableTypes()
            => availableTypes.Keys;

        public ResourceType LoadType(string reference)
        {
            var typeLocation = availableTypes[reference];

            var serializedResourceType = typeLoader.LoadResourceType(typeLocation);
            return resourceTypeFactory.GetResourceType(serializedResourceType);
        }
    }
}
