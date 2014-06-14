using System.ComponentModel.Composition;
using Microsoft.VisualStudio.ProjectSystem;

namespace ScriptVS.Project
{
    [Export]
    [PartMetadata("Microsoft.VisualStudio.ProjectSystem.ProjectCapabilityRequired", Constants.ScriptCS)]
    public sealed class ProjectProperties
    {
        [Import]
        private ConfiguredProject ConfiguredProject { get; set; }

        private string File { get; set; }

        private string ItemType { get; set; }

        private string ItemName { get; set; }

        //internal ConfigurationGeneral ConfigurationGeneral
        //{
        //    get
        //    {
        //        return new ConfigurationGeneral(this.ConfiguredProject, "Project", this.File, this.ItemType, this.ItemName);
        //    }
        //}

        //internal ConfigurationGeneralBrowseObject ConfigurationGeneralBrowseObject
        //{
        //    get
        //    {
        //        return new ConfigurationGeneralBrowseObject(this.ConfiguredProject, "Project", this.File, this.ItemType, this.ItemName);
        //    }
        //}

        //internal Folder Folder
        //{
        //    get
        //    {
        //        return new Folder(this.ConfiguredProject, "Project", this.File, this.ItemType, this.ItemName);
        //    }
        //}

        //internal Content Content
        //{
        //    get
        //    {
        //        return new Content(this.ConfiguredProject, "Project", this.File, this.ItemType, this.ItemName);
        //    }
        //}

        //internal None None
        //{
        //    get
        //    {
        //        return new None(this.ConfiguredProject, "Project", this.File, this.ItemType, this.ItemName);
        //    }
        //}

        //internal SourceControl SourceControl
        //{
        //    get
        //    {
        //        return new SourceControl(this.ConfiguredProject, "Project", this.File, this.ItemType, this.ItemName);
        //    }
        //}

        //internal ProjectReference ProjectReference
        //{
        //    get
        //    {
        //        return new ProjectReference(this.ConfiguredProject, "Project", this.File, this.ItemType, this.ItemName);
        //    }
        //}

        //internal ResolvedProjectReference ResolvedProjectReference
        //{
        //    get
        //    {
        //        return new ResolvedProjectReference(this.ConfiguredProject, "Project", this.File, this.ItemType, this.ItemName);
        //    }
        //}
    }
}