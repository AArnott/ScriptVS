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
    [SupportsFileExtension(Constants.csxprojExtensionWithDot)]
    [ProjectTypeRegistration(
        projectTypeGuid: Constants.ProjectTypeGuid,
        displayName: Constants.ScriptCS,
        displayProjectFileExtensions: Constants.csxprojProjectFileExtension,
        defaultProjectExtension: Constants.csxprojExtension,
        language: Constants.ScriptCS,
        PossibleProjectExtensions = Constants.csxprojExtension,
        LanguageVsTemplate = Constants.ScriptCS)]
    public class CapabilitiesProvider : IProjectCapabilitiesProvider
    {
        private static readonly ImmutableHashSet<string> ProjectSystem = new[]
        {
            Constants.ScriptCS,
            ProjectCapabilities.ProjectReferences,
            ProjectCapabilities.Cps
        };

        public Task<IEnumerable<string>> GetCapabilitiesAsync()
        {
            return Task.FromResult((IEnumerable<string>)ProjectSystem);
        }
    }
}