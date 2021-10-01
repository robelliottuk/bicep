// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Bicep.Core.Configuration;
using Bicep.Core.Registry.Auth;
using Bicep.Core.RegistryClient;
using System;

namespace Bicep.Core.Registry
{
    public class ContainerRegistryClientFactory : IContainerRegistryClientFactory
    {
        private readonly ITokenCredentialFactory credentialFactory;

        public ContainerRegistryClientFactory(ITokenCredentialFactory credentialFactory)
        {
            this.credentialFactory = credentialFactory;
        }

        public BicepRegistryBlobClient CreateBlobClient(RootConfiguration configuration, Uri registryUri, string repository)
        {
            var options = new ContainerRegistryClientOptions();

            // ensure User-Agent mentions us
            options.Diagnostics.ApplicationId = $"{LanguageConstants.LanguageId}/{ThisAssembly.AssemblyFileVersion}";

            var credential = this.credentialFactory.CreateChain(configuration.Cloud.CredentialPrecedence);

            return new(registryUri, credential, repository, options);
        }
    }
}
