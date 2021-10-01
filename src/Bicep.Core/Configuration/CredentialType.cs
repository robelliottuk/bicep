// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Bicep.Core.Configuration
{
    /// <summary>
    /// Represents type of credential used for authentication when restoring external modules.
    /// </summary>
    public enum CredentialType
    {
        /// <summary>
        /// Enables authentication via specific AZURE_* environment variables.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/azure.identity.environmentcredential?view=azure-dotnet"/>
        /// </summary>
        Environment,

        /// <summary>
        /// Enables authentication via a managed identity configured in the deployment environment.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/azure.identity.managedidentitycredential?view=azure-dotnet"/>
        /// </summary>
        ManagedIdentity,

        /// <summary>
        /// Enables authentication via Visual Studio account sign-in.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/azure.identity.visualstudiocredential?view=azure-dotnet"/>
        /// </summary>
        VisualStudio,

        /// <summary>
        /// Enables authentication via Visual Studio Code sign-in.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/azure.identity.visualstudiocodecredential?view=azure-dotnet"/>
        /// </summary>
        VisualStudioCode,

        /// <summary>
        /// Enables authentication via token obtained from Azure CLI.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/azure.identity.azureclicredential?view=azure-dotnet"/>
        /// </summary>
        AzureCLI,

        /// <summary>
        /// Enables authentication via token obtained from Azure PowerShell.
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/azure.identity.azurepowershellcredential?view=azure-dotnet"/>
        /// </summary>
        AzurePowerShell,

        /// <summary>
        /// Enables our clients to make requests to unauthenticated module registries.
        /// <see cref=""/>
        /// </summary>
        Anonymous
    }
}
