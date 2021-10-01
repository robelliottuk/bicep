// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System.Collections.Generic;

namespace Bicep.Core.TypeSystem.Az
{
    public interface IAzResourceTypeLoader
    {
        ResourceType LoadType(string reference);

        IEnumerable<string> GetAvailableTypes();
    }
}
