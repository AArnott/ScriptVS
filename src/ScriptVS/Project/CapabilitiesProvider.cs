using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Microsoft.Collections.Immutable;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.ProjectSystem;
using Microsoft.VisualStudio.ProjectSystem.Utilities;

namespace ScriptVS.Project
{
    [Export(typeof(IProjectCapabilitiesProvider))]
    [SupportsFileExtension(Constants.csxprojExtensionWithDot)]
    [ProjectTypeRegistration(
        projectTypeGuid: "{262852C6-CD72-467D-83FE-5EEB1973A190}",//Constants.CsharpProjectTypeGuid, // this is required for NuGet support!
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
        };

        public async Task<IEnumerable<string>> GetCapabilitiesAsync()
        {
            return ProjectSystem;
        }
    }
}
