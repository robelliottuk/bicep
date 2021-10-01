// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using Bicep.Core.Extensions;
using Bicep.Core.TypeSystem;

namespace Bicep.Core.Resources
{
    public class ResourceTypeReference
    {
        private const string TypeSegmentPattern = "[a-z0-9][a-z0-9-.]*";
        private const string VersionPattern = "[a-z0-9][a-z0-9-]+";

        private const RegexOptions PatternRegexOptions = RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled | RegexOptions.CultureInvariant;
        private static readonly Regex ResourceTypePattern = new Regex(@$"^(?<type>{TypeSegmentPattern})(/(?<type>{TypeSegmentPattern}))*@(?<version>{VersionPattern})?", PatternRegexOptions);

        public ResourceTypeReference(NamespaceType declaringNamespace, ImmutableArray<string> typeSegments, string? version)
        {
            if (typeSegments.Length <= 0)
            {
                throw new ArgumentException("At least one type must be specified.");
            }

            DeclaringNamespace = declaringNamespace;
            TypeSegments = typeSegments;
            Version = version;
        }

        public string FormatName()
            => $"{FormatType()}{(this.Version == null ? "" : $"@{this.Version}")}";

        public string FormatType()
            => string.Join('/', this.TypeSegments);

        public NamespaceType DeclaringNamespace { get; }

        public ImmutableArray<string> TypeSegments { get; }

        public string? Version { get; }

        public bool IsParentOf(ResourceTypeReference other)
        {
            // Parent should have N types, child should have N+1, first N types should be equal
            return 
                object.ReferenceEquals(this.DeclaringNamespace, other.DeclaringNamespace) &&
                this.TypeSegments.Length + 1 == other.TypeSegments.Length &&
                Enumerable.SequenceEqual(this.TypeSegments, other.TypeSegments.Take(this.TypeSegments.Length), StringComparer.OrdinalIgnoreCase);
        }

        public static bool TryParse(string resourceType, out ImmutableArray<string> types, out string? version)
        {
            var match = ResourceTypePattern.Match(resourceType);
            if (match.Success == false)
            {
                types = default;
                version = null;
                return false;
            }

            types = match.Groups["type"].Captures.Cast<Capture>()
                .Select(c => c.Value)
                .ToImmutableArray();
            version = match.Groups["version"].Value;
            return true;
        }

        public static bool IsNamespaceAndTypeSegment(string segment)
        {
            return ResourceTypePattern.Match(segment).Success;
        }
    }
}
