using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.ProjectSystem;
using Microsoft.VisualStudio.ProjectSystem.Designers;
using Microsoft.VisualStudio.ProjectSystem.Utilities;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace ScriptVS.Project
{
    [Export]
    [PartMetadata(ProjectCapabilities.Requires, Constants.ScriptCS)]
    [ProjectTypeRegistration(projectTypeGuid: Constants.ProjectTypeGuid, 
        displayName: Constants.ScriptCS, 
        displayProjectFileExtensions: Constants.csxprojProjectFileExtension, 
        defaultProjectExtension: Constants.csxprojExtension,
        language: Constants.ScriptCS, 
        resourcePackageGuid: Constants.PackageGuid, 
        PossibleProjectExtensions = Constants.csxprojExtension,
        LanguageVsTemplate = Constants.ScriptCS)]
    public class ScriptCsUnconfiguredProject
    {
        private Lazy<IVsSolutionBuildManager> solutionBuildManager;

        public ScriptCsUnconfiguredProject()
        {
            solutionBuildManager = new Lazy<IVsSolutionBuildManager>(
                    () => Package.GetGlobalService(typeof(SVsSolutionBuildManager)) as IVsSolutionBuildManager, true);
        }

        [Import]
        public UnconfiguredProject UnconfiguredProject { get; private set; }

        [Import]
        public Lazy<IProjectConfigurationsService> ProjectConfigurationsService { get; set; }

        [Import]
        public Lazy<IActiveConfiguredProjectBrokerService> ActiveConfiguredProjectBrokerService { get; set; }
    }
}