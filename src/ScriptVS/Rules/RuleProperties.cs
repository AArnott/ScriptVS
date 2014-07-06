using System.ComponentModel.Composition;
using Microsoft.VisualStudio.ProjectSystem;
using Microsoft.VisualStudio.ProjectSystem.Properties;
using Microsoft.VisualStudio.ProjectSystem.Utilities;

namespace ScriptVS.Rules
{
    [Export]
    [PartMetadata(ProjectCapabilities.Requires, ProjectCapabilities.CSharp)]
    internal partial class RuleProperties : StronglyTypedPropertyAccess
    {
        [ImportingConstructor]
        public RuleProperties(
            [Import(RequiredCreationPolicy = CreationPolicy.Shared)] ConfiguredProject configuredProject)
            : base(configuredProject)
        {
        }

        public RuleProperties(ConfiguredProject configuredProject, string file, string itemType, string itemName)
            : base(configuredProject, file, itemType, itemName)
        {
        }

        public RuleProperties(ConfiguredProject configuredProject, IProjectPropertiesContext projectPropertiesContext)
            : base(configuredProject, projectPropertiesContext)
        {
        }

        public RuleProperties(ConfiguredProject configuredProject, UnconfiguredProject unconfiguredProject)
            : base(configuredProject, unconfiguredProject)
        {
        }
    }
}