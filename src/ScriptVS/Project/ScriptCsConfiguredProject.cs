using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.ProjectSystem;

namespace ScriptVS.Project
{
    [Export]
    [PartMetadata("Microsoft.VisualStudio.ProjectSystem.ProjectCapabilityRequired", Constants.ScriptCS)]
    public sealed class ScriptCsConfiguredProject
    {
        [Import]
        public ConfiguredProject ConfiguredProject { get; private set; }

        [Import]
        public Lazy<ProjectProperties> Properties { get; private set; }
    }
}