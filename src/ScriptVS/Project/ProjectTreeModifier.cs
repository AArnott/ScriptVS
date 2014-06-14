using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.ProjectSystem.Designers;
using ScriptVS.Properties;

namespace ScriptVS.Project
{
    [Export(typeof(IProjectTreeModifier))]
    [PartMetadata("Microsoft.VisualStudio.ProjectSystem.ProjectCapabilityRequired", Constants.ScriptCS)]
    public sealed class ProjectTreeModifier : IProjectTreeModifier
    {
        [Import]
        public Lazy<IProjectTreeFactory> TreeFactory { get; set; }

        public IProjectTree ApplyModifications(IProjectTree tree, IProjectTreeProvider projectTreeProvider)
        {
            if (tree.Capabilities.Contains("ProjectRoot"))
            {
                tree = tree.SetIcon(Resources.Script);
            }
            return tree;
        }
    }
}