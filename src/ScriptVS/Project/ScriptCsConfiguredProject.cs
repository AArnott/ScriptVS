using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.ProjectSystem;
using Microsoft.VisualStudio.ProjectSystem.Utilities;

namespace ScriptVS.Project
{
    [Export]
    [PartMetadata(ProjectCapabilities.Requires, Constants.ScriptCS)]
    public sealed class ScriptCsConfiguredProject
    {
        [Import]
        public ConfiguredProject ConfiguredProject { get; private set; }

        [Import]
        public Lazy<ProjectProperties> Properties { get; private set; }
    }
}