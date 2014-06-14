using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Microsoft.Collections.Immutable;
using Microsoft.VisualStudio.ProjectSystem;
using Microsoft.VisualStudio.ProjectSystem.Utilities;

namespace ScriptVS.Project
{
    [Export(typeof(IProjectCapabilitiesProvider))]
    [SupportsFileExtension(".csxproj")]
    public class CapabilitiesProvider : IProjectCapabilitiesProvider
    {
        private static readonly ImmutableHashSet<string> ProjectSystem = new[] { "ScriptCS", "ReferencesFolder", "CPS" };

        public Task<IEnumerable<string>> GetCapabilitiesAsync()
        {
            return Task.FromResult((IEnumerable<string>)ProjectSystem);
        }
    }
}