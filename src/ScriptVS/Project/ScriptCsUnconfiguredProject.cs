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
    [PartMetadata("Microsoft.VisualStudio.ProjectSystem.ProjectCapabilityRequired", Constants.ScriptCS)]
    [ProjectTypeRegistration(Constants.ProjectTypeGuid,
        "ScriptCS", "ScriptCS Project Files (*.csxproj);*.csproj", "csxproj",
        "ScriptCS", Constants.PackageGuid, PossibleProjectExtensions = "csxproj",
        LanguageVsTemplate = "ScriptCS", ProjectTemplatesDir = "ProjectTemplates\\ScriptCsApp")]
    public class ScriptCsUnconfiguredProject
    {
        private readonly object syncObject = new object();
        private ConfiguredProjectImporter configuredProjectImporter;
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

        public ScriptCsConfiguredProject NuProjActiveConfiguredProject
        {
            get
            {
                Initialize();
                return configuredProjectImporter.ScriptCsConfiguredProject;
            }
        }

        public ConfiguredProject ActiveConfiguredProject
        {
            get
            {
                Initialize();
                return configuredProjectImporter.ConfiguredProject;
            }
        }

        private void Initialize()
        {
            lock (syncObject)
            {
                if (configuredProjectImporter != null)
                {
                    return;
                }
                configuredProjectImporter = new ConfiguredProjectImporter();
                ActiveConfiguredProjectBrokerService.Value.Register(configuredProjectImporter, true);
            }
        }

        private sealed class ConfiguredProjectImporter
        {
            [Import]
            internal ScriptCsConfiguredProject ScriptCsConfiguredProject { get; private set; }

            [Import]
            internal ConfiguredProject ConfiguredProject { get; private set; }
        }
    }
}