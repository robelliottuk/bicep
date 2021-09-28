// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Azure.Containers.ContainerRegistry;
using Azure.Containers.ContainerRegistry.Specialized;
using Azure.Core;
using System;

namespace Bicep.Core.Registry
{
    public class ContainerRegistryClientFactory : IContainerRegistryClientFactory
    {
        public ContainerRegistryBlobClient CreateBlobClient(Uri registryUri, string repository, TokenCredential credential)
        {
            var options = new ContainerRegistryClientOptions();

            // ensure User-Agent mentions us
            options.Diagnostics.ApplicationId = $"{LanguageConstants.LanguageId}/{ThisAssembly.AssemblyFileVersion}";

            // TODO: Add support for national clouds
            options.Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud;

            return new(registryUri, credential, repository, options);
        }
    }
}
